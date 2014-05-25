using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Assignments
{
    public class Assignment : IDataItem
    {
        public int Id { get; set; }
        public string AssignmentName { get; set; }
        public string Task { get; set; }
        public int CourseId { get; set; }
        public int LecturerId { get; set; }
        public int Difficulty { get; set; }
    }
}
