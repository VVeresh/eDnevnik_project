using eDnevnik.Models;
using eDnevnik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eDnevnik.Controllers
{
    [RoutePrefix("api/teachers")]
    public class TeachersController : ApiController
    {
        private ITeachersService teachersService;        

        public TeachersController(ITeachersService teachersService)
        {
            this.teachersService = teachersService;
        }

        // GET: api/teachers
        [Route("")]
        [Authorize(Roles = "admins,teachers")]
        [HttpGet]
        public IQueryable<Teacher> GetClasses()
        {
            return teachersService.GetAllTeachers().AsQueryable();
        }

        public TeachersController()
        {

        }
    }
}
