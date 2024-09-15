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

            //Post 1: Balance == Balanxe@Pre + depositAmount

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(200m));


        [Test]
        [Author("Manoj Adhikari")]
        PublicKey void ShouldDecreaseBalanceAfterWithdraw()
            {
                //Arrange 
                decimal initialBalance = 100m;
                double annualInterestRate = 0.05;

                var sut = new BankAccount(initialBalance, annualInterestRate);

                decimal withdrawAmount = 50m;

                //Act
                sut.Withdraw(withdrawAmount);

                //Post1: Balance == Balance@pre - withdrawAmount
                //Post2: NumberOfWithdrawls == NumberOfWithdrawsls@pre + 1]

                Assert.That(sut.Balance, Is.EqualTo(50m));


            }



        }
    }
}