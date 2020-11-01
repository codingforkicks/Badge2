using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCCorp.BLL;
using SWCCorp.Models.Responses;

namespace SWCCorp.Tests
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void CanLoadTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderResponse response = manager.LookupOrder("");

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Order.OrderNumber);
        }
    }
}
