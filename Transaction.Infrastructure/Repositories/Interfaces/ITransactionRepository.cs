using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Entities;
using Transaction.Entities.DTOs;

namespace Transaction.Infrastructure.Repositories.Interfaces
{
    public interface ITransactionRepository:IRepositoryBase<TransactionEntity>
    {
        IEnumerable<TransactionEntity> GetTransactions(string currency,string fromDate,string toDate,string status);

        IEnumerable<TransactionEntity> GetTransactionsByCurrency(string currency);
        IEnumerable<TransactionEntity> GetTransactionsByDateRange(string fromDate, string toDate);
        IEnumerable<TransactionEntity> GetTransactionsByStatus(string status);

    }
}
