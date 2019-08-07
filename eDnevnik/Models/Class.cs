using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{  
    public class Class
    {
        public int Id { get; set; }

        public int ClassYear { get; set; }

        public int ClassNumber { get; set; }

        public Teacher HomeroomTeacher { get; set; }

        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }       
    }
}