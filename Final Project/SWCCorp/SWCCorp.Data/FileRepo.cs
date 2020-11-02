using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SWCCorp.Data
{
    
    public class FileRepo : IOrderRepo
    {
        const string directory = @"..\..\..\SWCCorp.Data\SampleData";
        const string filePath = @"\Orders_";
        const string extention = ".txt";

        public static List<Order> _orderList(string fileDate)
        {
            string newPath = directory + filePath + fileDate + extention;
            //open the data path if it exists.  
            //If not, exit
            if (!File.Exists(newPath))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                return null;
            }

            //create list to hold orders
            List<Order> orders = new List<Order>();

            //read data from file
            string[] rows = File.ReadAllLines(newPath);
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Order o = new Order {
                    OrderNumber = int.Parse(columns[0]),
                    CustomerName = columns[1],
                    State = columns[2],
                    TaxRate = Convert.ToDecimal(columns[3]),
                    ProductType = columns[4],
                    Area = Convert.ToDecimal(columns[5]),
                    CostPerSquareFoot = Convert.ToDecimal(columns[6]),
                    LaborCostPerSquareFoot = Convert.ToDecimal(columns[7]),
                };
                orders.Add(o);
            }
            return orders;
        }

        //returns end of filepath string
        public string formatDate(string date)
        {
            string[] dateValues = date.Split('/');
            string dateString = null;
            if (dateValues[0].Length < 2)
            {
                dateString = "0" + dateValues[0];
            }
            else
            {
                dateString = dateValues[0];
            }
            if (dateValues[1].Length < 2)
            {
                dateString = dateString + "0" + dateValues[1];
            }
            else
            {
                dateString = dateString + dateValues[1];
            }

            return dateString + dateValues[2];
        }

        public List <Order> DisplayOrders(string date)
        {
            date = formatDate(date);
            List<Order> orderlist = _orderList(date);
            if(orderlist == null)
            {
                return null;
            }
            return orderlist;
        }

        public void AddOrder(Order order, string date)
        {
            string formattedDate = formatDate(date);
            string newPath = directory + filePath + formattedDate + extention;

            //open the data path if it exists.  
            //If not, create it and fill with order details.
            if (!File.Exists(newPath))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.AppendAllText(newPath,$"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total\n{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate:0.00},{order.ProductType},{order.Area:0.00},{order.CostPerSquareFoot:0.00},{order.LaborCostPerSquareFoot:0.00},{order.MaterialCost:0.00},{order.LaborCost:0.00},{order.Tax:0.00},{order.Total:0.00}");
            }

            //if the file does exist copy the current data and add the new order
            //append new text to file
            else if (File.Exists(newPath))
            {
                List<Order> currentOrders = DisplayOrders(date);

                File.AppendAllText(newPath, $"\n{currentOrders.Count + 1},{order.CustomerName},{order.State},{order.TaxRate:0.00},{order.ProductType},{order.Area:0.00},{order.CostPerSquareFoot:0.00},{order.LaborCostPerSquareFoot:0.00},{order.MaterialCost:0.00},{order.LaborCost:0.00},{order.Tax:0.00},{order.Total:0.00}");
            }
        }

        //create string for textfile change
        static string DataForTextFile(Order order)
        {
            string textString = $"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate:0.00},{order.ProductType},{order.Area:0.00},{order.CostPerSquareFoot:0.00},{order.LaborCostPerSquareFoot:0.00},{order.MaterialCost:0.00},{order.LaborCost:0.00},{order.Tax:0.00},{order.Total:0.00}";

            return textString;
        }

        //edit text file line
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public void EditOrder(Order newOrder, string date)
        {
            string formattedDate = formatDate(date);
            string newPath = directory + filePath + formattedDate + extention;
            string copyPath = directory + filePath + "copy" + extention;

            if (File.Exists(newPath))
            {
                File.Copy(newPath, copyPath);

                List<Order> currentOrders = DisplayOrders(date);

                //update text file to reflect change
                string[] rows = File.ReadAllLines(copyPath);
                
                foreach (Order order in currentOrders)
                {
                    string[] columns = rows[order.OrderNumber].Split(',');
                    if (Convert.ToInt32(columns[0]) == newOrder.OrderNumber)
                    {
                        string newText = DataForTextFile(newOrder);
                        lineChanger(newText, newPath, newOrder.OrderNumber);
                    };
                }
                File.Delete(copyPath);
            }
        }

        public void RemoveOrder(Order order, string date)
        {
            string formattedDate = formatDate(date);
            string newPath = directory + filePath + formattedDate + extention;
            string copyPath = directory + filePath + "copy" + extention;

            if (File.Exists(newPath))
            {
                File.Copy(newPath, copyPath);

                List<Order> currentOrders = DisplayOrders(date);

                //remove the suggested order
                string[] rows = File.ReadAllLines(copyPath);

                foreach (Order o in currentOrders)
                {
                    string[] columns = rows[order.OrderNumber].Split(',');
                    if (Convert.ToInt32(columns[0]) == o.OrderNumber)
                    {
                        currentOrders.RemoveAt(o.OrderNumber);
                    }
                }

                //recreate file
                File.Create(newPath).Close();
                File.AppendAllText(newPath, $"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (Order newOrder in currentOrders)
                {
                    File.AppendAllText(newPath, $"\n{newOrder.OrderNumber},{newOrder.CustomerName},{newOrder.State},{newOrder.TaxRate:0.00},{newOrder.ProductType},{newOrder.Area:0.00},{newOrder.CostPerSquareFoot:0.00},{newOrder.LaborCostPerSquareFoot:0.00},{newOrder.MaterialCost:0.00},{newOrder.LaborCost:0.00},{newOrder.Tax:0.00},{newOrder.Total:0.00}");
                }
                File.Delete(copyPath);
            }
        }

        public void SaveOrder(Order order, string date, string prompt)
        {
            switch (prompt)
            {
                case "2":
                    AddOrder(order, date);
                    break;
                case "3":
                    EditOrder(order, date);
                    break;
                case "4":
                    RemoveOrder(order, date);
                    break;
                default:
                    break;
            }
        }
    }
}