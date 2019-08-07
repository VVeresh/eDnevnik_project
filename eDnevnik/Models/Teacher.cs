using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class Teacher : User
    {
        public string TeacherName { get; set; }

        public string TeacherSurname { get; set; }

        public Subject TeachingSubject { get; set; }

        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}