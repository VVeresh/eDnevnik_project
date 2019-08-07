using eDnevnik.Models;
using eDnevnik.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Services
{
    public class TeachersService : ITeachersService
    {
        private IUnitOfWork db;

        public TeachersService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

      

     
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return db.TeachersRepository.Get();
        }

    }
}