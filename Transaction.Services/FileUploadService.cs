using System;
using Transaction.Entities;
using Transaction.Infrastructure.Repositories.Interfaces;
using Transaction.Services.Interfaces;

namespace Transaction.Services
{
    public class FileUploadService : IFileUploadService
    {

        protected readonly IRepositoryWrapper _repositoryWrapper;

        public FileUploadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public bool UploadCSVData()
        {
            try
            {
                // 1. Read data from CSV
                // 2. Validate transaction &  Create transactions
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
}
