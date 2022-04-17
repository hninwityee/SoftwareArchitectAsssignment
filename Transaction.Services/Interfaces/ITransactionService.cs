using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Entities;

namespace Transaction.Services.Interfaces
{
    public interface ITransactionService
    {
        List<TransactionOutputEntity> GetTransactions(string currency, string fromDate, string toDate, string status);
        List<TransactionOutputEntity> GetTransactionsByCurrency(string currency);
        List<TransactionOutputEntity> GetTransactionsByDateRange(string fromDate, string toDate);
        List<TransactionOutputEntity> GetTransactionsByStatus(string status);

    }
}
