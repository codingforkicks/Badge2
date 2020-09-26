using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Responses;
using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);

            AccountLookupResponse response2 = manager.LookupAccount("345");

            Assert.IsNull(response2.Account);
            Assert.IsFalse(response2.Success);
        }

        [Test]
        public void CanLoadAccount()
        {
            FreeAccountTestRepository testRepository = new FreeAccountTestRepository();

            Assert.AreEqual("12345", testRepository.LoadAccount("12345").AccountNumber);
            Assert.AreEqual(null, testRepository.LoadAccount("14"));
        }
    }
}
