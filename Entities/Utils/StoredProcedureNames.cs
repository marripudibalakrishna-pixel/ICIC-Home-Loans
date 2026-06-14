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

        #region Stored Procedures for project error level log
        public static string ProjectLevelErrorLog = "Usp_AddProjectLevelErrorlog";
#endregion
        #region Stored Procedures for project level log
        public static string ProjectLevelLog = "Usp_ProjectLevelLog";
        #endregion
        #region TokenBasedAuthentication storedprocedures
        public static readonly string GetUserRolesInformation = "Usp_GetUserRolesInformation";

        public static readonly string SignIn = "Usp_LoginCheck";

        public static readonly string Usp_UserResgistration = "Usp_UserResgistration";

        public static readonly string Usp_RolesResgistration = "Usp_RolesResgistration";

        public static readonly string Usp_UserRolesMapping = "Usp_UserRolesMapping";

        #endregion
    }
}
