﻿using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Models.Projects
{
    public class Project : IDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Assignment { get; set; }
        public int Owner { get; set; }
    }
}