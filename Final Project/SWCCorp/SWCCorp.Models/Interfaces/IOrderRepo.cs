using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.Models.Interfaces
{
    public interface IOrderRepo
    {
        List<Order> DisplayOrders(string date);

        void SaveOrder(Order orders, string date, string prompt);
    }
}