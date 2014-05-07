using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models
{
    public class Project : IDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssignmentId { get; set; }
        public int OwnerId { get; set; }
    }
}
