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
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public EmployeeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.EmpName, employee.empname);
                parameters.Add(StoredProcedureParameters.EmpSalary, employee.empsalary);
                parameters.Add(StoredProcedureParameters.insertedvalue, dbType: DbType.Int32, direction: ParameterDirection.Output);
                await cn.ExecuteScalarAsync(StoredProcedureNames.AddEmployee, parameters, commandType: CommandType.StoredProcedure);
              var result = parameters.Get<int>(StoredProcedureParameters.insertedvalue);
                return result;
            }
        }

        public async  Task<bool> DeleteEmployee(int empid)
        {
            using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.EmpId, empid);
                await cn.ExecuteScalarAsync(StoredProcedureNames.DeleteEmployee, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                var employees = await cn.QueryAsync<Employee>(StoredProcedureNames.GetAllEmployees, commandType: CommandType.StoredProcedure);
                return employees.ToList();
            }
        }

        public async  Task<Employee> GetEmployeeById(int empid)
        {
            using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.EmpId, empid);
                var result = await cn.QueryAsync<Employee>(StoredProcedureNames.GetEmployeeById, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            //using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            //{
            //    DynamicParameters parameters = new DynamicParameters();
            //    parameters.Add(StoredProcedureParameters.EmpId, employee.empid);
            //    var result = await cn.QueryAsync<Employee>(StoredProcedureNames.GetEmployeeById, parameters, commandType: CommandType.StoredProcedure);
            //    return result.FirstOrDefault();

                using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.EmpId, employee.empid);
                parameters.Add(StoredProcedureParameters.EmpName, employee.empname);
                parameters.Add(StoredProcedureParameters.EmpSalary, employee.empsalary);
                await cn.ExecuteScalarAsync(StoredProcedureNames.UpdateEmployee, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
