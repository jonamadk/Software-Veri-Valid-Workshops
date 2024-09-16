using BankAccountLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTests
{
    public class ASavingsAccount
    {


        [Test]
        public void ShouldSetInitialBalanceAnnualInterestRateAndAccountStatusWhenConstructed()
        {


            //Act

        decimal initialBalance = 100m;
        double annualInterestRate = 0.5;
       

        var sut = new SavingsAccount(initialBalance, annualInterestRate);

            Assert.That(sut.Balance, Is.EqualTo(initialBalance));
            Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
            Assert.That(sut.Status, Is.EqualTo(ActiveStatus.Active));


        }

    }
}
