using System;
using System.Collections.Generic;
using BankApp.Classes.Account;

namespace BankApp.Classes.Bank
{
    
    public class Bank : IBank
    {
        private string name;
        private Dictionary<Guid, IAccount> accounts;    // Could do an in-memory database but seemed simpler here

        public Bank(string _name) {
            name = _name;
            accounts = new Dictionary<Guid, IAccount>();
        }
        public void AddAccount(Guid accountId, IAccount account) {
            accounts.Add(accountId, account);
        }
        public void DeleteAccount(Guid accountId)
        {
            accounts.Remove(accountId);
        }
    }
}
