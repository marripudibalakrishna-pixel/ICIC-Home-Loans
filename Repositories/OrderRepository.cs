using Dapper;
using Entities.Interfaces;
using Entities.Models;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddOrders(Orders orders)
        {
            using (IDbConnection cn = _connectionFactory.dbMidLanddb())
            {
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add(StoredProcedureParameters.OrderId, orders.orderid);
                parameters.Add(StoredProcedureParameters.OrderName, orders.ordername);
                parameters.Add(StoredProcedureParameters.OrderLocation, orders.orderlocation, DbType.String);
                parameters.Add(StoredProcedureParameters.OrderInsertedvariable, dbType: DbType.Int32, direction: ParameterDirection.Output);

                await cn.ExecuteScalarAsync(StoredProcedureNames.AddOrder, parameters, commandType: CommandType.StoredProcedure);
                var result1 = parameters.Get<int>(StoredProcedureParameters.OrderInsertedvariable);
                return result1;
            }
        }

        public async Task<bool> DeleteOrders(int orderid)
        {
            using (IDbConnection cn = _connectionFactory.dbMidLanddb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.OrderId, orderid);
                var result = await cn.ExecuteScalarAsync(StoredProcedureNames.DeleteOrder, parameters, commandType: CommandType.StoredProcedure);
                return true; ;
            }
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            using (IDbConnection cn = _connectionFactory.dbMidLanddb())
            {
                var result = await cn.QueryAsync<Orders>(StoredProcedureNames.GetOrder, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<Orders> GetOrdersById(int orderid)
        {
            using (IDbConnection cn = _connectionFactory.dbMidLanddb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.OrderId, orderid);
                var result = await cn.QueryFirstOrDefaultAsync<Orders>(StoredProcedureNames.GetOrderByOrderId, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> UpdateOrders(Orders orders)
        {
            using (IDbConnection cn = _connectionFactory.dbMidLanddb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.OrderId, orders.orderid);
                parameters.Add(StoredProcedureParameters.OrderName, orders.ordername);
                parameters.Add(StoredProcedureParameters.OrderLocation, orders.orderlocation, DbType.String);
                var result = await cn.ExecuteScalarAsync(StoredProcedureNames.UpdateOrder, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
