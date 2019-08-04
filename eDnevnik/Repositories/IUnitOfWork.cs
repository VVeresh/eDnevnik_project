using eDnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UsersRepository { get; }
        IGenericRepository<Admin> AdminsRepository { get; set; }
        IGenericRepository<Mark> MarksRepository { get; set; }
        IGenericRepository<Parent> ParentsRepository { get; set; }
        IGenericRepository<Pupil> PupilsRepository { get; set; }
        IGenericRepository<Subject> SubjectsRepository { get; set; }
        IGenericRepository<Teacher> TeachersRepository { get; set; }
        IGenericRepository<Class> ClassesRepository { get; set; }

        void Save();
    }
}