using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class MedicalRecord
	{
		public int RecordId { get; set; }
		public int? PatientId { get; set; }
		public DateTime? RecordDate { get; set; }
		public string RecordDetails { get; set; }

		public MedicalRecord(int recordId, int? patientId, DateTime? recordDate, string recordDetails)
		{
			RecordId = recordId;
			PatientId = patientId;
			RecordDate = recordDate;
			RecordDetails = recordDetails;
		}
	}
}
