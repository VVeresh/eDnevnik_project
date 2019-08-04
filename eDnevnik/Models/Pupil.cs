using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public class Pupil : User
    {
        public string PupilName { get; set; }

        public string PupilSurname { get; set; }
    }
}