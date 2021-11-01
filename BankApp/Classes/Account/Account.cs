using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Classes.Account
{
    public enum AccountTypes { Checking, IndividualInvestment, CorporateInvestment };
    public class Account : IAccount
    {
        private Guid accountID;
        private int balance; // int jus to keep it simple
        private string owner = "";
        private AccountTypes accountType;
        private const int INDIVIDUAL_LIMIT = 500;
        public Account(int _balance, string _owner, AccountTypes _accountType) {
            accountID = Guid.NewGuid();
            balance = _balance;
            owner = _owner;
            accountType = _accountType;
        }
        public int GetBalance() {
            return balance;
        }
        public void Withdraw(int withdrawAmount) {

            if (withdrawAmount > 0 && (accountType != AccountTypes.IndividualInvestment || withdrawAmount <= INDIVIDUAL_LIMIT))
                balance -= withdrawAmount;
            else
                throw new ArgumentOutOfRangeException("withdrawAmount");
        }
        public void Deposit(int depositAmount) {
            balance += depositAmount;
        }
        // Do transfers have the same constraints as withdraws for Individual Investment types?
        public void Transfer(int transferAmount, Account targetAccount) {
            Withdraw(transferAmount);
            targetAccount.Deposit(transferAmount);
        }
    }
}
