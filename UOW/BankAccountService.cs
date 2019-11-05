using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOW
{
    public class BankAccountService: IBankAccountService
    {
        private readonly IRepository repo;
        private readonly IUnitOfWork unitOfWork;

        public BankAccountService(IRepository repo, IUnitOfWork unitOfWork)
        {
            this.repo = repo;
            this.unitOfWork = unitOfWork;
        }

        public BankAccount Get(int acctNo)
        {
            return repo.Find(acctNo);
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return repo.GetAll();
        }

        public void Transfer(BankAccount fromAccount, BankAccount toAccount, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException(nameof(amount));

            if (!fromAccount.CanTransfer(amount))
                throw new ApplicationException("Insufficient funds");

            using (unitOfWork)
            {
                fromAccount.AmountAvailable -= amount;
                repo.Update(fromAccount);
                toAccount.AmountAvailable += amount;
                repo.Update(toAccount);
                unitOfWork.CommitChanges();
            }
        }
    }
}
