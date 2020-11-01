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
                        DisplayOrderWorkflow workflow = new DisplayOrderWorkflow();
                        workflow.Execute();
                        break;
                    case "2":
                        break;
                    case "3":
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
