using Dapper;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Authenticaterepository: IAuthenticateRepository

    {

        private readonly IConnectionFactory _connectionFactory;
        public Authenticaterepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<UserRolesInformationResponse> GetUserRolesInformation(LoginDTO loginDTOObj)
        {
            using (IDbConnection con = _connectionFactory.dbHotelManagementdb())
            {
                var p = new DynamicParameters();
                p.Add("@UserName", loginDTOObj.UserName);
                //var queryResult = await conn.QueryAsync<Hotel>(StoredProcedureStaticMessages.GetHotelDetails, CommandType.StoredProcedure);
                var result = await con.QueryAsync<UserRolesInformationResponse>(StoredProcedureNames.GetUserRolesInformation, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;
            }
        }
        public async Task<UserSignInResponse> UserSignIn(LoginDTO loginDTOObj)
        {
            using (IDbConnection con = _connectionFactory.dbHotelManagementdb())
            {
                var encryptText = EncryptionLibrary.EncryptText(loginDTOObj.Password);
                //==========******For Testing Point of view you  can see the  decrypt text=======
                var decryptText = EncryptionLibrary.DecryptText(encryptText);
                //===========================================================================
                var p = new DynamicParameters();
                p.Add("@UserName", loginDTOObj.UserName);
                p.Add("@Password", encryptText);
                //var queryResult = await conn.QueryAsync<Hotel>(StoredProcedureStaticMessages.GetHotelDetails, CommandType.StoredProcedure);
                var result = await con.QueryAsync<UserSignInResponse>(StoredProcedureNames.SignIn, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;
            }
        }
    }
}
    