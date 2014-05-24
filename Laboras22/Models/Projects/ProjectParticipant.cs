using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Projects
{
    class ProjectParticipant : IDataItem
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int StudentId { get; set; }
    }
}
