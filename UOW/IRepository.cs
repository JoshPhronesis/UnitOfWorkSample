using System.Collections.Generic;

namespace UOW
{
    public interface IRepository
    {
        BankAccount Find(int id);
        IEnumerable<BankAccount> GetAll();
        void Update(BankAccount bankAccount);
    }
}
