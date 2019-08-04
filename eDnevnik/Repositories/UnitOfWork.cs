using eDnevnik.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;

namespace eDnevnik.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        [Dependency]
        public IGenericRepository<User> UsersRepository { get; set; }

        [Dependency]
        public IGenericRepository<Admin> AdminsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Mark> MarksRepository { get; set; }

        [Dependency]
        public IGenericRepository<Parent> ParentsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Pupil> PupilsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Subject> SubjectsRepository { get; set; }

        [Dependency]
        public IGenericRepository<Teacher> TeachersRepository { get; set; }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}