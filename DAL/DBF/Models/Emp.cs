using System;
using System.Collections.Generic;

namespace DAL.DBF.Models;

public partial class Emp
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public int? DepartmentId { get; set; }

    public int? ManagerId { get; set; }

    public DateTime? Doj { get; set; }

    public int? Salary { get; set; }
}
