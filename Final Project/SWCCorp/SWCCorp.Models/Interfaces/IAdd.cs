using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCCorp.Models;
using SWCCorp.Models.Responses;

namespace SWCCorp.Models.Interfaces
{
    public interface IAdd
    {
        AddResponse Add(Order order, string date, string name, Products productType, string state = "", decimal area = 0);
    }
}
