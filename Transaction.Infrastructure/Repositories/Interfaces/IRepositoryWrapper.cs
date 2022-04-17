namespace Transaction.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IShiftMasterRepository ShiftMaster { get; }
        ITransactionRepository TransactionRepository { get; }

    }
}
