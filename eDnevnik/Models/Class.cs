using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public enum Year { First = 1, Second, Third, Fourth, Fiveth, Sixth, Seventh, Eighth}

    public class Class
    {
        public int Id { get; set; }

        public Year ClassYear { get; set; }

        public int ClassNumber { get; set; }

        public Teacher HomeroomTeacher { get; set; }

        public ICollection<Subject> Subjects { get; set; }        

        public ICollection<Pupil> Pupils { get; set; }
    }
}