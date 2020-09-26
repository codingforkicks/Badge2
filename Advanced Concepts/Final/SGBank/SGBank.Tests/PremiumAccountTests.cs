using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Responses;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("123", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("123", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("123", "Premium Account", 100, AccountType.Premium, 1050, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account testAccount = new Account
            {
                Name = name,
                Balance = balance,
                AccountNumber = accountNumber,
                Type = accountType
            };

            AccountDepositResponse response = new AccountDepositResponse();
            response = deposit.Deposit(testAccount, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
