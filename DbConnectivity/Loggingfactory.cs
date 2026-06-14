using Dapper;
using Entities.Interfaces;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnectivity
{
    public class Loggingfactory : ILoggingFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        public Loggingfactory(IConnectionFactory connectionFactory) 
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> projectlevelErrorlog(int statuscode, string message, string stacktrace, string innerexception)
        {
            using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.StatusCode, statuscode);
                parameters.Add(StoredProcedureParameters.Message, message);
                parameters.Add(StoredProcedureParameters.StackTrace, stacktrace);
                parameters.Add(StoredProcedureParameters.InnerException, innerexception);
                var result = await cn.ExecuteScalarAsync(StoredProcedureNames.ProjectLevelErrorLog, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<bool> projectlevellog(string username, string loglevel, string messagetemplate)
        {
            using (IDbConnection cn = _connectionFactory.dbHotelManagementdb())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(StoredProcedureParameters.Username, username);
                parameters.Add(StoredProcedureParameters.LogLevel, loglevel);
                parameters.Add(StoredProcedureParameters.MessageTemplate, messagetemplate);
                var result = await cn.ExecuteScalarAsync(StoredProcedureNames.ProjectLevelLog, parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
