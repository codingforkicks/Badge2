using SGBank.Models;
using SGBank.Models.Responses;
using SGBank.Models.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        const string directory = @"..\..\..\SGBank.Data\Data1";
        const string filePath = @"..\..\..\SGBank.Data\Data1\Account.txt";

        public static List<Account> _accountList()
        {
            //open the data path if it exists.  If not, create it and fill with test data
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                File.Create(filePath).Close();
                
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("AccountNumber,Name,Balance,Type");
                    writer.WriteLine("11111,Free Customer,100,F");
                    writer.WriteLine("22222,Basic Customer,500,B");
                    writer.WriteLine("33333,Premium Customer,1000,P");
                }

                Console.ReadKey();
            }

            //create list to hold accounts
            List<Account> accounts = new List<Account>();

            //read data from file
            string[] rows = File.ReadAllLines(filePath);
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                if(columns[3] == "F" || columns[3] == "B" || columns[3] == "P")
                {
                    Account a = new Account();
                    a.AccountNumber = columns[0];
                    a.Balance = Convert.ToDecimal(columns[2]);

                    if (columns[3] == "F")
                    {
                        a.Name = "Free Account";
                        a.Type = AccountType.Free;
                    }
                    else if (columns[3] == "B")
                    {
                        a.Name = "Basic Account";
                        a.Type = AccountType.Basic;
                    }
                    else {
                        a.Name = "Premium Account";
                        a.Type = AccountType.Premium;
                    }
                    accounts.Add(a);
                }
            }
            return accounts;
        }

        public Account LoadAccount(string AccountNumber)
        {
            List<Account> accountList = _accountList();

            foreach(Account account in accountList)
            {
                if (AccountNumber == account.AccountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        //create string for textfile change
        static string accountDataForTextFile(Account account)
        {
            string textString = null;

            //AccountNumber,Name,Balance,Type
            if(account.Type == AccountType.Free)
            {
                textString = $"{account.AccountNumber},'Free Customer',{account.Balance.ToString()},'F'";
            } else if (account.Type == AccountType.Basic)
            {
                textString = $"{account.AccountNumber},'Basic Customer',{account.Balance.ToString()},'B'";
            } else
            {
                textString = $"{account.AccountNumber},'Premium Customer',{account.Balance.ToString()},'P'";
            }

            return textString;
        }

        //edit text file line
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public void SaveAccount(Account account)
        {
            string newText = null;

            List<Account> accountList = _accountList();

            foreach (Account a in accountList)
            {
                if (a.AccountNumber == account.AccountNumber)
                {
                    a.Balance = account.Balance;

                    //update file
                    string[] rows = File.ReadAllLines(filePath);
                    for (int i = 1; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        if(columns[0] == a.AccountNumber)
                        {
                            newText = accountDataForTextFile(a);
                            lineChanger(newText, filePath, i);
                        }

                    }
                }
            }
        }
    }
}
