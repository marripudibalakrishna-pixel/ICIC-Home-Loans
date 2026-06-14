using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IRolesRepository
    {
        Task<UserSignInResponse> RolesCreation(Roles rolesObj);
    }
}
