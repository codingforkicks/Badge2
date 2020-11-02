using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class ProductRepo : IProductsRepo
    {
        const string directory = @"..\..\..\SWCCorp.Data\SampleData";
        const string filePath = @"\Products.txt";

        public List<Products> LoadProductTypes()
        {
            string newPath = directory + filePath;
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
            List<Products> products = new List<Products>();

            //read data from file
            string[] rows = File.ReadAllLines(newPath);
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Products p = new Products
                {
                    ProductType = columns[0],
                    CostPerSquareFoot = Convert.ToDecimal(columns[1]),
                    LaborCostPerSquareFoot = Convert.ToDecimal(columns[2])
                };
                products.Add(p);
            }
            return products;
        }
    }
}
