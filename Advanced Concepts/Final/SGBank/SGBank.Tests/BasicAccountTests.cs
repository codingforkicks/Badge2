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
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account testAccount = new Account
            {
                Name = name,
                Balance = balance,
                AccountNumber = accountNumber,
                Type = accountType
            };

            Console.WriteLine(testAccount.Type);
            Console.WriteLine(testAccount.AccountNumber);

            AccountDepositResponse response = new AccountDepositResponse();
            response = deposit.Deposit(testAccount, amount);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.Success);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
