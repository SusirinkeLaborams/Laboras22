using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Assignments
{
    public class Faculty : IDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public int DeanId { get; set; }
        public string Address { get; set; }
    }
}
