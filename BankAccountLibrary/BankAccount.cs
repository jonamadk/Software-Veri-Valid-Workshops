





namespace BankAccountLibrary
{
    public class BankAccount
    {

        public decimal Balance { get; private set; }
        public double AnnualInterestRate { get; }
        public int NumberOfDeposits { get; private set; }

        public int NumberOfWithdrawls { get; private set; }

        public decimal MonthlyServiceCharge { get; set; }

        public BankAccount(decimal initialBalance, double annualInterestRate)
        {
            Balance = initialBalance;
            AnnualInterestRate = annualInterestRate;
        }

        public virtual void Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
            NumberOfDeposits++;
        }

        public virtual void Withdraw(decimal withdrawAmount)
        {
            Balance -= withdrawAmount;
            NumberOfWithdrawls++;
        }

    

        public void CalculateInterest()

        {
            double MonthlyInterestRate = AnnualInterestRate / 12;
            decimal MonthlyInterest = Balance * new decimal(MonthlyInterestRate);
            Balance += MonthlyInterest;

      
        }

        public virtual void MonthlyProcess()
        {
            Balance -= MonthlyServiceCharge;
            CalculateInterest();
            NumberOfDeposits = 0;
            NumberOfWithdrawls = 0;
            MonthlyServiceCharge = 0;
            
        }
    }
}
