using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnik.Models
{
    public enum Marks { One = 1, Two, Three, Four, Five}

    public class Mark
    {
        public int Id { get; set; }

        public Marks MarkValue { get; set; }
    }
}