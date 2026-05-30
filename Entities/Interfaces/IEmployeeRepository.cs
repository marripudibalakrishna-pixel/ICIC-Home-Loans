using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IEmployeeRepository
    {

        Task<int>AddEmployee(Employee employee);
        Task<bool>DeleteEmployee(int empid);
        Task<Employee>GetEmployeeById(int empid);
        Task<List<Employee>>GetAllEmployees();
        Task<bool>UpdateEmployee(Employee employee);
    }
}
