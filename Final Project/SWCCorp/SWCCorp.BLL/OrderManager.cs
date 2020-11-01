using SWCCorp.BLL.Validation;
using SWCCorp.Models.Interfaces;
using SWCCorp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderResponse LookupOrder(string date)
        {
            OrderResponse response = new OrderResponse();
            response.Order = _orderRepository.DisplayOrders(date);

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = $"No orders were found for {date}.";
            } else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
