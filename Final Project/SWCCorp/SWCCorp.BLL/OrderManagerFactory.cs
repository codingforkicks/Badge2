﻿using SWCCorp.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepo(), new TaxRepo(), new ProductRepo());
                case "Prod":
                    return new OrderManager(new FileRepo(), new TaxRepo(), new ProductRepo());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
