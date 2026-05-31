using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IorderService
    {
        public readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
    }
    
        public async Task<int> AddOrders(OderDto orders)
        {
            Orders orders1 = new Orders();

           // orders1.orderid = orders.orderid;
            orders1.ordername = orders.ordername;
            orders1.orderlocation = orders.orderlocation;
           var result= await _orderRepository.AddOrders(orders1);
           return result;
        }

        public async Task<bool> DeleteOrders(int orderid)
        {
            var result=await _orderRepository.DeleteOrders(orderid);
            return result;
        }

        public async Task<List<OderDto>> GetAllOrders()
        {
            var result=await _orderRepository.GetAllOrders();
            List<OderDto> orderDtos = new List<OderDto>();
            foreach (var item in result)
            {
                OderDto orderDto = new OderDto();
                orderDto.orderid = item.orderid;
                orderDto.ordername = item.ordername;
                orderDto.orderlocation = item.orderlocation;
                orderDtos.Add(orderDto);
            }
            return orderDtos;

        }

        public async  Task<OderDto> GetOrdersById(int orderid)
        {
            var result = await _orderRepository.GetOrdersById(orderid);
            OderDto orderDto = new OderDto();
            orderDto.orderid = result.orderid;
                
           orderDto.ordername = result.ordername;
            orderDto.orderlocation = result.orderlocation;
            return orderDto;
        }

        public async Task<bool> UpdateOrders(OderDto orders)
        {
             Orders orders1 = new Orders();
            orders1.orderid = orders.orderid;
            orders1.ordername = orders.ordername;
            orders1.orderlocation = orders.orderlocation;
            var result = await _orderRepository.UpdateOrders(orders1);
            return result;
        }
    }
}
