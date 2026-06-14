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
    public class EmployeeService : IEmployeeService
         
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> AddEmployee(EmployeeDto employee)
        {

            Employee emp = new Employee();
            emp.empid = employee.EmpId;
            emp.empname = employee.EmpName;
            emp.empsalary = employee.EmpSalary;
            var result = await _employeeRepository.AddEmployee(emp);
            return result;




        }

        public async Task<bool> DeleteEmployee(int empid)
        {
            var result = await _employeeRepository.DeleteEmployee(empid);
            return result;

        }

        public async  Task<List<EmployeeDto>> GetAllEmployees()
        {
            var result = await _employeeRepository.GetAllEmployees();
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            foreach (var empdto in result)
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.EmpId = empdto.empid;
                employeeDto.EmpName = empdto.empname;
                employeeDto.EmpSalary = empdto.empsalary;
                employeeDtos.Add(employeeDto);

            }
            return employeeDtos;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res= await _employeeRepository.GetEmployeeById(empid);
            EmployeeDto employeeDto = new EmployeeDto();
            employeeDto.EmpId = res.empid;
            employeeDto.EmpName = res.empname;
            employeeDto.EmpSalary = res.empsalary;
            return employeeDto;

        }

        public Task<bool> UpdateEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee();
            emp.empid = employee.EmpId;
            emp.empname = employee.EmpName;
            emp.empsalary = employee.EmpSalary;
            var result = _employeeRepository.UpdateEmployee(emp);
            return result;
        }
    }
}
