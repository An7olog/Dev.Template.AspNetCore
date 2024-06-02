using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using MedicalRecord = Entities.MedicalRecord;

namespace BL
{
	public class MedicalRecordsBL
	{
		public async Task<int> AddOrUpdateAsync(MedicalRecord entity)
		{
			entity.RecordId = await new MedicalRecordsDal().AddOrUpdateAsync(entity);
			return entity.RecordId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new MedicalRecordsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(MedicalRecordsSearchParams searchParams)
		{
			return new MedicalRecordsDal().ExistsAsync(searchParams);
		}

		public Task<MedicalRecord> GetAsync(int id)
		{
			return new MedicalRecordsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new MedicalRecordsDal().DeleteAsync(id);
		}

		public Task<SearchResult<MedicalRecord>> GetAsync(MedicalRecordsSearchParams searchParams)
		{
			return new MedicalRecordsDal().GetAsync(searchParams);
		}
	}
}

