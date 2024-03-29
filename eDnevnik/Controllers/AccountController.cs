﻿using eDnevnik.Models.DTOs;
using eDnevnik.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDnevnik.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository repo = null;
        public AccountController()
        {
            repo = new AuthRepository();
        }
        //[AllowAnonymous]
        //[Route("register")]
        //public async Task<IHttpActionResult> Register(UserDto userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    IdentityResult result = await repo.RegisterUser(userModel);
        //    IHttpActionResult errorResult = GetErrorResult(result);
        //    if (errorResult != null)
        //    {
        //        return errorResult;
        //    }
        //    return Ok();
        //}

        [AllowAnonymous]
        [Route("register-admin")]
        public async Task<IHttpActionResult> RegisterAdmin(UserDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await repo.RegisterAdminUser(userModel);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }

        [AllowAnonymous]
        [Route("register-teacher")]
        public async Task<IHttpActionResult> RegisterTeacher(TeacherDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await repo.RegisterTeacherUser(userModel);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }

        [AllowAnonymous]
        [Route("register-parent")]
        public async Task<IHttpActionResult> RegisterParent(ParentDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await repo.RegisterParentUser(userModel);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }

        [AllowAnonymous]
        [Route("register-pupil")]
        public async Task<IHttpActionResult> RegisterPupil(PupilDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityResult result = await repo.RegisterPupilUser(userModel);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
