using eDnevnik.Models;
using eDnevnik.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Services
{
    public class ClassesService : IClassesService
    {
        private IUnitOfWork db;

        public ClassesService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public Class CreateClass(Class _class)
        {
            db.ClassesRepository.Insert(_class);
            db.Save();

            return _class;
        }

        public Class DeleteClass(int classYear, int classNumber)
        {
            Class _class = db.ClassesRepository.Get(x => (int)(x.ClassYear) == classYear && x.ClassNumber == classNumber).FirstOrDefault(); ;

            if (_class != null)
            {
                db.ClassesRepository.Delete(_class);
                db.Save();
            }

            return _class;
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return db.ClassesRepository.Get();
        }

        public Class GetClass(int classYear, int classNumber)
        {
            return db.ClassesRepository.Get(x => (int)(x.ClassYear) == classYear && x.ClassNumber == classNumber).FirstOrDefault();
        }       

        //public Class UpdateClass(int id, Year classYear, int classNumber, Teacher HomeroomTeacher)
        //{
        //    Class _class = db.ClassesRepository.GetByID(id);

        //    if (_class != null)
        //    {
        //        _class.ClassYear = classYear;
        //        _class.ClassNumber = classNumber;
        //        _class.HomeroomTeacher = HomeroomTeacher;                

        //        db.ClassesRepository.Update(_class);
        //        db.Save();
        //    }

        //    return _class;
        //}

        //public Class AddPupil(int classYear, int classNumber, Pupil pupil)
        //{
        //    Class _class = db.ClassesRepository.Get(x => (int)(x.ClassYear) == classYear && x.ClassNumber == classNumber).FirstOrDefault();

        //    if (_class != null)
        //    {
        //        _class.Pupils.Add(pupil);
             
        //        db.ClassesRepository.Update(_class);
        //        db.Save();
        //    }

        //    return _class;
        //}

        //public Class AddTeacher(int classYear, int classNumber, Teacher teacher)
        //{
        //    Class _class = db.ClassesRepository.Get(x => (int)(x.ClassYear) == classYear && x.ClassNumber == classNumber).FirstOrDefault();

        //    if (_class != null)
        //    {
        //        _class.Teachers.Add(teacher);

        //        db.ClassesRepository.Update(_class);
        //        db.Save();
        //    }

        //    return _class;
        //}

        //public Class RemovePupil(int classYear, int classNumber, Pupil pupil)
        //{
        //    Class _class = db.ClassesRepository.Get(x => (int)(x.ClassYear) == classYear && x.ClassNumber == classNumber).FirstOrDefault();

        //    if (_class != null)
        //    {
        //        _class.Pupils.Remove(pupil);

        //        db.ClassesRepository.Update(_class);
        //        db.Save();
        //    }

        //    return _class;
        //}

        //public Class RemoveTeacher(int classYear, int classNumber, Teacher teacher)
        //{
        //    Class _class = db.ClassesRepository.Get(x => (int)(x.ClassYear) == classYear && x.ClassNumber == classNumber).FirstOrDefault();

        //    if (_class != null)
        //    {
        //        _class.Teachers.Remove(teacher);

        //        db.ClassesRepository.Update(_class);
        //        db.Save();
        //    }

        //    return _class;
        //}
    }
}