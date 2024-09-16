using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary;
namespace BankAccountLibrary
{

   public enum ActiveStatus
    {
        Active,
        Inactive
    }
    public class SavingsAccount: BankAccount
    {

        public ActiveStatus Status { get; set; }

        public SavingsAccount(decimal initialBalance, double annualInterestRate) :base ( initialBalance,  annualInterestRate)
        {

                if (Balance>25) { Status = ActiveStatus.Active; }
                else { Status = ActiveStatus.Inactive; }
        }
        
      
    }
}
