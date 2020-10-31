using SWCCorp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrders(Order orders, string date)
        {
            Console.WriteLine("*************************************************************************\n" +
                $"{orders.OrderNumber} | {date}\n" +
                $"{orders.CustomerName}\n" +
                $"{orders.State}\n" +
                $"Product: {orders.ProductType}\n" +
                $"Materials: {orders.MaterialCost}\n" +
                $"Labor: {orders.LaborCost}\n" +
                $"Tax: {orders.Tax}\n" +
                $"Total: {orders.Total}\n" +
                 "*************************************************************************");
        }
    }
}
