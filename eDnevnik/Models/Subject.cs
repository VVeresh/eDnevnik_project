using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public int FundOfClasses { get; set; }

        public Teacher Teacher { get; set; }
    }
}