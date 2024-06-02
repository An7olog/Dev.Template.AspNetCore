using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Patient = Entities.Patient;

namespace BL
{
	public class PatientsBL
	{
		public async Task<int> AddOrUpdateAsync(Patient entity)
		{
			entity.PatientId = await new PatientsDal().AddOrUpdateAsync(entity);
			return entity.PatientId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new PatientsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(PatientsSearchParams searchParams)
		{
			return new PatientsDal().ExistsAsync(searchParams);
		}

		public Task<Patient> GetAsync(int id)
		{
			return new PatientsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new PatientsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Patient>> GetAsync(PatientsSearchParams searchParams)
		{
			return new PatientsDal().GetAsync(searchParams);
		}
	}
}

