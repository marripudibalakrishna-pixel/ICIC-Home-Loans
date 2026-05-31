using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DepartmentService: IDepartmentService
    {
        public readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> AddDepartment(DepartmentDTo department)
        {
            Department dept = new Department();

            dept. deptid = department.deptid;
            dept.deptname = department.deptname;
            dept.deptlocation = department.deptlocation;

            var res = await _departmentRepository.AddDepartment(dept);
            return res;
        }

        public async Task<bool> DeleteDepartment(int deptid)
        {
            await _departmentRepository.DeleteDepartment(deptid);
            return true;


        }

        public async Task<List<DepartmentDTo>> GetAllDepartments()
        {
            var res = await _departmentRepository.GetAllDepartments();
            List<DepartmentDTo> deptlist = new List<DepartmentDTo>();
            foreach (var item in res)
            {
                DepartmentDTo dept = new DepartmentDTo();
                dept.deptid = item.deptid;
                dept.deptname = item.deptname;
                dept.deptlocation = item.deptlocation;
                deptlist.Add(dept);
            }
            return deptlist;

        }

        public async Task<DepartmentDTo> GetDepartmentById(int deptid)
        {
           var result = await _departmentRepository.GetDepartmentById(deptid);
            DepartmentDTo dept = new DepartmentDTo();
            dept.deptid = result.deptid;
            dept.deptname = result.deptname;
            dept.deptlocation = result.deptlocation;
            return dept;
        }

        public Task<bool> UpdateDepartment(DepartmentDTo department)
        {
            Department dept = new Department();
            dept.deptid = department.deptid;
            dept.deptname = department.deptname;
            dept.deptlocation = department.deptlocation;
            var res = _departmentRepository.UpdateDepartment(dept);
            return res;
        }
    }
}
