using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicalRecordModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "RecordId")]
		public int RecordId { get; set; }

		[Display(Name = "PatientId")]
		public int? PatientId { get; set; }

		[Display(Name = "RecordDate")]
		public DateTime? RecordDate { get; set; }

		[Display(Name = "RecordDetails")]
		public string RecordDetails { get; set; }

		public static MedicalRecordModel FromEntity(MedicalRecord obj)
		{
			return obj == null ? null : new MedicalRecordModel
			{
				RecordId = obj.RecordId,
				PatientId = obj.PatientId,
				RecordDate = obj.RecordDate,
				RecordDetails = obj.RecordDetails,
			};
		}

		public static MedicalRecord ToEntity(MedicalRecordModel obj)
		{
			return obj == null ? null : new MedicalRecord(obj.RecordId, obj.PatientId, obj.RecordDate,
				obj.RecordDetails);
		}

		public static List<MedicalRecordModel> FromEntitiesList(IEnumerable<MedicalRecord> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<MedicalRecord> ToEntitiesList(IEnumerable<MedicalRecordModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
