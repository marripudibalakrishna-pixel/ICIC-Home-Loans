using Dapper;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using Entities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        
            private readonly IConnectionFactory _connectionFactory;
            public UserRepository(IConnectionFactory connectionFactory)
            {
                _connectionFactory = connectionFactory;
            }

            public async Task<UserSignInResponse> UserResgistration(Users usersObj)
            {
                using (IDbConnection con = _connectionFactory.dbHotelManagementdb())
                {
                    var encryptText = EncryptionLibrary.EncryptText(usersObj.Password);
                    //==========******For Testing Point of view you  can see the  decrypt text=======
                    var decryptText = EncryptionLibrary.DecryptText(encryptText);
                    //===========================================================================
                    var p = new DynamicParameters();
                    p.Add("@UserName", usersObj.UserName);
                    p.Add("@Password", encryptText);//here pass the encrypted string to store in database.password is secure
                    p.Add("@EmailId", usersObj.EmailId);
                    p.Add("@PhoneNumber", usersObj.PhoneNumber);
                    p.Add("@Address", usersObj.Address);
                    p.Add("@IsActive", usersObj.IsActive);
                    var result = await con.QuerySingleAsync<UserSignInResponse>(StoredProcedureNames.Usp_UserResgistration, p, commandType: CommandType.StoredProcedure);
                    return result;

                }
            }

            public async Task<UserSignInResponse> UserRolesMapping(UserRole userRoleObj)
            {
                using (IDbConnection con = _connectionFactory.dbHotelManagementdb())
                {
                    var p = new DynamicParameters();
                    p.Add("@RoleId", userRoleObj.RoleId);
                    p.Add("@UserId", userRoleObj.UserId);
                    var result = await con.QuerySingleAsync<UserSignInResponse>(StoredProcedureNames.Usp_UserRolesMapping, p, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
        }
    }
