using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models.DTOs
{
    public class PupilDTO : UserDto
    {
        [Required]
        [Display(Name = "Pupil name")]
        public string PupilName { get; set; }

        [Required]
        [Display(Name = "Pupil name")]
        public string PupilSurname { get; set; }
    }
}