using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class Parent : User
    {
        public string ParentName { get; set; }

        public string ParentSurname { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Pupil> Pupils { get; set; }
    }
}