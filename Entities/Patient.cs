using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Patient
	{
		public int PatientId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }

		public Patient(int patientId, string firstName, string lastName, DateTime? dateOfBirth, string gender,
			string address, string phoneNumber)
		{
			PatientId = patientId;
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = dateOfBirth;
			Gender = gender;
			Address = address;
			PhoneNumber = phoneNumber;
		}
	}
}
