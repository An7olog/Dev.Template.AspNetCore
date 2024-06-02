using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class PatientModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "PatientId")]
		public int PatientId { get; set; }

		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		[Display(Name = "LastName")]
		public string LastName { get; set; }

		[Display(Name = "DateOfBirth")]
		public DateTime? DateOfBirth { get; set; }

		[Display(Name = "Gender")]
		public string Gender { get; set; }

		[Display(Name = "Address")]
		public string Address { get; set; }

		[Display(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		public static PatientModel FromEntity(Patient obj)
		{
			return obj == null ? null : new PatientModel
			{
				PatientId = obj.PatientId,
				FirstName = obj.FirstName,
				LastName = obj.LastName,
				DateOfBirth = obj.DateOfBirth,
				Gender = obj.Gender,
				Address = obj.Address,
				PhoneNumber = obj.PhoneNumber,
			};
		}

		public static Patient ToEntity(PatientModel obj)
		{
			return obj == null ? null : new Patient(obj.PatientId, obj.FirstName, obj.LastName, obj.DateOfBirth,
				obj.Gender, obj.Address, obj.PhoneNumber);
		}

		public static List<PatientModel> FromEntitiesList(IEnumerable<Patient> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Patient> ToEntitiesList(IEnumerable<PatientModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
