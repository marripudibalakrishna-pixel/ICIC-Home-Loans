using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IorderService
    {
        Task<int> AddOrders(OderDto orders);
        Task<bool> DeleteOrders(int orderid);
        Task<bool> UpdateOrders(OderDto orders);
        Task<List<OderDto>> GetAllOrders();
        Task<OderDto> GetOrdersById(int orderid);
    }
}
