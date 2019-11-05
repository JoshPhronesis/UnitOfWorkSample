using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOW.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        Dictionary<BankAccount, IUnitOfWorkRepository> updatedChanges;

        public UnitOfWork()
        {
            updatedChanges = new Dictionary<BankAccount, IUnitOfWorkRepository>();
        }

        public void CommitChanges()
        {
            foreach (var item in updatedChanges.Keys)
            {
                updatedChanges[item].PersistUpdate(item);
            }
        }

        public void RegisterUpdate(BankAccount bankAccount, IUnitOfWorkRepository repository)
        {
            if (!updatedChanges.ContainsKey(bankAccount))
            {
                updatedChanges.Add(bankAccount, repository);
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}
