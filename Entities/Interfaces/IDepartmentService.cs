using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IDepartmentService
    {
        Task<int> AddDepartment(DepartmentDTo department);
        Task<bool> DeleteDepartment(int deptid);
        Task<bool> UpdateDepartment(DepartmentDTo department);
        Task<List<DepartmentDTo>> GetAllDepartments();
        Task<DepartmentDTo> GetDepartmentById(int deptid);
    }
}
