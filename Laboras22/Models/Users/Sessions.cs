using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Interfaces;

namespace Laboras22.Models.Users
{
    class Sessions : IDataItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public string IP { get; set; }
    }
}
