using System;
using System.Collections.Generic;
using System.Linq;
using Transaction.Entities;
using Transaction.Entities.DTOs;
using Transaction.Infrastructure.Persistance;
using Transaction.Infrastructure.Repositories.Interfaces;

namespace Transaction.Infrastructure.Repositories
{
    public class TransactionRepository : RepositoryBase<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(TransactionDBContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<TransactionEntity> GetTransactions(string currency, string fromDate, string toDate, string status)
        {
            // query
            var query =
                 from transc in RepositoryContext.Transactions
                 where transc.Status == status && transc.CurrencyCode == currency &&  transc.TransactionDate >= DateTime.ParseExact(fromDate, "yyyy/MM/dd", null) &&
                  transc.TransactionDate <= DateTime.ParseExact(toDate, "yyyy/MM/dd", null)
                 select transc;
            return query;

        }
        public IEnumerable<TransactionEntity> GetTransactionsByCurrency(string currency)
        {
            // query
            var query =
                 from transc in RepositoryContext.Transactions
                 where   transc.CurrencyCode == currency  
                 select transc;
            return query;

        }

        public IEnumerable<TransactionEntity> GetTransactionsByDateRange( string fromDate, string toDate )
        {
            // query
            var query =
                 from transc in RepositoryContext.Transactions
                 where  transc.TransactionDate >= DateTime.ParseExact(fromDate, "yyyy/MM/dd", null) &&
                  transc.TransactionDate <= DateTime.ParseExact(toDate, "yyyy/MM/dd", null)
                 select transc;
            return query;

        }

        public IEnumerable<TransactionEntity> GetTransactionsByStatus( string status)
        {
            // query
            var query =
                 from transc in RepositoryContext.Transactions
                 where transc.Status == status 
                 select transc;
            return query;

        }

    }
}
