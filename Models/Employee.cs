﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int department_id { get; set; }
        public string designation { get; set; }
    }
}
