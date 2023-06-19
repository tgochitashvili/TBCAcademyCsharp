namespace A8Task2
{
    internal partial class BankAccount
    {
        public void TransferFunds(BankAccount target, Currency amount)
        {
            if(this.Balance.CurrencyCode == target.Balance.CurrencyCode)
            {
                this.Balance -= amount;
                target.Balance += amount;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
