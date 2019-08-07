using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models.DTOs
{
    public class ClassDTO
    {
        [Required]
        [Display(Name = "Class year")]
        public int ClassYear { get; set; }

        [Required]
        [Display(Name = "Class number")]
        public int ClassNumber { get; set; }

        [Required]
        [Display(Name = "Homeroom Teacher")]
        public Teacher HomeroomTeacher { get; set; }
    }
}