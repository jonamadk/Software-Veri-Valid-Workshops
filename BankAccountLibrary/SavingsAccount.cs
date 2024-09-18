using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary;
namespace BankAccountLibrary
{

    public enum AccountStatus
    {
        Active,
        Inactive
    }
    public class SavingsAccount : BankAccount
    {

        public AccountStatus Status { get; set; }

        public SavingsAccount(decimal initialBalance, double annualInterestRate) : base(initialBalance, annualInterestRate)
        {

            if (Balance > 25) { Status = AccountStatus.Active; }
            else { Status = AccountStatus.Inactive; }

            Console.WriteLine($"{ Status}and {Balance}");
        }

        public override void Withdraw(decimal withdrawAmount)
        {
            if (Status == AccountStatus.Active)
            {
                base.Withdraw(withdrawAmount);

            }
            
        }

        public override void Deposit(decimal depositAmount)
        {
            base.Deposit(depositAmount);

            if (Status == AccountStatus.Inactive && Balance > 25)
            {
                Status = AccountStatus.Active;
            }
            //else
            //{ Status = AccountStatus.Inactive; }

        }

        public override void MonthlyProcess()
        {
            if (NumberOfWithdrawls > 4)
            {
                MonthlyServiceCharge += NumberOfWithdrawls - 4;
          
            }


            base.MonthlyProcess();

            if (Balance <= 25)
            {
                Status = AccountStatus.Inactive;


            }
            else
            {
                Status = AccountStatus.Active;
            }
        }

    }
}