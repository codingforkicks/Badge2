﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Responses
{
    public class OrderLookUpResponse : Response
    {
        public Order Order { get; set; }
    }
}
