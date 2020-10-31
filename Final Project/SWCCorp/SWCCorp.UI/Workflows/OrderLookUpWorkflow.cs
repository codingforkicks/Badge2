using SWCCorp.BLL;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.UI.Workflows
{
    public class OrderLookUpWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Order Lookup By Date");
            Console.Write("Enter order date: ");

            string date = Console.ReadLine();

            OrderLookUpResponse response = manager.LookupOrder(date);

            if(response.Success)
            {
                ConsoleIO.DisplayOrders(response.Order, date);
            }
            else
            {
                Console.WriteLine("An error occured.");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
