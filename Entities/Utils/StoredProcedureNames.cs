using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Utils
{
    public class StoredProcedureNames
    {
        #region Employee Stored Procedures
        public const string AddEmployee = "Usp_AddEmployeeReturn";
        public const string DeleteEmployee = "Usp_DeleteEmployee";
        public const string GetEmployeeById = "Usp_GetEmployeeId";
        public const string GetAllEmployees = "Usp_GetEmployee";
        public const string UpdateEmployee = "Usp_UpdateEmployee";
        #endregion

        #region orders Stored Procedures

        public static string AddOrder = "Usp_AddOrder";
        public static string UpdateOrder = "Usp_UpdateOrder";
        public static string DeleteOrder = "Usp_DeleteOrder";
        public static string GetOrder = "Usp_GetOrder";
        public static string GetOrderByOrderId = "Usp_GetOrderById";

        #endregion

        #region Department Stored Procedures
        public static string AddDepartment = "Usp_AddDepartment";
        public static string UpdateDepartment = "Usp_UpdateDepartment";
        public static string DeleteDepartment = "Usp_DeleteDepartment";
        public static string GetDepartment = "Usp_GetDepartment";
        public static string GetDepartmentByDeptId = "Usp_GetDepartmentById";

        #endregion

    }
}
