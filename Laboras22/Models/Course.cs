using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models
{
    public class Course : IDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyDepartmentId { get; set; }
    }
}
