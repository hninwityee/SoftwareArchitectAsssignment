namespace Transaction.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITransactionRepository TransactionRepository { get; }

    }
}
