using BankAccountLibrary;
using System.Security.Cryptography.X509Certificates;

namespace BankAccountTests
{
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
            Assert.That(sut.Balance, Is.EqualTo(200m));
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
            double annualInterestRate = 0.6;

            var sut = new BankAccount (initialBalance, annualInterestRate);

            //Act
            sut.CalculateInterest();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(105m));

        }

        [Test]
        public void ShouldUpdateMonthlyBalanceResetNumberOfWithdrawslsNumberOfDepositsAndMonthlyServiceCharge()
        {


            //Arrange

            decimal initialBalance = 100m;
            double annualInterestRate = 0.6;

            var sut = new BankAccount(initialBalance, annualInterestRate);

            sut.MonthlyServiceCharge = 10m;

            //Act
            sut.MonthlyProcess();


            //Assert
            Assert.That(sut.Balance,Is.EqualTo(94.5m));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(0));
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
            Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));

        }
       

 

       




    }
}