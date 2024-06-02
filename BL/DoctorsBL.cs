using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Doctor = Entities.Doctor;

namespace BL
{
	public class DoctorsBL
	{
		public async Task<int> AddOrUpdateAsync(Doctor entity)
		{
			entity.DoctorId = await new DoctorsDal().AddOrUpdateAsync(entity);
			return entity.DoctorId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new DoctorsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(DoctorsSearchParams searchParams)
		{
			return new DoctorsDal().ExistsAsync(searchParams);
		}

		public Task<Doctor> GetAsync(int id)
		{
			return new DoctorsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new DoctorsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Doctor>> GetAsync(DoctorsSearchParams searchParams)
		{
			return new DoctorsDal().GetAsync(searchParams);
		}
	}
}

