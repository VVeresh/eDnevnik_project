using eDnevnik.Models.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace eDnevnik.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(UserDto userModel);

        Task<IdentityResult> RegisterAdminUser(UserDto userModel);
        Task<IdentityResult> RegisterTeacherUser(TeacherDTO userModel);
        Task<IdentityResult> RegisterParentUser(ParentDTO userModel);
        Task<IdentityResult> RegisterPupilUser(PupilDTO userModel);

        Task<IdentityUser> FindUser(string userName, string password);
        Task<IList<string>> FindRoles(string userId);

        void Dispose();
    }
}