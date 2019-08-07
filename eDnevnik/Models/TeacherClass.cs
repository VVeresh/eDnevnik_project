using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class TeacherClass
    {
        [Key, Column(Order = 1)]
        public string Teacher_Id { get; set; }

        [Key, Column(Order = 2)]
        public int Class_Id { get; set; }

        [ForeignKey("Teacher_Id")]
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("Class_Id")]
        public virtual Class Class { get; set; }
    }
}