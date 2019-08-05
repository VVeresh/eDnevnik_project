using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models.DTOs
{
    public class TeacherDTO : UserDto
    {
        [Required]
        [Display(Name = "Teacher name")]
        public string TeacherName { get; set; }

        [Required]
        [Display(Name = "Teacher surname")]
        public string TeacherSurname { get; set; }
    }
}