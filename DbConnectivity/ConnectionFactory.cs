using Entities.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnectivity
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public SqlConnection dbHotelManagementdb()
        {
            var connectionstring = Convert.ToString(_configuration.GetSection("ConnectionStrings:HotelmanagementsqlConnectionString").Value);

            SqlConnection cn = new SqlConnection(connectionstring);
            return cn;
        }
    }
}
