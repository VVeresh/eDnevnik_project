using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    //public enum Year { First = 1, Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth}

    public class Class
    {
        public int Id { get; set; }

        //public Year ClassYear { get; set; }

        public int ClassYear { get; set; }

        public int ClassNumber { get; set; }

        public Teacher HomeroomTeacher { get; set; }

        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }

        //[ForeignKey("Id")]
        //public virtual ICollection<Teacher> Teachers { get; set; }

        //[ForeignKey("Id")]
        //public virtual ICollection<Pupil> Pupils { get; set; }
    }
}