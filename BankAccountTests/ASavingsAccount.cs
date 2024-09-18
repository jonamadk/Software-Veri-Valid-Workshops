using BankAccountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAccountTests
{
    [TestFixture]
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
            Assert.That(sut.Balance, Is.EqualTo(30m));
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
            Assert.That(sut.Balance, Is.EqualTo(15m));
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

        //EDGE CASES

        [TestCase(100, 0.05, AccountStatus.Active)]    // Balance over 25, should be active
        [TestCase(50, 0.02, AccountStatus.Active)]     // Balance over 25, should be active
        [TestCase(10, 0.01, AccountStatus.Inactive)]   // Balance under 25, should be inactive
        [TestCase(25, 0.03, AccountStatus.Inactive)]     // Balance exactly 25, should be inactive
        [TestCase(5, 0.1, AccountStatus.Inactive)]     // Very low balance, should be inactive
        public void ShouldSetInitialBalanceAnnualInterestRateAndAccountStatusCorrectlyWhenConstructedForDifferentCombinationOfInitialBalance(
        decimal initialBalance, double annualInterestRate, AccountStatus expectedStatus)
        {
            // Act
            var sut = new SavingsAccount(initialBalance, annualInterestRate);

            // Assert
            Assert.That(sut.Balance, Is.EqualTo(initialBalance));
            Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
            Assert.That(sut.Status, Is.EqualTo(expectedStatus));
        }




        [TestCase(10, 20, AccountStatus.Active)]  // Deposit pushes balance over 25
        [TestCase(10, 5, AccountStatus.Inactive)] // Deposit keeps balance below 25
        [TestCase(5, 20, AccountStatus.Inactive)]   // Exactly reaches 25
        public void ShouldChangeAccountStatusToActiveAfterTotalDepositAmountIsMoreThan25ForDifferentCombination(
        decimal initialBalance, decimal depositAmount, AccountStatus expectedStatus)
        {
            // Arrange
            double annualInterestRate = 0.05;
            var sut = new SavingsAccount(initialBalance, annualInterestRate);

            // Act
            sut.Deposit(depositAmount);

            // Assert
            Assert.That(sut.Status, Is.EqualTo(expectedStatus));
        }


        [TestCase(100,0.06,10,20,5,65.325,AccountStatus.Active,0,0,0)]
        [TestCase(100, 0.06, 20, 50, 10, 20.1, AccountStatus.Inactive, 0, 0, 0)]

        public void ShouldNotIncreaseMonthlyChargeIfNumberOfWithdrawlsIsLessThan4AndAccountStatusIsInactiveIfBalanceLessThan25ForDifferentCombinations(
            decimal initialBalance, double annualInterestRate, decimal withdrawAmount1, decimal withdrawAmount2, decimal MonthlyServiceChargeRate, decimal expectedBalance, AccountStatus expectedStatus,
            double expectedNumberOfWithdrawls, double expectedNumberOfDeposits, decimal expectedMonthlyServiceCharge )
        {

            //Arrange
      
            var sut = new SavingsAccount(initialBalance, annualInterestRate);
            sut.Withdraw(withdrawAmount1);
            sut.Withdraw(withdrawAmount2);

            sut.MonthlyServiceCharge = MonthlyServiceChargeRate;

            //Act
            sut.MonthlyProcess();

            //Assert
            Assert.That(sut.Balance, Is.EqualTo(expectedBalance));
            Assert.That(sut.Status, Is.EqualTo(expectedStatus));
            Assert.That(sut.NumberOfWithdrawls, Is.EqualTo(expectedNumberOfWithdrawls));
            Assert.That(sut.NumberOfDeposits, Is.EqualTo(expectedNumberOfDeposits));
            Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(expectedMonthlyServiceCharge));


        }
    }
}
