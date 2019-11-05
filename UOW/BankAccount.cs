using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOW
{
    public class BankAccount
    {
        public int AccountNumber { get;  set; }
        public string Name { get;  set; }
        public int AmountAvailable { get;  set; }

        public bool CanTransfer(int amount) => AmountAvailable >= amount;
    }
}

