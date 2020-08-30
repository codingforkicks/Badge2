using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //load products and customers
            List<Product> products = DataLoader.LoadProducts();
            List<Customer> customers = DataLoader.LoadCustomers();

            //PrintAllProducts();
            //Console.WriteLine("\n");
            //PrintAllCustomers();
            //Console.WriteLine("\n");

            //First 10 Exercises
            //PrintAllOutOfStockProducts(products);
            //ProductsOver3Dollars(products);
            //WACustomers(customers);
            //AnonymousTypeProductName(products);
            //UnitPriceUp25(products);
            //NameAndCategoryToUpperCase(products);
            //ReorderFlag(products);
            //StockValue(products);
            //NumbersAEvens();
            //CustomerTotalLessThan500(customers);

            //Second 10 Exercises
            //NumberCFirstThreeOdd();
            //NumberBSkipFirstThree();
            //WARecentOrderByCompany(customers);
            //NumberCUntilGreaterThan5();
            //NumberCFirstAfterDivideBy3();
            //AlphabeticalProducts(products);
            //ProductsDescendingByUnitsInStock(products);
            //ProductsFilteredByCategoryAndUnitPrice(products);
            //NumberBReversed();
            //GroupCategoryPrintByCategoryName(products);

            //Last Exercises
            //CustomerOrdersByYearThenMonth(customers);
            //ProductCategories(products);
            //Product789Check(products);
            //OutOfStockCategories(products);
            //InStockCategories(products);
            //NumbersANumOfOdds();
            //CustomerCountByOrder(customers);
            //ProductCountByCategory(products);
            //TotalUnitsInStockByCategory(products);
            //LowestPricedProductByCategory(products);
            //TopThreeCategoriesByAvgUnitPrice(products);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");
            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void PrintAllOutOfStockProducts(IEnumerable<Product> products)
        {
            //method syntax
            var outOfStock = products.Where(p => p.UnitsInStock < 1);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOut of stock: ");
            Console.ResetColor();
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void ProductsOver3Dollars(IEnumerable<Product> products)
        {
            //query syntax
            var productsOverThreeDollars = from item in products
                                       where item.UnitsInStock > 0 && item.UnitPrice > 3
                                       select item;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nMore than $3.00: ");
            Console.ResetColor();
            PrintProductInformation(productsOverThreeDollars);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void WACustomers(IEnumerable<Customer> customers)
        {
            //method syntax
            var WaCustomers = customers.Where(c => c.Region == "WA");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWA Customers: ");
            Console.ResetColor();
            PrintCustomerInformation(WaCustomers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void AnonymousTypeProductName(IEnumerable<Product> products)
        {
            //query syntax
            var productName = from p in products
                              where p.ProductName != null
                              select new { name = p.ProductName };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAnonymous Product Names: ");
            Console.ResetColor();

            foreach (var p in productName)
            {
                Console.WriteLine(p.name);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void UnitPriceUp25(IEnumerable<Product> products)
        {
            decimal increaseAmount = (decimal).25;
            var productsPlus25 = from p in products
                            where p.ProductName != null
                            select new
                            {
                                ProductID = p.ProductID,
                                ProductName = p.ProductName,
                                Category = p.Category,
                                UnitPrice = (p.UnitPrice * increaseAmount) + p.UnitPrice,
                                UnitsInStock = p.UnitsInStock
                            };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nIncrease Product Price by 25%: ");
            Console.ResetColor();
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");
            foreach (var product in productsPlus25)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void NameAndCategoryToUpperCase(IEnumerable<Product> products)
        {
            var productsToUppercase = from p in products
                                 where p.ProductName != null
                                 select new
                                 {
                                     ProductName = p.ProductName.ToUpper(),
                                     Category = p.Category.ToUpper(),
                                 };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nName and Category To UpperCase: ");
            Console.ResetColor();
            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");
            foreach (var product in productsToUppercase)
            {
                Console.WriteLine(line, product.ProductName, product.Category);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void ReorderFlag(IEnumerable<Product> products)
        {
            var productList = from p in products
                                 where p.ProductName != null
                                 select new
                                 {
                                     ProductID = p.ProductID,
                                     ProductName = p.ProductName,
                                     Category = p.Category,
                                     UnitPrice = p.UnitPrice,
                                     UnitsInStock = p.UnitsInStock,
                                     ReOrder = p.UnitsInStock < 3 ? true : false,
                                 };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nReOrder Flag: ");
            Console.ResetColor();
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,5}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("==============================================================================");
            foreach (var product in productList)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void StockValue(IEnumerable<Product> products)
        {
            var productList = from p in products
                              where p.ProductName != null
                              select new
                              {
                                  ProductID = p.ProductID,
                                  ProductName = p.ProductName,
                                  Category = p.Category,
                                  UnitPrice = p.UnitPrice,
                                  UnitsInStock = p.UnitsInStock,
                                  StockValue = p.UnitPrice * p.UnitsInStock,
                              };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nStock Value: ");
            Console.ResetColor();
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,13:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "StockValue");
            Console.WriteLine("=====================================================================================");
            foreach (var product in productList)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void NumbersAEvens()
        {
            var evens = DataLoader.NumbersA.Where(n => n % 2 == 0);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNumberA Evens: ");
            Console.ResetColor();
            foreach (var num in evens)
            {
                Console.Write($"{num} ");
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void CustomerTotalLessThan500(IEnumerable<Customer> customers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nOrders under $500: ");
            Console.ResetColor();

            var customerList = customers.Where(c => c.Orders.Length > 0 && c.Orders[0].Total < 500);

            foreach (var customer in customerList)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void NumberCFirstThreeOdd()
        {
            var odds = DataLoader.NumbersC.Where(n => n % 2 != 0);
            var topThree = odds.Take(3);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNumberC First Three Odd Numbers: ");
            Console.ResetColor();
            foreach(var item in topThree)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void NumberBSkipFirstThree()
        {
            var skipFirstThree = DataLoader.NumbersB.Skip(3);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNumberC First Three Odd Numbers: ");
            Console.ResetColor();
            foreach (var item in skipFirstThree)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void WARecentOrderByCompany(IEnumerable<Customer> customers)
        {
            var customerList = customers.Where(c => c.Region == "WA" && c.Orders.Length > 0);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWA Most Recent Order By Company: ");
            Console.ResetColor();

            foreach (var customer in customerList)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders.Reverse().Take(1))
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void NumberCUntilGreaterThan5()
        {
            var NumberCLessThan6 = DataLoader.NumbersC.TakeWhile(n => n <= 6);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNumberC Until Number >= 6: ");
            Console.ResetColor();
            foreach (var item in NumberCLessThan6)
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void NumberCFirstAfterDivideBy3()
        {
            var firstNum = DataLoader.NumbersC.Where(n => n % 3 == 0).Take(1);
            var index = firstNum.ElementAt(0);
            var numQuery = DataLoader.NumbersC.Skip(index + 1);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNumberC First After Divide By 3: ");
            Console.ResetColor();
            foreach (var num in numQuery)
            {
                Console.Write($"{num} ");
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void AlphabeticalProducts(IEnumerable<Product> products)
        {
            var alphabetical = products.OrderBy(p => p.ProductName);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProducts Alphabetical by Name: ");
            Console.ResetColor();
            PrintProductInformation(alphabetical);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void ProductsDescendingByUnitsInStock(IEnumerable<Product> products)
        {
            var descByUnitStock = products.OrderByDescending(p => p.UnitsInStock);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProducts Descending By Units In Stock: ");
            Console.ResetColor();
            PrintProductInformation(descByUnitStock);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void ProductsFilteredByCategoryAndUnitPrice(IEnumerable<Product> products)
        {
            var filteredProducts = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProducts Filtered By Category And Unit Price: ");
            Console.ResetColor();
            PrintProductInformation(filteredProducts);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void NumberBReversed()
        {
            var numQuery = DataLoader.NumbersB.Reverse();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nNumberB Reversed: ");
            Console.ResetColor();
            foreach (var num in numQuery)
            {
                Console.Write($"{num} ");
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void GroupCategoryPrintByCategoryName(IEnumerable<Product> products)
        {
            //create ordered list via query
            var productList = from p in products
                              where p.Category != null
                              orderby p.Category
                              select new
                              {
                                  Name = (string)p.ProductName,
                                  Category = (string)p.Category,
                              };

            //grab each individual category
            var categories = productList
                .GroupBy(p => p.Category)
                .Select(p => p.FirstOrDefault());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProducts by category: ");
            Console.ResetColor();

            foreach (var item in categories)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProduct Category {item.Category}: ");
                Console.ResetColor();
                var product = productList.Where(p => p.Category == item.Category);
                foreach (var i in product)
                {
                        Console.WriteLine($"{i.Name}");
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void CustomerOrdersByYearThenMonth(IEnumerable<Customer> customers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCustomer Orders By Year Then Month: ");
            Console.ResetColor();

            var orderList = customers
                .Where(c => c.Orders.Length > 0)
                .OrderBy(c => c.Orders[0].OrderDate.Year)
                .ThenBy(c => c.Orders[0].OrderDate.Month);

            foreach (var customer in orderList)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"{order.OrderDate.Year}");
                    Console.WriteLine("\t{0} {1,20:c}", order.OrderDate.Month, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void ProductCategories(IEnumerable<Product> products)
        {
            var categories = products
                .GroupBy(p => p.Category)
                .Select(p => p.FirstOrDefault());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProducts Categories: ");
            Console.ResetColor();

            foreach(var c in categories)
            {
                Console.WriteLine(c.Category);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Product789Check(IEnumerable<Product> products)
        {
            const int productNum = 789;
            var check = products
                .Any(p => p.ProductID == productNum);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProducts Categories: ");
            Console.ResetColor();

            if (check)
            {
                Console.WriteLine($"item {productNum} exists");
            } else
            {
                Console.WriteLine($"item {productNum} does not exists");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void OutOfStockCategories(IEnumerable<Product> products)
        {
            var outOfStockProducts = products
                .Where(p => p.UnitsInStock < 1)
                .GroupBy(p => p.Category);

            var outOfStockCategories = outOfStockProducts.Select(c => c.FirstOrDefault());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProduct Categories with items out of stock: ");
            Console.ResetColor();

            foreach(var item in outOfStockCategories)
            {
                Console.WriteLine($"{item.Category}");
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void InStockCategories(IEnumerable<Product> products)
        {
            var inStockCategories = products
                .GroupBy(p => p.Category, p => p.UnitsInStock)
                .Where(p => p.All(i => i > 0));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProduct Categories with no items out of stock: ");
            Console.ResetColor();

            foreach (var item in inStockCategories)
            {
                Console.WriteLine($"{item.Key}");
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void NumbersANumOfOdds()
        {
            var numOfOdds = DataLoader.NumbersA.Where(n => n % 2 != 0).Count();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nNumber of Odds in NumberA: {numOfOdds}");
            Console.ResetColor();
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void CustomerCountByOrder(IEnumerable<Customer> customers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCustomerId and the count of their orders: ");
            Console.ResetColor();

            var orderList = customers
                .Where(c => c.Orders.Length > 0)
                .Select(c => new {
                    CompanyName = c.CustomerID,
                    OrderCount = c.Orders.Count()
                });

            foreach (var customer in orderList)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine($"Order Count: {customer.OrderCount}");
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void ProductCountByCategory(IEnumerable<Product> products)
        {
            var listOfCategoriesAndCount = products
                .GroupBy(p => p.Category);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProduct categories and the count of the products they contain: ");
            Console.ResetColor();

            foreach (var item in listOfCategoriesAndCount)
            {
                Console.WriteLine($"{item.Key} \t {item.Count()}");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void TotalUnitsInStockByCategory(IEnumerable<Product> products)
        {
            var categoriesAndUnits = products
                .GroupBy(p => p.Category, p => p.UnitsInStock);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProduct categories and the total units in stock: ");
            Console.ResetColor();

            foreach (var item in categoriesAndUnits)
            {
                Console.WriteLine($"{item.Key} \t {item.Sum():d}");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void LowestPricedProductByCategory(IEnumerable<Product> products)
        {
            var categoriesAndUnitPrice = products
                .GroupBy(p => p.Category, p => p.UnitPrice);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nProduct categories and the lowest priced product in that category: ");
            Console.ResetColor();

            foreach (var item in categoriesAndUnitPrice)
            {
                Console.WriteLine($"{item.Key} \t {item.Min():c}");
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void TopThreeCategoriesByAvgUnitPrice(IEnumerable<Product> products)
        {
            //sort products by category
            //find average of each category
            //take top 3
            var topThreeCategories = products
                .GroupBy(p => p.Category, p => p.UnitPrice)
                .OrderByDescending(p => p.Average())
                .Take(3);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTop 3 categories by the average unit price of their products: ");
            Console.ResetColor();

            foreach (var item in topThreeCategories)
            {
                Console.WriteLine($"{item.Key} \t {item.Average():c}");
            }
        }
    }
}
