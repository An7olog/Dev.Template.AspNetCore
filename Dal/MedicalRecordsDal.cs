using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class MedicalRecordsDal : BaseDal<DefaultDbContext, MedicalRecord, Entities.MedicalRecord, int, MedicalRecordsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public MedicalRecordsDal()
		{
		}

		protected internal MedicalRecordsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.MedicalRecord entity, MedicalRecord dbObject, bool exists)
		{
			dbObject.RecordId = entity.RecordId;
			dbObject.PatientId = entity.PatientId;
			dbObject.RecordDate = entity.RecordDate;
			dbObject.RecordDetails = entity.RecordDetails;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<MedicalRecord>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<MedicalRecord> dbObjects, MedicalRecordsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.MedicalRecord>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<MedicalRecord> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<MedicalRecord, int>> GetIdByDbObjectExpression()
		{
			return item => item.RecordId;
		}

		protected override Expression<Func<Entities.MedicalRecord, int>> GetIdByEntityExpression()
		{
			return item => item.RecordId;
		}

		internal static Entities.MedicalRecord ConvertDbObjectToEntity(MedicalRecord dbObject)
		{
			return dbObject == null ? null : new Entities.MedicalRecord(dbObject.RecordId, dbObject.PatientId,
				dbObject.RecordDate, dbObject.RecordDetails);
		}
	}
}
