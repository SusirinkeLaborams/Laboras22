using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Users
{
    public class Lecturer : User
    {
        public int FacultyDepartment { get; set; }
    }
}
