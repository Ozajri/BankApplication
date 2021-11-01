using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Classes.Account;

namespace BankTests
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        public void Account_WithdrawAmount_CheckBalanceReflectsWithdrawal()
        {
            // Arrange
            int initialBalance = 1000;
            string owner = "Name";
            AccountTypes accountType = AccountTypes.Checking;
            int withdrawAmount = 250;
            int expectedBalance = initialBalance - withdrawAmount;

            Account account = new Account(initialBalance, owner, accountType);

            // Act
            account.Withdraw(withdrawAmount);

            // Assert
            int actualBalance = account.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance, "Withdraw Success");
        }
        [TestMethod]
        public void Account_DepositAmount_CheckBalanceReflectsDeposit()
        {
            // Arrange
            int initialBalance = 1000;
            string owner = "Name";
            AccountTypes accountType = AccountTypes.Checking;
            int depositAmount = 250;
            int expectedBalance = initialBalance + depositAmount;

            Account account = new Account(initialBalance, owner, accountType);

            // Act
            account.Deposit(depositAmount);

            // Assert
            int actualBalance = account.GetBalance();
            Assert.AreEqual(expectedBalance, actualBalance, "Withdraw Success");
        }
        [TestMethod]
        public void Account_TransferAmount_CheckBalancesReflectTransfer()
        {
            // Arrange
            int transferAmount = 250;
            int initialBalanceFrom = 1000;
            string ownerFrom = "Name";
            AccountTypes accountTypeFrom = AccountTypes.Checking;
            int expectedBalanceFrom = initialBalanceFrom - transferAmount;
            int initialBalanceTo = 1000;
            string ownerTo = "Name";
            AccountTypes accountTypeTo = AccountTypes.Checking;
            int expectedBalanceTo = initialBalanceTo + transferAmount;

            Account accountFrom = new Account(initialBalanceFrom, ownerFrom, accountTypeFrom);
            Account accountTo = new Account(initialBalanceTo, ownerTo, accountTypeTo);

            // Act
            accountFrom.Transfer(transferAmount, accountTo);

            // Assert
            int actualBalanceFrom = accountFrom.GetBalance();
            int actualBalanceTo = accountTo.GetBalance();
            Assert.AreEqual(expectedBalanceFrom, actualBalanceFrom, "Transfer From Success");
            Assert.AreEqual(expectedBalanceTo, actualBalanceTo, "Transfer To Success");
        }
        [TestMethod]
        public void Account_WithdrawLessThan0_ThrowArgumentOutOfRange()
        {
            // Arrange
            int initialBalance = 1000;
            string owner = "Name";
            AccountTypes accountType = AccountTypes.Checking;
            int withdrawAmount = -1;

            Account account = new Account(initialBalance, owner, accountType);

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Withdraw(withdrawAmount));
        }
        [TestMethod]
        public void Account_WithdrawGreaterThan500_ThrowArgumentOutOfRangeForIndividualInvestment()
        {
            // Arrange
            int initialBalance = 1000;
            string owner = "Name";
            AccountTypes accountType = AccountTypes.IndividualInvestment;
            int withdrawAmount = 501;

            Account account = new Account(initialBalance, owner, accountType);

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Withdraw(withdrawAmount));
        }
    }
}
