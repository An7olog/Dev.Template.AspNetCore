using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Doctor
	{
		public int DoctorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Specialization { get; set; }
		public int? DepartmentId { get; set; }

		public Doctor(int doctorId, string firstName, string lastName, string specialization, int? departmentId)
		{
			DoctorId = doctorId;
			FirstName = firstName;
			LastName = lastName;
			Specialization = specialization;
			DepartmentId = departmentId;
		}
	}
}
