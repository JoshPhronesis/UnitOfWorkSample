using Autofac;
using System;
using UOW;
using static System.Console;

namespace UOw.Console
{
    class Program
    {
        public static IContainer Container { get; set; }
        private static readonly IBankAccountService bankAccountService;
        static Program()
        {
            Container = DIContainer.Build();
            bankAccountService = Container.Resolve<IBankAccountService>();
        }
       
        static void Main(string[] args)
        {
            Container = DIContainer.Build();
            DisplayAvailableAccounts();
            Read();
        }

        private static void DisplayAvailableAccounts()
        {
            var accounts = bankAccountService.GetAllAccounts();
            WriteLine("*****ACCOUNTS*****");
            foreach (BankAccount account in accounts)
            {
                WriteLine(string.Format("\tNo-{0}, Name-{1}, AmountAvailable-{2}", account.AccountNumber, account.Name, account.AmountAvailable));
            }

            WriteLine("******************\n");
            TransferPromt();

            WriteLine();
        }

        private static void TransferPromt()
        {
            bool transfer = false;
            while (!transfer)
            {
                WriteLine("Would you like to make a new transfer ?");
                string input = ReadLine();
                if (input.ToLower() == "y")
                {
                    ProcessTransfer();
                }
            }
        }

        private static void ProcessTransfer()
        {
            Output("*****Please Enter transfer details in this format amount,acctFrom,acctTo");
            string[] input = ReadLine().Split(',');
            int amount=0, acctFrom =0, acctTo =0;
            if (input.Length != 3)
                InvalidTransferDetails();
            if (!int.TryParse(input[0], out amount) || !int.TryParse(input[1], out acctFrom) || !int.TryParse(input[2],out acctTo))
                InvalidTransferDetails();

            Output($"*****Processing transfer of {input[0]} from {input[1]} to {input[2]}*****");

            BankAccount toAccount = bankAccountService.Get(acctTo);
            BankAccount fromAccount = bankAccountService.Get(acctFrom);

            if (fromAccount == null || toAccount == null)
                InvalidTransferDetails();

            bankAccountService.Transfer(fromAccount, toAccount, amount);

            Output("*****Transfer Complete*****");
            DisplayAvailableAccounts();
        }

        private static void Output(string message)
        {
            WriteLine(message);
        }

        private static void InvalidTransferDetails()
        {
            throw new ArgumentException("Please enter a valid transfer request");
        }
    }
}
