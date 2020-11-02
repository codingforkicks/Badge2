using SWCCorp.Models;
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
        private IOrderRepo _orderRepository;
        private ITaxRepo _taxRepo;
        private IProductsRepo _productRepo;

        public OrderManager(IOrderRepo orderRepository, ITaxRepo taxRepo, IProductsRepo productRepo)
        {
            _orderRepository = orderRepository;
            _taxRepo = taxRepo;
            _productRepo = productRepo;
        }

        public OrderResponse LookupOrder(string date)
        {
            OrderResponse response = new OrderResponse();
            response.Orders = _orderRepository.DisplayOrders(date);

            if(response.Orders == null)
            {
                response.Success = false;
                response.Message = $"No orders were found for {date}.";
            } else
            {
                response.Success = true;
            }

            return response;
        }
        
        public ModifyResponse Modify(Order order, string date, string prompt)
        {
            ModifyResponse response = new ModifyResponse();
            _orderRepository.SaveOrder(order, date, prompt);
            response.Orders = _orderRepository.DisplayOrders(date);

            if (response.Orders == null)
            {
                response.Success = false;
                response.Message = $"No orders were found for {date}.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
