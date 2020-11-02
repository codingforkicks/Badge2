using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class OrderTestRepo : IOrderRepo
    {
        public List<Order> _orderlist = new List<Order> {
            new Order
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
                Total = 1051.88 */
            },
            new Order
            {
                //2,Grant,IN,6.25,Tile,100.00,5.15,4.75
                OrderNumber = 2,
                CustomerName = "Grant",
                State = "IN",
                TaxRate = 6.25M,
                ProductType = "Tile",
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
                /* MaterialCost = 515.00
                LaborCost = 475.00
                Tax = 61.88
                Total = 1051.88 */
            }

        };

        public List <Order> DisplayOrders(string date)
        {
            return _orderlist;
        }

        public void SaveOrder(Order order, string date)
        {
            List<Order> orders = new List<Order>();
            orders.Add(order);
            _orderlist = orders;
        }

    }
}
