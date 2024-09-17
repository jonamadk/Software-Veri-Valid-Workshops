using BankAccountLibrary;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace BankAccountTests
{
    [TestFixture]
    public class ABankAccount
    {
        [Test]
        public void ShouldSetBalanceAndAnnualInterestRateWhenConstructed()
        {
            //Arrange 
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;

            //Act
            var sut = new BankAccount(initialBalance, annualInterestRate);

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(initialBalance));
            Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
        }

        [Test]
        public void ShouldIncreaseBalanceAfterADeposit()
        {
            //Arrange 
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);

            decimal depositAmount = 100m;
            var NumberofPreDeposit = sut.NumberOfDeposits;

            //Act
            sut.Deposit(depositAmount);
            //Post 1: Balance == Balance@Pre + depositAmount
            //Post 2: NumberOfDeposits == NumberOfDeposits@pre + 1

            //Assert
            //Assert.That(sut.Balance, Is.EqualTo(200m));
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(NumberofPreDeposit + 1));
           
         
        }


        [Test]
        [Author("Manoj Adhikari")]
        public void ShouldDecreaseBalanceAfterWithdrawAndIncreaseNumberOfWithdrawlsBy1()
        {
            //Arrange 
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);
            decimal withdrawAmount = 50m;

            var NumberOfPreWithdrawls = sut.NumberOfWithdrawls;
          

            //Act
            sut.Withdraw(withdrawAmount);

            //Post1: Balance == Balance@pre - withdrawAmount
            

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(initialBalance - withdrawAmount));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(NumberOfPreWithdrawls + 1));
        }


        [Test]
        public  void ShouldCalcualteInterestRateAndIncreaseBalanceAccordingly()
        {

            //Arrange

            decimal initialBalance = 100m;
            double annualInterestRate = 0.06;

            var sut = new BankAccount (initialBalance, annualInterestRate);

            //Act
            sut.CalculateInterest();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(100.5m));

        }

        [Test]
        public void ShouldUpdateMonthlyBalanceResetNumberOfWithdrawslsNumberOfDepositsAndMonthlyServiceCharge()
        {


            //Arrange

            decimal initialBalance = 100m;
            double annualInterestRate = 0.06;

            var sut = new BankAccount(initialBalance, annualInterestRate);

            sut.MonthlyServiceCharge = 10m;

            //Act
            sut.MonthlyProcess();


            //Assert
            Assert.That(sut.Balance,Is.EqualTo(90.45m));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(0));
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
            Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));

        }


        //EDGE CASES
        [Test]
        public void ShouldNotIncreaseTheBalanceWhenDepositAmountIsZero()
        {
            //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);
            decimal DepositAmount = 0m;

            //Act
            sut.Deposit(DepositAmount);

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(100m));

        }
        [Test]
        public void ShouldNotIncreaseTheBalanceWhenDepositAmountIsNegative()
        {
            //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);
            decimal DepositAmount = -50m;

            //Act
            sut.Deposit(DepositAmount);

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(100m));
         

        }

        [Test]
        public void ShouldNotDecreaseTheBalanceWhenWithdrawlAmountIsZero()
        {

            //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);
            decimal withdrawlAmount = 0m;

            //Act
            sut.Withdraw(withdrawlAmount);


            //Assert
            Assert.That(sut.Balance, Is.EqualTo(100m));


        }



        [TestCase(100, 0.5, 0, 100)]   //CASE 1: Zero Withdrawl Amount;  WithdrawlAmount = 0
        [TestCase(100, 0.5, -50, 100)] //CASE 2: Negative Withdrawl Amount; WithdrawlAmount = -50 
        public void ShouldNotDecreaseTheBalanceWhenWithdrawlAmountIsNegativeOrZero(decimal initialBalance, double annualInterestRate, decimal withdrawlAmount, decimal expectedBalance)
        {

            //Arrange
            var sut = new BankAccount(initialBalance, annualInterestRate);
       

            //Act
            sut.Withdraw(withdrawlAmount);


            //Assert
            Assert.That(sut.Balance, Is.EqualTo(expectedBalance));


        }

        [TestCase(100, 0.06, 100.5)]     // 6% interest rate
        [TestCase(200, 0.03, 200.5)]     // 3% interest rate
        [TestCase(0, 0.5, 0)]         // Edge case: Zero balance
        [TestCase(1000, 0.24, 1020)]   // 24% interest rate
        public void ShouldCalcualteInterestRateAndIncreaseBalanceAccordinglyBasedOnDifferentBalanceAndInterestRate(decimal initialBalance, double annualInterestRate, decimal expectedBalance)
        {

            //Arrange


            var sut = new BankAccount(initialBalance, annualInterestRate);

            //Act
            sut.CalculateInterest();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(expectedBalance));

        }









    }
}