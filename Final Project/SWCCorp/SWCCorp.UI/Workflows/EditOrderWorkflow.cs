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
    public class EditOrderWorkflow
    {
        public void Execute(string prompt)
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.Write("Enter order date: ");

            //grab user input and validate
            string date = Console.ReadLine();
            DataValidation isValid = new DataValidation();
            date = isValid.checkDate(date);

            Console.Write("Enter order number: ");
            string orderNumber = Console.ReadLine();
            Order order = isValid.checkOrderNumber(orderNumber, date);

            while(order == null)
            {
                Console.Clear();
                Console.WriteLine("Edit Order");
                Console.WriteLine($"\nError: No file found with date {date} and order number {orderNumber}");

                Console.Write("Enter order date: ");
                date = Console.ReadLine();
                date = isValid.checkDateTime(date);

                Console.Write("Enter order number: ");
                orderNumber = Console.ReadLine();
                order = isValid.checkOrderNumber(orderNumber, date);
            }

            Console.Clear();
            Console.WriteLine("Edit Order\n");
            ConsoleIO.DisplaySingleOrder(order, date);

            Console.Write("Would you like to edit the current order? (y/n): ");
            string userInput = Console.ReadLine().Trim();
            userInput = userInput.ToLower();

            while (userInput != "y" && userInput != "yes" && userInput != "n" && userInput != "no")
            {
                Console.Clear();
                Console.WriteLine("Edit Order\n");

                ConsoleIO.DisplaySingleOrder(order, date);

                Console.Write("Error: Invalid response\n" +
                    "Would you like to add the current order? (y/n): ");
                userInput = Console.ReadLine().Trim();
                userInput = userInput.ToLower();
            }

            if (userInput == "y" || userInput == "yes")
            {
                //get changes
                Console.Write("Enter new customer name or press enter to skip: ");
                string name = Console.ReadLine();
                name = isValid.checkNameChange(order, name);

                Console.Write("Enter new state or press enter to skip: ");
                string state = Console.ReadLine();
                Tax tax = isValid.checkStateChange(state);

                Products productType = isValid.checkProductSelection(state);

                Console.Write("Enter Area or press enter to skip: ");
                string area = Console.ReadLine();
                decimal validArea = isValid.checkAreaChange(area);

                Order changedOrder = new Order
                {
                    OrderNumber = order.OrderNumber,
                    CustomerName = name != null ? name : order.CustomerName,
                    State = tax != null ? tax.StateAbbreviation : order.State,
                    TaxRate = tax != null ? tax.TaxRate : order.TaxRate,
                    ProductType = productType != null ? productType.ProductType : order.ProductType,
                    Area = validArea > 0 ? validArea : order.Area,
                    CostPerSquareFoot = productType != null ? productType.CostPerSquareFoot : order.CostPerSquareFoot,
                    LaborCostPerSquareFoot = productType != null ? productType.LaborCostPerSquareFoot : order.LaborCostPerSquareFoot,
                };

                Console.WriteLine("Current Order: ");
                ConsoleIO.DisplaySingleOrder(order, date);
                Console.WriteLine("Suggested Changes: ");
                ConsoleIO.DisplaySingleOrder(changedOrder, date);

                Console.Write("Would you like to save these changes? (y/n): ");
                userInput = Console.ReadLine().Trim();
                userInput = userInput.ToLower();

                while (userInput != "y" && userInput != "yes" && userInput != "n" && userInput != "no")
                {
                    Console.Write("Error: Invalid response\n" +
                        "Would you like to save these changes? (y/n): ");
                    userInput = Console.ReadLine().Trim();
                    userInput = userInput.ToLower();
                }

                if (userInput == "y" || userInput == "yes")
                {
                    Console.Clear();
                    //pass order
                    ModifyResponse response = manager.Modify(changedOrder, date, prompt);

                    if (response.Success)
                    {
                        ConsoleIO.DisplaySingleOrder(changedOrder, date);
                    }
                    else
                    {
                        Console.WriteLine("An error occured!");
                        Console.WriteLine(response.Message);
                    }
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
