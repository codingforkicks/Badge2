using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Data
{
    public class TaxRepo : ITaxRepo
    {
        const string directory = @"..\..\..\SWCCorp.Data\SampleData";
        const string filePath = @"\Taxes.txt";
        public List<Tax> LoadTaxRepo()
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
            List<Tax> taxes = new List<Tax>();

            //read data from file
            string[] rows = File.ReadAllLines(newPath);
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Tax t = new Tax
                {
                    StateAbbreviation = columns[0],
                    StateName = columns[1],
                    TaxRate = Convert.ToDecimal(columns[2])
                };
                taxes.Add(t);
            }
            return taxes;
        }
    }
}
