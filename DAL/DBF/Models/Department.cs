﻿using System;
using System.Collections.Generic;

namespace DAL.DBF.Models;

public partial class Department
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
