using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboras22.Interfaces;

namespace Laboras22.Models.Users
{
    class UserLogin : IDataItem
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string OldPasswordHash { get; set; }
    }
}
