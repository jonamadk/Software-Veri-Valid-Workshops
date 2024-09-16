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

            //Act
            sut.Deposit(depositAmount);

            //Post 1: Balance == Balance@Pre + depositAmount

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(200m));
        }


        [Test]
        public void ShouldIncreaseNumberOfdepositBy1()
        {
            //Arrange 
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);
            var NumberofPreDeposit = sut.NumberOfDeposits;

            //Act
            sut.IncrementNumberOfDeposits();

            //Post1: NumberOfDeposits == NumberOfDeposits@pre + 1

            //Assert
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(NumberofPreDeposit+1));
        }


        [Test]
        [Author("Manoj Adhikari")]
        public void ShouldDecreaseBalanceAfterWithdraw()
        {
            //Arrange 
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);
            decimal withdrawAmount = 50m;

            //Act
            sut.Withdraw(withdrawAmount);

            //Post1: Balance == Balance@pre - withdrawAmount
            //Post2: NumberOfWithdrawls == NumberOfWithdrawsls@pre + 1

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(initialBalance - withdrawAmount));
        }


        [Test]
        public void ShouldIncreaseNumberOfWithdrawlsBy1()
        {
            //Arrange 
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
            var sut = new BankAccount(initialBalance, annualInterestRate);

            var NumberOfPreWithdrawls = sut.NumberOfWithdrawls;

            //Act
            sut.IncrementNumberOfWithdrawls();

            //Post1: NumberOfWithdrawls == NumberOfWithdrawls@pre + 1

            //Assert
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
     
       
 

       




    }
}