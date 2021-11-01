namespace BankApp.Classes.Account
{
    public interface IAccount
    {
        public int GetBalance();
        public void Withdraw(int withdrawAmount);
        public void Deposit(int depositAmount);
        public void Transfer(int transferAmount, Account targetAccount);
    }
}
