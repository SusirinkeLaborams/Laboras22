using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Assignments
{
    public class University : IDataItem
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string Description { get; set; }
        public int YearFounded { get; set; }
        public int RectorId { get; set; }
    }
}
