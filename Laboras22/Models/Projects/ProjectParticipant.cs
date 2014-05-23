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
        public int Project { get; set; }
        public int Student { get; set; }
    }
}
