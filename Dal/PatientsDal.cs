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
	public class PatientsDal : BaseDal<DefaultDbContext, Patient, Entities.Patient, int, PatientsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public PatientsDal()
		{
		}

		protected internal PatientsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Patient entity, Patient dbObject, bool exists)
		{
			dbObject.PatientId = entity.PatientId;
			dbObject.FirstName = entity.FirstName;
			dbObject.LastName = entity.LastName;
			dbObject.DateOfBirth = entity.DateOfBirth;
			dbObject.Gender = entity.Gender;
			dbObject.Address = entity.Address;
			dbObject.PhoneNumber = entity.PhoneNumber;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Patient>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Patient> dbObjects, PatientsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Patient>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Patient> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Patient, int>> GetIdByDbObjectExpression()
		{
			return item => item.PatientId;
		}

		protected override Expression<Func<Entities.Patient, int>> GetIdByEntityExpression()
		{
			return item => item.PatientId;
		}

		internal static Entities.Patient ConvertDbObjectToEntity(Patient dbObject)
		{
			return dbObject == null ? null : new Entities.Patient(dbObject.PatientId, dbObject.FirstName,
				dbObject.LastName, dbObject.DateOfBirth, dbObject.Gender, dbObject.Address, dbObject.PhoneNumber);
		}
	}
}
