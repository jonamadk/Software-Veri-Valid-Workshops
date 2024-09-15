




namespace BankAccountLibrary
{
    public class BankAccount
    {

        public decimal Balance { get; private set; }
        public double AnnualInterestRate { get; }
        public int NumberOfDeposits { get; private set; }

        public int NumberOfWithdrawls { get; private set; }

        public BankAccount(decimal initialBalance, double annualInterestRate)
        {
            Balance = initialBalance;
            AnnualInterestRate = annualInterestRate;
        }

        public void Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
        }

        public void Withdraw(decimal withdrawAmount)
        {
            Balance -= withdrawAmount;
        }

        public void IncrementNumberOfDeposits()
        {
            NumberOfDeposits++;
        }

        public void IncrementNumberOfWithdraws()
        {
            //throw new NotImplementedException();

        }

        public void GenerateMonthlyProcessCharge()
        {
            throw new NotImplementedException();
        }
    }
}
