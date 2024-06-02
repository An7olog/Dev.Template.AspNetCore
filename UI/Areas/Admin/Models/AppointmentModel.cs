using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class AppointmentModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "AppointmentId")]
		public int AppointmentId { get; set; }

		[Display(Name = "PatientId")]
		public int? PatientId { get; set; }

		[Display(Name = "DoctorId")]
		public int? DoctorId { get; set; }

		[Display(Name = "AppointmentDate")]
		public DateTime? AppointmentDate { get; set; }

		public static AppointmentModel FromEntity(Appointment obj)
		{
			return obj == null ? null : new AppointmentModel
			{
				AppointmentId = obj.AppointmentId,
				PatientId = obj.PatientId,
				DoctorId = obj.DoctorId,
				AppointmentDate = obj.AppointmentDate,
			};
		}

		public static Appointment ToEntity(AppointmentModel obj)
		{
			return obj == null ? null : new Appointment(obj.AppointmentId, obj.PatientId, obj.DoctorId,
				obj.AppointmentDate);
		}

		public static List<AppointmentModel> FromEntitiesList(IEnumerable<Appointment> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Appointment> ToEntitiesList(IEnumerable<AppointmentModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
