




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

        public void IncrementNumberOfWithdrawls()
        {
            NumberOfWithdrawls++;

        }

    

        public void CalculateInterest()

        {
            double MonthlyInterestRate = AnnualInterestRate / 12;
            decimal MonthlyInterest = Balance * new decimal(MonthlyInterestRate);
            Balance += MonthlyInterest;

      
        }
    }
}
