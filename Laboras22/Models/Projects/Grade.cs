using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Projects
{
    class Grade : IDataItem
    {
        public int Id { get; set; }
        public int Participant { get; set; }
    }
}
