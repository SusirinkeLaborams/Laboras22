using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Assignments
{
    public class FacultyDepartment : IDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public int HeadId { get; set; }
        public string Description { get; set; }
    }
}
