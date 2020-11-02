using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCCorp.Data;
using SWCCorp.Models;

namespace SWCCorp.BLL.Validation
{
    public class DataValidation
    {
        public string checkDate(string date)
        {
            while (true)
            {
                bool isValid = DateTime.TryParse(date, out DateTime validDate);

                if (isValid)
                {
                    return validDate.ToShortDateString();
                } else
                {
                    Console.Clear();
                    Console.WriteLine($"{date} is not a valid date! Please try again.\n");
                    Console.Write("Enter date: ");
                    date = Console.ReadLine();
                }
            }
        }

        public string checkDateTime(string date)
        {
            while (true)
            {
                date = checkDate(date);
                DateTime datetime = DateTime.Parse(date);
                if (datetime >= DateTime.Today)
                {
                    return date;
                }
                Console.WriteLine("\nError: date must be in the future.");
                Console.Write("Enter date: ");
                date = Console.ReadLine();
            }
        }

        public string checkNameChange(string name)
        {
            name = name.Trim();
            while (true)
            {
                if (name.Length < 1)
                {
                    Console.WriteLine("\nError: Name cannot be blank");
                    Console.Write("Enter Customer Name: ");
                    name = Console.ReadLine();
                }
                else if (name.Length < 3)
                {
                    Console.WriteLine("\nError: Name must contain at least 3 characters");
                    Console.Write("Enter Customer Name: ");
                    name = Console.ReadLine();
                }
                else
                {
                    return name;
                }
            }
        }

        public Tax checkState(string state)
        {
           state = state.Trim();

            while (true)
            {
                if(state.Length != 2)
                {
                    Console.WriteLine("\nError: Please use state abbreviation");
                    Console.Write("Enter State: ");
                    state = Console.ReadLine();
                } else
                {
                    TaxRepo stateRepo = new TaxRepo();
                    List<Tax> taxes = stateRepo.LoadTaxRepo();

                    foreach(Tax tax in taxes)
                    {
                        if(tax.StateAbbreviation.ToUpper() == state.ToUpper())
                        {
                            return tax;
                        }
                    }

                    Console.WriteLine($"\nError: State {state} not serviced");
                    Console.Write("Enter State: ");
                    state = Console.ReadLine();
                }
            }
        }
        public Products checkProductSelection()
        {
            ProductRepo productRepo = new ProductRepo();
            List<Products> products = productRepo.LoadProductTypes();

            Console.WriteLine("\nProduct List: ");
            foreach(Products p in products)
            {
                Console.WriteLine($"Type: {p.ProductType}\n" +
                    $"Cost Per Square Foot {p.CostPerSquareFoot}\n" +
                    $"Labor Cost Per Square Foot {p.LaborCostPerSquareFoot}\n");
            }

            Console.Write("Enter product type name: ");
            string productType = Console.ReadLine();

            bool isValid = Char.IsLetter(productType[0]);

            while (true)
            {
                if (!isValid)
                {
                    Console.WriteLine($"\nError: Product Type must start with letter");
                    Console.Write("Enter Product Type: ");
                    productType = Console.ReadLine();
                    isValid = Char.IsLetter(productType[0]);
                }
                foreach (Products p in products)
                {
                    if(p.ProductType.ToLower() == productType.ToLower())
                    {
                        return p;
                    }
                }
                Console.WriteLine($"\nError: Invalid product type");
                Console.Write("Enter Product Type: ");
                productType = Console.ReadLine();
            }
        }

        public decimal checkArea(string area)
        {
            while (true)
            {
                if (decimal.TryParse(area, out decimal result))
                {
                    if(result >= 100)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"\nError: Invalid Area Size");
                        Console.Write("Enter area size 100 or greater : ");
                        area = Console.ReadLine();
                    }
                } else
                {
                    Console.WriteLine($"Error: Invalid Area Input");
                    Console.Write("Enter area as positive interger: ");
                    area = Console.ReadLine();
                }
            }
        }

    }
}
