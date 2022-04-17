using Transaction.Infrastructure.Persistance;
using Transaction.Infrastructure.Repositories.Interfaces;

namespace Transaction.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private TransactionDBContext _repoContext;

        public RepositoryWrapper(TransactionDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }


       

        private IShiftMasterRepository _shiftMaster;
        public IShiftMasterRepository ShiftMaster
        {
            get
            {
                if (_shiftMaster == null)
                {
                    _shiftMaster = new ShiftMasterRepository(_repoContext);
                }

                return _shiftMaster;
            }
        }

        private ITransactionRepository _transactionRepository;
        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository = new TransactionRepository(_repoContext);
                }

                return _transactionRepository;
            }
        }



    }
}
