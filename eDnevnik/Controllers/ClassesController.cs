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

        // GET: api/Classes
        [Authorize(Roles = "admins")]
        public IQueryable<Class> GetClasses()
        {
            return classesService.GetAllClasses().AsQueryable();
        }

        // GET: api/Classes/5/2
        [ResponseType(typeof(Class))]
        [Authorize(Roles = "admins")]
        [Route("{int:classsYear}/{int:classNumber}")]
        public IHttpActionResult GetUser([FromUri] int classYear, [FromUri] int classNumber)
        {
            Class _class = classesService.GetClass(classYear, classNumber);
            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }

        // POST: api/Classes
        [Route("")]
        [ResponseType(typeof(Class))]
        [Authorize(Roles = "admins")]
        public IHttpActionResult PostClass(Class _class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Class createdClass = classesService.CreateClass(_class);

            return Created("", createdClass);
        }

        // PUT: api/Classes/AddPupil/5/2 
        [Route("AddPupil/{id:classYear}/{role:classNumber}")]
        [ResponseType(typeof(Class))]
        public IHttpActionResult PutAddPupil([FromUri] int classYear, [FromUri] int classNumber, [FromBody] Pupil pupil)
        {
            Class classWithAddedPupil = classesService.AddPupil(classYear, classNumber, pupil);

            if (classWithAddedPupil == null)
            {
                return NotFound();
            }

            return Ok(classWithAddedPupil);
        }

        // PUT: api/Classes/AddSubject/5/2 
        [Route("AddPupil/{id:classYear}/{role:classNumber}")]
        [ResponseType(typeof(Class))]
        public IHttpActionResult PutAddPupil([FromUri] int classYear, [FromUri] int classNumber, [FromBody] Subject subject)
        {
            Class classWithAddedPupil = classesService.AddSubject(classYear, classNumber, subject);

            if (classWithAddedPupil == null)
            {
                return NotFound();
            }

            return Ok(classWithAddedPupil);
        }


        // DELETE: api/Classes/Delete/5/2 
        [Route("AddPupil/{id:classYear}/{role:classNumber}")]
        [ResponseType(typeof(Class))]
        public IHttpActionResult DeleteClass([FromUri] int classYear, [FromUri] int classNumber)
        {
            Class _class = classesService.DeleteClass(classYear, classNumber);

            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }        
    }
}
