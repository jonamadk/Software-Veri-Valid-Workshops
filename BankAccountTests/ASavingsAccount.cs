using BankAccountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAccountTests
{
    public class ASavingsAccount
    {


        [Test]
        public void ShouldSetInitialBalanceAnnualInterestRateAndAccountStatusActiveWhenConstructed()
        {
        
        //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.05;
       
        //Act
            var sut = new SavingsAccount(initialBalance, annualInterestRate);

        //Assert
            Assert.That(sut.Balance, Is.EqualTo(initialBalance));
            Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
            Assert.That(sut.Status, Is.EqualTo(AccountStatus.Active));


        }

        [Test]
        public void ShouldSetInitialBalanceAnnualInterestRateAndAccountStatusToInactiveWhenConstructed()
        {

            //Arrange
            decimal initialBalance = 10m;
            double annualInterestRate = 0.05;

            //Act
            var sut = new SavingsAccount(initialBalance, annualInterestRate);

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(initialBalance));
            Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
            Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));


        }


        [Test]
        public void ShouldNotChangeBalanceAfterWithdrawlWhenInactive()
        {
            //Arrange
            decimal initialBalance = 20m;
            double annualInterestRate = 0.05;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            decimal withdrawAmount = 10m;

            //Act
            sut.Withdraw(withdrawAmount);

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(20m));
  
            
        }


        [Test]
        public void ShouldChangeBalanceAfterWithdrawlWhenActive()
        {
            //Arrange
            decimal initialBalance = 200m;
            double annualInterestRate = 0.05;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            decimal withdrawAmount = 10m;

            //Act
            sut.Withdraw(withdrawAmount);

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(190m));


        }



        [Test]
        public void ShouldChangeAccountStatusToActiveAfterTotalDepositAmpuntIsMoreThan25()
        {

            //Arrange
            decimal initialBalance = 10m;
            double annualInterestRate = 0.05;
            var sut = new SavingsAccount (initialBalance, annualInterestRate);
            decimal depositAmount = 20m;

            //Act
            sut.Deposit(depositAmount);

            //Assert
            Assert.That(sut.Status, Is.EqualTo(AccountStatus.Active));
         
        }

        [Test]
        public void ShouldChangeAccountStatusInactiveAfterTotalDepositAmpuntIsLessThan25()
        {

            //Arrange
            decimal initialBalance = 10m;
            double annualInterestRate = 0.05;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            decimal depositAmount = 5m;

            //Act
            sut.Deposit(depositAmount);

            //Assert
            Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));

        }


        [Test]
        public void ShouldIncreaseMonthlyChargeIfNumberOfWithdrawlsIsGreaterThan4AndAccountStatusActiveIfBalanceGreaterThan25()
        {


            //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.06;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.MonthlyServiceCharge = 10m;

            //Act
            sut.MonthlyProcess();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(39.195m));
            Assert.That(sut.Status,Is.EqualTo(AccountStatus.Active));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(0));
            Assert.That(sut.NumberOfDeposits,Is.EqualTo(0));
            Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));
            

        }

        [Test]
        public void ShouldIncreaseMonthlyChargeIfNumberOfWithdrawlsIsGreaterThan4AndAccountStatusIsInactiveIfBalanceLessThan25()
        {

            //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.06;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(30);
            sut.MonthlyServiceCharge = 10m;

            //Act
            sut.MonthlyProcess();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(19.095m));
            Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(0));
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
            Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));


        }
        [Test]
        public void ShouldNotIncreaseMonthlyChargeIfNumberOfWithdrawlsIsLessThan4AndAccountStatusIsInactiveIfBalanceLessThan25()
        {

            //Arrange
            decimal initialBalance = 100m;
            double annualInterestRate = 0.06;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            sut.Withdraw(10);
            sut.Withdraw(10);
            sut.Withdraw(50);
            sut.MonthlyServiceCharge = 10m;

            //Act
            sut.MonthlyProcess();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(20.1m));
            Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(0));
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
            Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));


        }


    }
}
