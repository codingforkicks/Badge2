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
        public static void DisplayOrders(List <Order> orders, string date)
        {
            foreach(Order order in orders)
            {
                Console.WriteLine("*************************************************************************\n" +
                    $"{order.OrderNumber} | {date}\n" +
                    $"{order.CustomerName}\n" +
                    $"{order.State}\n" +
                    $"Product: {order.ProductType}\n" +
                    $"Materials: {order.MaterialCost:C2}\n" +
                    $"Labor: {order.LaborCost:C2}\n" +
                    $"Tax: {order.Tax:C2}\n" +
                    $"Total: {order.Total:C2}\n" +
                        "*************************************************************************");
            }
        }

        public static void DisplayPendingOrder(Order order, string date)
        {
            Console.WriteLine("*************************************************************************\n" +
                    $"Pending Order | {date}\n" +
                    $"{order.CustomerName}\n" +
                    $"{order.State}\n" +
                    $"Product: {order.ProductType}\n" +
                    $"Materials: {order.MaterialCost:C2}\n" +
                    $"Labor: {order.LaborCost:C2}\n" +
                    $"Tax: {order.Tax:C2}\n" +
                    $"Total: {order.Total:C2}\n" +
                        "*************************************************************************");
        }

        public static void DisplaySingleOrder(Order order, string date)
        {
            Console.WriteLine("*************************************************************************\n" +
                    $"{order.OrderNumber} | {date}\n" +
                    $"{order.CustomerName}\n" +
                    $"{order.State}\n" +
                    $"Product: {order.ProductType}\n" +
                    $"Materials: {order.MaterialCost:C2}\n" +
                    $"Labor: {order.LaborCost:C2}\n" +
                    $"Tax: {order.Tax:C2}\n" +
                    $"Total: {order.Total:C2}\n" +
                        "*************************************************************************");
        }
    }
}