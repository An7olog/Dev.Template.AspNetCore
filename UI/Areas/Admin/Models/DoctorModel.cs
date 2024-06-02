using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DoctorModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "DoctorId")]
		public int DoctorId { get; set; }

		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		[Display(Name = "LastName")]
		public string LastName { get; set; }

		[Display(Name = "Specialization")]
		public string Specialization { get; set; }

		[Display(Name = "DepartmentId")]
		public int? DepartmentId { get; set; }

		public static DoctorModel FromEntity(Doctor obj)
		{
			return obj == null ? null : new DoctorModel
			{
				DoctorId = obj.DoctorId,
				FirstName = obj.FirstName,
				LastName = obj.LastName,
				Specialization = obj.Specialization,
				DepartmentId = obj.DepartmentId,
			};
		}

		public static Doctor ToEntity(DoctorModel obj)
		{
			return obj == null ? null : new Doctor(obj.DoctorId, obj.FirstName, obj.LastName, obj.Specialization,
				obj.DepartmentId);
		}

		public static List<DoctorModel> FromEntitiesList(IEnumerable<Doctor> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Doctor> ToEntitiesList(IEnumerable<DoctorModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
