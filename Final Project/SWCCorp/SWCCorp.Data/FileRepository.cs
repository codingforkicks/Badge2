using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace SWCCorp.Data
{
    
    public class FileRepository : IOrderRepository
    {
        const string directory = @"..\..\..\SWCCorp.Data\SampleData";
        const string filePath = @"..\..\..\SWCCorp.Data\SampleData\Orders_";
        const string extention = ".txt";

        public static List<Order> _orderList(string fileDate)
        {
            string newPath = filePath + fileDate + extention;

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
            if (dateValues[0].Length < 2)
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
        public void SaveOrder(Order order)
        {
            
        }
    }
}
*/