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

        public void SaveOrder(Order order, string date, string prompt)
        {
            switch (prompt)
            {
                case "2":
                    AddOrder(order, date);
                    break;
                default:
                    break;
            }
        }
    }
}