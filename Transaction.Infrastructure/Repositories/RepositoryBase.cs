using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Transaction.Infrastructure.Persistance;
using Transaction.Infrastructure.Repositories.Interfaces;

namespace Transaction.Infrastructure.Repositories
{
    public  abstract class RepositoryBase<T>:IRepositoryBase<T> where T : class
    {
        protected TransactionDBContext RepositoryContext { get; set; }

        public RepositoryBase(TransactionDBContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            if (flush) this.Save();
        }

        public void Update(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            if (flush) this.Save();
        }

        public void Delete(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            if (flush) this.Save();
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }

      
    }
}
