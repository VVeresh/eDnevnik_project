using eDnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public interface ITeachersService
    {
        IEnumerable<Teacher> GetAllTeachers();
    }
}
