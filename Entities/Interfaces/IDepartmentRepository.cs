using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<int> AddDepartment(Department department);
        Task<bool> DeleteDepartment(int deptid);
        Task<bool> UpdateDepartment(Department department);
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int deptid);
    }
}
