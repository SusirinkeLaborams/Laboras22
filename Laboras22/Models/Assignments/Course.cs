using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Assignments
{
    public class Course : IDataItem
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int FacultyDepartmentId { get; set; }
        public int OwnerId { get; set; }
        public int SchoolYear { get; set; }
    }
}
