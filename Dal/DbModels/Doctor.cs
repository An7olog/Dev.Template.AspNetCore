using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Specialization { get; set; }

    public int? DepartmentId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; }
}
