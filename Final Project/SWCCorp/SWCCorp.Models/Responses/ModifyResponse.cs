using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Responses
{
    public class ModifyResponse : Response
    {
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
        public string Date { get; set; }
    }
}
