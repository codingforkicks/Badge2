using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Responses
{
    public class OrderResponse : Response
    {
        public List <Order> Orders { get; set; }
        public int Date { get; set; }
    }
}
