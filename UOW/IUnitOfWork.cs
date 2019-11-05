using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOW
{
    public interface IUnitOfWork: IDisposable
    {
        void CommitChanges();
        void RegisterUpdate(BankAccount bankAccount, IUnitOfWorkRepository repository);
    }
}
