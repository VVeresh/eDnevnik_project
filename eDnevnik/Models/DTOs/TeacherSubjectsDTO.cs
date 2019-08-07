using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models.DTOs
{
    public class TeacherSubjectsDTO
    {
        [Required]
        [Display(Name = "Teacher name")]
        public string TeacherName { get; set; }

        [Required]
        [Display(Name = "Teacher surname")]
        public string TeacherSurname { get; set; }

        [Required]
        [Display(Name = "Teaching subjects")]
        public ICollection<Subject> TeachingSubjects { get; set; }
    }
}