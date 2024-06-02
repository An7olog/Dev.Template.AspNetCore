using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Appointment
	{
		public int AppointmentId { get; set; }
		public int? PatientId { get; set; }
		public int? DoctorId { get; set; }
		public DateTime? AppointmentDate { get; set; }

		public Appointment(int appointmentId, int? patientId, int? doctorId, DateTime? appointmentDate)
		{
			AppointmentId = appointmentId;
			PatientId = patientId;
			DoctorId = doctorId;
			AppointmentDate = appointmentDate;
		}
	}
}
