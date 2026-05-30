using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(EmployeeDto employee);
        Task<bool> DeleteEmployee(int empid);
        Task<EmployeeDto> GetEmployeeById(int empid);
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<bool> UpdateEmployee(EmployeeDto employee);
    }
}
