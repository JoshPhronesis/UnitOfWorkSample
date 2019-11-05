namespace UOW
{
    public interface IUnitOfWorkRepository
    {
        void PersistUpdate(BankAccount item);
    }
}
