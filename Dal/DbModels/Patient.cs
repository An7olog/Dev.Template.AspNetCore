using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
