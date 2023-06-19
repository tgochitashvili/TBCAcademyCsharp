namespace A8Task2
{
    internal class Part1
    {
        static void Main(string[] args)
        {
            BankAccount acc0 = new BankAccount("AccNumber0", "Name0", new Currency("GEL", 1000M));
            BankAccount acc1 = new BankAccount("AccNumber1", "Name1", new Currency("GEL", 2000M));

            Console.WriteLine(acc0.BalanceCheck());
            Console.WriteLine(acc1.BalanceCheck());

            Console.WriteLine("Transfering 500 GEL from acc0 to acc1");
            acc0.TransferFunds(acc1, new Currency("GEL", 500M));

            Console.WriteLine(acc0.BalanceCheck());
            Console.WriteLine(acc1.BalanceCheck());



            Console.WriteLine("Withdrawing 500 from acc0 and depositing 1000 to acc1");

            acc0.Withdraw(new Currency("GEL", 500M));
            acc1.Deposit(new Currency("GEL", 1000M));

            Console.WriteLine(acc0.BalanceCheck());
            Console.WriteLine(acc1.BalanceCheck());
        }
    }

    internal partial class BankAccount
    {
        private string AccountNumber;
        private string AccountHolderName;
        private Currency Balance {
            get; set;
        }

        public BankAccount(string AccountNumber, string AccountHolderName, Currency Balance)
        {
            this.AccountNumber = AccountNumber;
            this.AccountHolderName = AccountHolderName;
            this.Balance = Balance;
        }

        public void Deposit(Currency amount)
        {
            Balance += amount;
        }

        public void Withdraw(Currency amount)
        {
            Balance -= amount;
        }

        public decimal BalanceCheck()
        {
            return this.Balance.Amount;
        }
    }

    internal struct Currency
    {
        internal string CurrencyCode{
            get; set;
        }
        internal decimal Amount
        {
            get; set;
        }
        public Currency(string currencyCode, decimal amount)
        {
            this.CurrencyCode = currencyCode;
            this.Amount = amount;
        }
        public static Currency operator +(Currency a, Currency b)
        {
            if(a.CurrencyCode == b.CurrencyCode)
            {
                a.Amount += b.Amount;
                return a;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static Currency operator -(Currency a, Currency b)
        {
            if (a.CurrencyCode == b.CurrencyCode)
            {
                a.Amount -= b.Amount;
                return a;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}