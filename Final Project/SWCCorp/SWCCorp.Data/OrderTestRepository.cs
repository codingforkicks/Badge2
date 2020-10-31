using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            //1,Wise,OH,6.25,Wood,100.00,5.15,4.75
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M
            /* MaterialCost = 515.00
            LaborCost = 475.00
            Tax = 61.88
            Total = 1051.88
            */
        };
        public void AddOrder()
        {
            throw new NotImplementedException();
        }

        public Order DisplayOrders(string date)
        {
            return _order;
        }

        public void EditOrder(string date, string OrderNumber)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(string date, string OrderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
