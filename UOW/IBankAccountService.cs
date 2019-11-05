using System.Collections.Generic;

namespace UOW
{
    public interface IBankAccountService
    {
        BankAccount Get(int acctNo);
        IEnumerable<BankAccount> GetAllAccounts();
        void Transfer(BankAccount fromAccount, BankAccount toAccount, int amount);
    }
}