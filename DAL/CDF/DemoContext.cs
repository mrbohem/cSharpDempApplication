using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.CDF
{
    public class DemoContext:DbContext
    {
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
    }
}
