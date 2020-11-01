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
                $"Materials: {orders.MaterialCost:C2}\n" +
                $"Labor: {orders.LaborCost:C2}\n" +
                $"Tax: {orders.Tax:C2}\n" +
                $"Total: {orders.Total:C2}\n" +
                 "*************************************************************************");
        }
    }
}