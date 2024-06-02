using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
