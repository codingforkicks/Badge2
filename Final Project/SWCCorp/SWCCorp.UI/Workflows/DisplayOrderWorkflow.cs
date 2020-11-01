using SWCCorp.BLL;
using SWCCorp.Models.Responses;
using SWCCorp.BLL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Order Lookup By Date");
            Console.Write("Enter order date: ");

            string date = Console.ReadLine();
            DataValidation isValid = new DataValidation();
            date = isValid.checkDate(date);

            OrderResponse response = manager.LookupOrder(date);

            if(response.Success)
            {
                ConsoleIO.DisplayOrders(response.Orders, date);
            }
            else
            {
                Console.WriteLine("An error occured!");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
