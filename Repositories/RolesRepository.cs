using Dapper;
using Entities.Dtos;
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
    public class RolesRepository : IRolesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RolesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> RolesCreation(Roles rolesObj)
        {
            using (IDbConnection con = _connectionFactory.dbHotelManagementdb())
            {
                var p = new DynamicParameters();
                p.Add("@RoleName", rolesObj.RoleName);
                p.Add("@IsActive", rolesObj.IsActive);
                var result = await con.QuerySingleAsync<UserSignInResponse>(StoredProcedureNames.Usp_RolesResgistration, p, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
