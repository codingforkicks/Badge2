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
        //open repository file if it exists
        string path = @"c:\Data\Accounts.txt";

        if(File.Exists(path)){

        } else {
            File.Create()
        }

        
    }
}
