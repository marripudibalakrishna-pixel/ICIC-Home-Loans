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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public DepartmentRepository(IConnectionFactory connectionFactory) 
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddDepartment(Department department)
        {
            using (IDbConnection cn = _connectionFactory.dbNorthWind())
            {
                // Implementation for adding a department
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.DeptName, department.deptname);
                parameters.Add(StoredProcedureParameters.DeptLocation, department.deptlocation);
                parameters.Add(StoredProcedureParameters.DeptInsertedvariable, dbType: DbType.Int32, direction: ParameterDirection.Output);
              await   cn.ExecuteScalarAsync(StoredProcedureNames.AddDepartment, parameters, commandType: CommandType.StoredProcedure);
                var res= parameters.Get<int>(StoredProcedureParameters.DeptInsertedvariable);
                return res;
            }
        }

        public async Task<bool> DeleteDepartment(int deptid)
        {
            using(IDbConnection cn = _connectionFactory.dbNorthWind())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.DeptId, deptid);
                var result =await  cn.ExecuteScalarAsync(StoredProcedureNames.DeleteDepartment, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            using(IDbConnection cn = _connectionFactory.dbNorthWind())
            {
                var result = await cn.QueryAsync<Department>(StoredProcedureNames.GetDepartment, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<Department> GetDepartmentById(int deptid)
        {
            using(IDbConnection cn = _connectionFactory.dbNorthWind())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.DeptId, deptid);
                var result = cn.QueryFirstOrDefaultAsync<Department>(StoredProcedureNames.GetDepartmentByDeptId, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            using(IDbConnection cn = _connectionFactory.dbNorthWind())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.DeptId, department.deptid);
                parameters.Add(StoredProcedureParameters.DeptName, department.deptname);
                parameters.Add(StoredProcedureParameters.DeptLocation, department.deptlocation);
                var result = await cn.ExecuteScalarAsync(StoredProcedureNames.UpdateDepartment, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
