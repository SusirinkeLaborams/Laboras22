using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Interfaces;

namespace Laboras22.Models.Users
{
    public class User : IDataItem
    {
        public int Id { get; set; }
        public String Email {get; set;}
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int LoginID { get; set; }
    }
}
