using System;
using Transaction.Entities;
using Transaction.Infrastructure.Repositories.Interfaces;
using Transaction.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Transaction.Services
{
    public class FileUploadService : IFileUploadService
    {

        protected readonly IRepositoryWrapper _repositoryWrapper;

        public FileUploadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public FileUploadResponse UploadFile(IFormFile _ufile)
        {

            string errmsg = "";
            try
            {

                if (_ufile.ContentType != "text/csv" && _ufile.ContentType != "text/xml")
                {
                    errmsg = "Invalid File Type";
                    return new FileUploadResponse() { Status = "NotOk", ErrorMessage = errmsg } ;
                }
              

                if (_ufile.Length > 0)
                {
                    if (_ufile.Length < 1048576)
                    {
                        if (_ufile.ContentType == "text/xml")
                        {

                            ////Reading XML File
                            XmlSerializer serializer = new XmlSerializer(typeof(Transactions));
                            using (var stream = _ufile.OpenReadStream())
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                Transactions _transactions = (Transactions)serializer.Deserialize(reader);
                                for (var i = 0; i < _transactions.Transaction.Count; i++)
                                {
                                    Transaction transaction = _transactions.Transaction[i];
                                    string transid = "";
                                    decimal amount;
                                    string curcode;
                                    DateTime transdate;
                                    string status = "";
                                    
                                    //Transaction ID
                                    if (transaction.Id.Length == 0)
                                    {
                                        errmsg = "TransactionID is required ";
                                        break;
                                    }
                                    else if (transaction.Id.Length > 50)
                                    {
                                        errmsg = "TransactionID should not exceed 50 characters ";
                                        break;
                                    }
                                    else
                                    {
                                        transid = transaction.Id;

                                    }
                                    //Amount
                                     amount = transaction.PaymentDetails.Amount;

                                     
                                    //Currency Code
                                    if (transaction.PaymentDetails.CurrencyCode.Length == 0)
                                    {
                                        errmsg = "Currency Code is required";
                                        break;
                                    }
                                    else
                                    {
                                        curcode = transaction.PaymentDetails.CurrencyCode;
                                    }
                                    //Transaction Date
                                    
                                        try
                                        {
                                        transdate = transaction.TransactionDate;

                                        }
                                        catch (Exception)
                                        {
                                            errmsg = "Invalid Date Format at Transaction Date Column ";
                                            break;
                                        }
                                    
                                    //Status
                                    if (transaction.Status.Length == 0)
                                    {
                                        errmsg = "Status is required";
                                        break;
                                    }
                                    else if (transaction.Status == "Approved" || transaction.Status == "Rejected" || transaction.Status == "Done")
                                    {
                                        status = transaction.Status;
                                    }
                                    else { errmsg = "Invalid Status."; break; }

                                    if (errmsg == "")
                                    {
                                        TransactionEntity _transaction = new TransactionEntity();
                                        _transaction.Transaction_Id = transid;
                                        _transaction.Amount = amount;
                                        _transaction.Status = status;
                                        _transaction.TransactionDate = transdate;
                                        _transaction.CurrencyCode = curcode;
                                        _transaction.InputSource = "xml";
                                        _repositoryWrapper.TransactionRepository.Create(_transaction, false);
                                    }
                                }

                                // out of loop
                                if (errmsg == "")
                                {
                                    _repositoryWrapper.TransactionRepository.Save();
                                }

                            }

                        }
                        else
                        {
                            ////Reading csv File
                            var result = new StringBuilder();
                            using (var reader = new StreamReader(_ufile.OpenReadStream()))
                            {
                                while (reader.Peek() >= 0)
                                {
                                    var _row = reader.ReadLine();


                                    string transid = "";
                                    decimal amount;
                                    string curcode;
                                    DateTime transdate;
                                    string status = "";
                                    string[] cell = _row.Split(',');

                                    //Transaction ID
                                    if (cell[0].Length == 0)
                                    {
                                        errmsg = "TransactionID is required ";
                                        break;
                                    }
                                    else if (cell[0].Length > 50)
                                    {
                                        errmsg = "TransactionID should not exceed 50 characters ";
                                        break;
                                    }
                                    else
                                    {
                                        transid = cell[0];

                                    }
                                    //Amount
                                    if (cell[1].Length == 0)
                                    {
                                        errmsg = "Amount is required ";
                                        break;
                                    }
                                    else if (!int.TryParse(cell[1], out int n))
                                    {
                                        errmsg = "Invalid Amount value ";
                                        break;
                                    }
                                    else
                                    {
                                        amount = decimal.Parse(cell[1]);

                                    }
                                    //Currency Code
                                    if (cell[2].Length == 0)
                                    {
                                        errmsg = "Currency Code is required";
                                        break;
                                    }
                                    else
                                    {
                                        curcode = cell[2];
                                    }
                                    //Transaction Date
                                    if (cell[3].Length == 0)
                                    {
                                        errmsg = "Transaction Date is required";
                                        break;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            transdate = DateTime.ParseExact(cell[3], "dd/MM/yyyy hh:mm:ss", null);

                                        }
                                        catch (Exception)
                                        {
                                            errmsg = "Invalid Date Format at Transaction Date Column ";
                                            break;
                                        }
                                    }
                                    //Status
                                    if (cell[4].Length == 0)
                                    {
                                        errmsg = "Status is required";
                                        break;
                                    }
                                    else if (cell[4] == "Approved" || cell[4] == "Failed" || cell[4] == "Finished")
                                    {
                                        status = cell[4];
                                    }
                                    else { errmsg = "Invalid Status."; break; }

                                    if (errmsg == "")
                                    {
                                        TransactionEntity _transaction = new TransactionEntity();
                                        _transaction.Transaction_Id = transid;
                                        _transaction.Amount = amount;
                                        _transaction.Status = status;
                                        _transaction.TransactionDate = transdate;
                                        _transaction.CurrencyCode = curcode;
                                        _transaction.InputSource = "csv";
                                        _repositoryWrapper.TransactionRepository.Create(_transaction, false);
                                    }
                                }

                                // out of loop
                                if (errmsg == "")
                                {
                                    _repositoryWrapper.TransactionRepository.Save();
                                }
                            }
                        }
                    }
                    else
                    {
                        errmsg = "Uploaded file should not exceed maximum file size(1 MB).";
                    }

                }
                else
                {
                    errmsg = "Please select a valid file";
                }
                if (errmsg == "") { return new FileUploadResponse() { Status = "Ok", ErrorMessage = "" }; }
                else { return new FileUploadResponse() { Status = "NotOk", ErrorMessage = errmsg }; }

            }
            catch (Exception ex)
            {
                return new FileUploadResponse() { Status = "NotOk", ErrorMessage = ex.Message.ToString() };
            }
        }



        public bool UploadXMLData()
        {
            try
            {
                // 1. Prepare data from XML
                // 2. Validate transaction & Create transactions
                // 3. Save after creating all transactions.

                TransactionEntity transaction = new TransactionEntity();
                _repositoryWrapper.TransactionRepository.Create(transaction);

                // out of loop
                _repositoryWrapper.TransactionRepository.Save();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;// temp
        }
    }

    public class FileUploadResponse
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    [XmlRoot(ElementName = "PaymentDetails")]
    public class PaymentDetails
    {

        [XmlElement(ElementName = "Amount")]
        public decimal Amount { get; set; }

        [XmlElement(ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
    }

    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {

        [XmlElement(ElementName = "TransactionDate")]
        public DateTime TransactionDate { get; set; }

        [XmlElement(ElementName = "PaymentDetails")]
        public PaymentDetails PaymentDetails { get; set; }

        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Transactions")]
    public class Transactions
    {

        [XmlElement(ElementName = "Transaction")]
        public List<Transaction> Transaction { get; set; }
    }

}
