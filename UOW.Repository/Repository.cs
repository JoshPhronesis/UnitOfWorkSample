using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UOW.Repository
{
    public class Repository : IRepository, IUnitOfWorkRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private IList<BankAccount> bankAccounts;

        public Repository(IUnitOfWork unitOfWork)
        {
            bankAccounts = new List<BankAccount>()
            {
                new BankAccount(){AccountNumber=1, AmountAvailable=100, Name="Joshua"},
                new BankAccount(){AccountNumber=2, AmountAvailable=200, Name="Eve"},
                new BankAccount(){AccountNumber=3, AmountAvailable=300, Name="Jen"},
            };
            this.unitOfWork = unitOfWork;
        }

        public BankAccount Find(int acctNum)
        {
            if (acctNum <= 0)
                throw new ApplicationException($"Invalid account number {acctNum}");

            return bankAccounts.FirstOrDefault(acct => acct.AccountNumber == acctNum);
        }

        public IEnumerable<BankAccount> GetAll() => bankAccounts;

        public void PersistUpdate(BankAccount account)
        {
            bankAccounts.Add(account);
        }

        public void Update(BankAccount bankAccount)
        {
            unitOfWork.RegisterUpdate(bankAccount, this);
        }
    }
}
