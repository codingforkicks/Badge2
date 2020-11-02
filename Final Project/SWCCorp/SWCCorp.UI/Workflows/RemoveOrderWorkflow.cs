using SWCCorp.BLL;
using SWCCorp.BLL.Validation;
using SWCCorp.Models;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute(string prompt)
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.Write("Enter order date: ");

            //grab user input and validate
            string date = Console.ReadLine();
            DataValidation isValid = new DataValidation();
            date = isValid.checkDate(date);

            Console.Write("Enter order number: ");
            string orderNumber = Console.ReadLine();
            Order order = isValid.checkOrderNumber(orderNumber, date);

            while (order == null)
            {
                Console.Clear();
                Console.WriteLine("Remove Order");
                Console.WriteLine($"\nError: No file found with date {date} and order number {orderNumber}");

                Console.Write("Enter order date: ");
                date = Console.ReadLine();
                date = isValid.checkDateTime(date);

                Console.Write("Enter order number: ");
                orderNumber = Console.ReadLine();
                order = isValid.checkOrderNumber(orderNumber, date);
            }

            Console.Clear();
            Console.WriteLine("Remove Order\n");
            ConsoleIO.DisplaySingleOrder(order, date);

            Console.Write("Would you like to remove the current order? (y/n): ");
            string userInput = Console.ReadLine().Trim();
            userInput = userInput.ToLower();

            while (userInput != "y" && userInput != "yes" && userInput != "n" && userInput != "no")
            {
                Console.Clear();
                Console.WriteLine("Remove Order\n");

                ConsoleIO.DisplaySingleOrder(order, date);

                Console.Write("Error: Invalid response\n" +
                    "Would you like to remove the current order? (y/n): ");
                userInput = Console.ReadLine().Trim();
                userInput = userInput.ToLower();
            }

            if (userInput == "y" || userInput == "yes")
            {
                Console.Clear();
                //pass order
                ModifyResponse response = manager.Modify(order, date, prompt);

                if (response.Success)
                {
                    ConsoleIO.DisplaySingleOrder(order, date);
                }
                else
                {
                    Console.WriteLine("An error occured!");
                    Console.WriteLine(response.Message);
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
