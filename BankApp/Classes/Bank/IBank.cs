using System;
using BankApp.Classes.Account;

namespace BankApp.Classes.Bank
{
    public interface IBank
    {
        public void AddAccount(Guid accountId, IAccount account);
        public void DeleteAccount(Guid accountId);
    }
}
