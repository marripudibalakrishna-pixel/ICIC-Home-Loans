using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddOrders(Orders orders);
        Task<bool>DeleteOrders(int orderid);
        Task<bool>UpdateOrders(Orders orders);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrdersById(int orderid);
    }
}
