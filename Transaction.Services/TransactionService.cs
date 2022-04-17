using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Entities;
using Transaction.Infrastructure.Repositories.Interfaces;
using Transaction.Services.Interfaces;

namespace Transaction.Services
{
    public class TransactionService : ITransactionService
    {

        protected readonly IRepositoryWrapper _repositoryWrapper;

        public TransactionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public List<TransactionOutputEntity> GetTransactions(string currency, string fromDate, string toDate, string status)
        {
            // 1. Retrieve data from DB
            IEnumerable < TransactionEntity > transResult = _repositoryWrapper.TransactionRepository.GetTransactions(currency, fromDate, toDate, status);
            //2.  mapping for Status 
            List<TransactionOutputEntity> transoutputList = new List<TransactionOutputEntity>();
            foreach (TransactionEntity e in transResult)
            {
                TransactionOutputEntity transactionOutputEntity = new TransactionOutputEntity();
                transactionOutputEntity.id = e.Transaction_Id;
                transactionOutputEntity.payment = e.Amount.ToString() + " " + e.CurrencyCode;
                if (e.InputSource == "csv")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Failed") transactionOutputEntity.status = "R";
                    else if (e.Status == "Finished") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                else if(e.InputSource == "xml") {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Rejected") transactionOutputEntity.status = "R";
                    else if (e.Status == "Done") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                transoutputList.Add(transactionOutputEntity);
            }
             
            //3.  Return response
            return transoutputList;
            //throw new NotImplementedException();
        }

        public List<TransactionOutputEntity> GetTransactionsByCurrency(string currency)
        {
            // 1. Retrieve data from DB
            IEnumerable<TransactionEntity> transResult = _repositoryWrapper.TransactionRepository.GetTransactionsByCurrency(currency);
            //2.  mapping for Status 
            List<TransactionOutputEntity> transoutputList = new List<TransactionOutputEntity>();
            foreach (TransactionEntity e in transResult)
            {
                TransactionOutputEntity transactionOutputEntity = new TransactionOutputEntity();
                transactionOutputEntity.id = e.Transaction_Id;
                transactionOutputEntity.payment = e.Amount.ToString() + " " + e.CurrencyCode;
                if (e.InputSource == "csv")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Failed") transactionOutputEntity.status = "R";
                    else if (e.Status == "Finished") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                else if (e.InputSource == "xml")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Rejected") transactionOutputEntity.status = "R";
                    else if (e.Status == "Done") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                transoutputList.Add(transactionOutputEntity);
            }

            //3.  Return response
            return transoutputList;
            //throw new NotImplementedException();
        }

        public List<TransactionOutputEntity> GetTransactionsByDateRange(string fromDate, string toDate)
        {
            // 1. Retrieve data from DB
            IEnumerable<TransactionEntity> transResult = _repositoryWrapper.TransactionRepository.GetTransactionsByDateRange(fromDate,toDate);
            //2.  mapping for Status 
            List<TransactionOutputEntity> transoutputList = new List<TransactionOutputEntity>();
            foreach (TransactionEntity e in transResult)
            {
                TransactionOutputEntity transactionOutputEntity = new TransactionOutputEntity();
                transactionOutputEntity.id = e.Transaction_Id;
                transactionOutputEntity.payment = e.Amount.ToString() + " " + e.CurrencyCode;
                if (e.InputSource == "csv")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Failed") transactionOutputEntity.status = "R";
                    else if (e.Status == "Finished") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                else if (e.InputSource == "xml")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Rejected") transactionOutputEntity.status = "R";
                    else if (e.Status == "Done") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                transoutputList.Add(transactionOutputEntity);
            }

            //3.  Return response
            return transoutputList;
            //throw new NotImplementedException();
        }

        public List<TransactionOutputEntity> GetTransactionsByStatus(string status)
        {
            // 1. Retrieve data from DB
            IEnumerable<TransactionEntity> transResult = _repositoryWrapper.TransactionRepository.GetTransactionsByStatus(status);
            //2.  mapping for Status 
            List<TransactionOutputEntity> transoutputList = new List<TransactionOutputEntity>();
            foreach (TransactionEntity e in transResult)
            {
                TransactionOutputEntity transactionOutputEntity = new TransactionOutputEntity();
                transactionOutputEntity.id = e.Transaction_Id;
                transactionOutputEntity.payment = e.Amount.ToString() + " " + e.CurrencyCode;
                if (e.InputSource == "csv")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Failed") transactionOutputEntity.status = "R";
                    else if (e.Status == "Finished") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                else if (e.InputSource == "xml")
                {
                    if (e.Status == "Approved") transactionOutputEntity.status = "A";
                    else if (e.Status == "Rejected") transactionOutputEntity.status = "R";
                    else if (e.Status == "Done") transactionOutputEntity.status = "D";
                    else transactionOutputEntity.status = "";
                }
                transoutputList.Add(transactionOutputEntity);
            }

            //3.  Return response
            return transoutputList;
            //throw new NotImplementedException();
        }

    }
}
