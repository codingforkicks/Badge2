using SWCCorp.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*************************************************************************\n" +
                    "* Flooring Program\n" +
                    "*\n" +
                    "* 1. Display Orders\n" +
                    "* 2. Add an Order\n" +
                    "* 3. Edit an Order\n" +
                    "* 4. Remove an Order\n" +
                    "* 5. Quit\n" +
                    "*\n" +
                    "*************************************************************************\n");
                Console.Write("Enter selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute(userInput);
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute(userInput);
                        break;
                    case "4":
                        break;
                    case "5":
                        return;
                }
            }
        }
    }
}
