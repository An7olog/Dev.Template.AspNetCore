using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Appointment = Entities.Appointment;

namespace BL
{
	public class AppointmentsBL
	{
		public async Task<int> AddOrUpdateAsync(Appointment entity)
		{
			entity.AppointmentId = await new AppointmentsDal().AddOrUpdateAsync(entity);
			return entity.AppointmentId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new AppointmentsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(AppointmentsSearchParams searchParams)
		{
			return new AppointmentsDal().ExistsAsync(searchParams);
		}

		public Task<Appointment> GetAsync(int id)
		{
			return new AppointmentsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new AppointmentsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Appointment>> GetAsync(AppointmentsSearchParams searchParams)
		{
			return new AppointmentsDal().GetAsync(searchParams);
		}
	}
}

