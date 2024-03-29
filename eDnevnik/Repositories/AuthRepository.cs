﻿using eDnevnik.Infrastructure;
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
    public class AuthRepository : IDisposable, IAuthRepository
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserDto userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "users");
            return result;
        }

        public async Task<IdentityResult> RegisterAdminUser(UserDto userModel)
        {
            IdentityUser user = new IdentityUser { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "admins");
            return result;
        }

        public async Task<IdentityResult> RegisterTeacherUser(TeacherDTO userModel)
        {
            IdentityUser user = new IdentityUser { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "teachers");
            return result;
        }

        public async Task<IdentityResult> RegisterParentUser(ParentDTO userModel)
        {
            IdentityUser user = new IdentityUser { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "parents");
            return result;
        }

        public async Task<IdentityResult> RegisterPupilUser(PupilDTO userModel)
        {
            IdentityUser user = new IdentityUser { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "pupils");
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IList<string>> FindRoles(string userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}