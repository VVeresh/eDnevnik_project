using eDnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Services
{
    public interface IClassesService
    {
        IEnumerable<Class> GetAllClasses();

        Class GetClass(int classYear, int classNumber);

        Class CreateClass(Class _class);

        // Class UpdateClass(int id, Year classYear, int classNumber, Teacher HomeroomTeacher);

        //Class AddTeacher(int classYear, int classNumber, Teacher teacher);

        //Class AddPupil(int classYear, int classNumber, Pupil pupil);

        Class DeleteClass(int classYear, int classNumber);

        //Class RemovePupil(int classYear, int classNumber, Pupil pupil);     //?

        //Class RemoveTeacher(int classYear, int classNumber, Teacher teacher);       //?
    }
}