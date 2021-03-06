﻿using SWCCorp.BLL;
using SWCCorp.Models;
using SWCCorp.Models.Responses;
using SWCCorp.BLL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SWCCorp.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute(string prompt)
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Add Order");
            Console.Write("Enter order date: ");

            //grab user input and validate
            string date = Console.ReadLine();
            DataValidation isValid = new DataValidation();
            date = isValid.checkDateTime(date);

            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            name = isValid.checkName(name);

            Console.Write("Enter state: ");
            string state = Console.ReadLine();
            Tax tax = isValid.checkState(state);

            Products productType = isValid.checkProductSelection();

            Console.Write("Enter Area: ");
            string area = Console.ReadLine();
            decimal validArea = isValid.checkArea(area);

            //create order
            Order order = new Order {
                OrderNumber = 1,
                CustomerName = name,
                State = tax.StateAbbreviation,
                ProductType = productType.ProductType,
                Area = validArea,
                CostPerSquareFoot = productType.CostPerSquareFoot,
                LaborCostPerSquareFoot = productType.LaborCostPerSquareFoot,
                TaxRate = tax.TaxRate
            };

            //display order to user
            Console.Clear();
            Console.WriteLine("Add Order\n");

            ConsoleIO.DisplayPendingOrder(order, date);

            Console.Write("Would you like to add the current order? (y/n): ");
            string userInput = Console.ReadLine().Trim();
            userInput = userInput.ToLower();

            while (userInput != "y" && userInput != "yes" && userInput != "n" && userInput != "no")
            {
                Console.Clear();
                Console.WriteLine("Add Order\n");

                ConsoleIO.DisplayPendingOrder(order, date);

                Console.Write("Error: Invalid response\n" +
                    "Would you like to add the current order? (y/n): ");
                userInput = Console.ReadLine().Trim();
                userInput = userInput.ToLower();
            }

            if(userInput == "y" || userInput == "yes")
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
