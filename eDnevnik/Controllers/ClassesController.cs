using eDnevnik.Models;
using eDnevnik.Repositories;
using eDnevnik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace eDnevnik.Controllers
{
    [RoutePrefix("api/classes")]
    public class ClassesController : ApiController
    {
        //private IUnitOfWork db;

        //public ClassesController(IUnitOfWork unitOfWork)
        //{
        //    db = unitOfWork;
        //}

        private IClassesService classesService;

        public ClassesController(IClassesService classesService)
        {
            this.classesService = classesService;
        }

        // GET: api/classes
        [Authorize(Roles = "admins")]
        [HttpGet]
        [Route("")]
        public IQueryable<Class> GetClasses()
        {
            return classesService.GetAllClasses().AsQueryable();
        }

        // GET: api/classes/5/2
        [ResponseType(typeof(Class))]
        [Authorize(Roles = "admins")]
        [Route("{classYear}/{classNumber}")]
        [HttpGet]
        public IHttpActionResult GetUser([FromUri] int classYear, [FromUri] int classNumber)
        {
            Class _class = classesService.GetClass(classYear, classNumber);
            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }

        // POST: api/classes
        [Route("")]
        [ResponseType(typeof(Class))]
        [Authorize(Roles = "admins")]
        [HttpPost]
        public IHttpActionResult PostClass(Class _class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Class createdClass = classesService.CreateClass(_class);

            return Created("", createdClass);
        }

        // PUT: api/classes/addPupil/5/2 
        //[Route("addPupil/{classYear}/{classNumber}")]
        //[Authorize(Roles = "admins")]
        //[ResponseType(typeof(Class))]
        //[HttpPut]
        //public IHttpActionResult AddPupil([FromUri] int classYear, [FromUri] int classNumber, [FromBody] Pupil pupil)
        //{
        //    Class classWithAddedPupil = classesService.AddPupil(classYear, classNumber, pupil);

        //    if (classWithAddedPupil == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(classWithAddedPupil);
        //}

        // PUT: api/classes/addTeacher/5/2 
        //[Route("addTeacher/{classYear}/{classNumber}")]
        //[Authorize(Roles = "admins")]
        //[ResponseType(typeof(Class))]
        //[HttpPut]
        //public IHttpActionResult AddSubject([FromUri] int classYear, [FromUri] int classNumber, [FromBody] Teacher teacher)
        //{
        //    Class classWithAddedSubject = classesService.AddTeacher(classYear, classNumber, teacher);

        //    if (classWithAddedSubject == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(classWithAddedSubject);
        //}


        // DELETE: api/classes/delete/5/2 
        [Route("delete/{classYear}/{classNumber}")]
        [ResponseType(typeof(Class))]
        [Authorize(Roles = "admins")]
        [HttpDelete]
        public IHttpActionResult DeleteClass([FromUri] int classYear, [FromUri] int classNumber)
        {
            Class _class = classesService.DeleteClass(classYear, classNumber);

            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }

        public ClassesController()
        {

        }
    }
}
