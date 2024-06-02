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
	public class AppointmentsDal : BaseDal<DefaultDbContext, Appointment, Entities.Appointment, int, AppointmentsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public AppointmentsDal()
		{
		}

		protected internal AppointmentsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Appointment entity, Appointment dbObject, bool exists)
		{
			dbObject.AppointmentId = entity.AppointmentId;
			dbObject.PatientId = entity.PatientId;
			dbObject.DoctorId = entity.DoctorId;
			dbObject.AppointmentDate = entity.AppointmentDate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Appointment>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Appointment> dbObjects, AppointmentsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Appointment>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Appointment> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Appointment, int>> GetIdByDbObjectExpression()
		{
			return item => item.AppointmentId;
		}

		protected override Expression<Func<Entities.Appointment, int>> GetIdByEntityExpression()
		{
			return item => item.AppointmentId;
		}

		internal static Entities.Appointment ConvertDbObjectToEntity(Appointment dbObject)
		{
			return dbObject == null ? null : new Entities.Appointment(dbObject.AppointmentId, dbObject.PatientId,
				dbObject.DoctorId, dbObject.AppointmentDate);
		}
	}
}
