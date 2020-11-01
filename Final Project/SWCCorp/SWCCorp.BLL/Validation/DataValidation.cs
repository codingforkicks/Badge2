using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
