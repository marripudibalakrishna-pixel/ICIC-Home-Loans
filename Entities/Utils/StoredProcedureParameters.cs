using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Utils
{
    public static class StoredProcedureParameters
    {
        public const string EmpId = "@EmpId";
        public const string EmpName = "@EmpName";
        public const string EmpSalary = "@EmpSalary";
        public const string insertedvalue = "@insertvalue";

        #region StoredprocedureParameters for orders
        public static string OrderId = "@orderid";  //@orderid
        public static string OrderName = "@ordername";
        public static string OrderLocation = "@orderlocation";
        public static string OrderInsertedvariable = "@insertedvalue";

        #endregion


        #region Department Parameters
        public static string DeptId = "@deptid";
        public static string DeptName = "@deptname";
        public static string DeptLocation = "@deptlocation";
        public static string DeptInsertedvariable = "@insertedvalue";
        #endregion

        #region StoredprocedureParameters for projecterror level log

            public static string StatusCode = "@StatusCode";
            public static string Message = "@ErrorMessage";
            public static string StackTrace = "@StackTraceError";
            public static string InnerException = "@InnerExceptionError";
        #endregion

        #region StoredprocedureParameters for projecterror level log
        public static string Username = "@username";
        public static string LogLevel = "@LogLevel";
        public static string MessageTemplate = "@MessageTemplate";


        #endregion




    }
}
