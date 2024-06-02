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
	public class DoctorsDal : BaseDal<DefaultDbContext, Doctor, Entities.Doctor, int, DoctorsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public DoctorsDal()
		{
		}

		protected internal DoctorsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Doctor entity, Doctor dbObject, bool exists)
		{
			dbObject.DoctorId = entity.DoctorId;
			dbObject.FirstName = entity.FirstName;
			dbObject.LastName = entity.LastName;
			dbObject.Specialization = entity.Specialization;
			dbObject.DepartmentId = entity.DepartmentId;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Doctor>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Doctor> dbObjects, DoctorsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Doctor>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Doctor> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Doctor, int>> GetIdByDbObjectExpression()
		{
			return item => item.DoctorId;
		}

		protected override Expression<Func<Entities.Doctor, int>> GetIdByEntityExpression()
		{
			return item => item.DoctorId;
		}

		internal static Entities.Doctor ConvertDbObjectToEntity(Doctor dbObject)
		{
			return dbObject == null ? null : new Entities.Doctor(dbObject.DoctorId, dbObject.FirstName,
				dbObject.LastName, dbObject.Specialization, dbObject.DepartmentId);
		}
	}
}
