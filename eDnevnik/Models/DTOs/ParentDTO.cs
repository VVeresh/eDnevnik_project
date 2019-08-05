using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnik.Models.DTOs
{
    public class ParentDTO : UserDto
    {
        [Required]
        [Display(Name = "Parent name")]
        public string ParentName { get; set; }

        [Required]
        [Display(Name = "Parent surname")]
        public string ParentSurname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Parent email")]
        public string Email { get; set; }
    }
}