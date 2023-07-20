using System;
using System.Collections.Generic;

namespace DAL.DBF.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? DepartmentId { get; set; }

    public string? Designation { get; set; }

    public virtual Department? Department { get; set; }
}
