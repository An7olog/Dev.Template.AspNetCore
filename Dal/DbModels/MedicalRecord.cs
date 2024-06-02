using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? RecordDate { get; set; }

    public string RecordDetails { get; set; }

    public virtual Patient Patient { get; set; }
}
