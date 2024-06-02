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
	public class DepartmentsDal : BaseDal<DefaultDbContext, Department, Entities.Department, int, DepartmentsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public DepartmentsDal()
		{
		}

		protected internal DepartmentsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Department entity, Department dbObject, bool exists)
		{
			dbObject.DepartmentId = entity.DepartmentId;
			dbObject.DepartmentName = entity.DepartmentName;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Department>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Department> dbObjects, DepartmentsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Department>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Department> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Department, int>> GetIdByDbObjectExpression()
		{
			return item => item.DepartmentId;
		}

		protected override Expression<Func<Entities.Department, int>> GetIdByEntityExpression()
		{
			return item => item.DepartmentId;
		}

		internal static Entities.Department ConvertDbObjectToEntity(Department dbObject)
		{
			return dbObject == null ? null : new Entities.Department(dbObject.DepartmentId, dbObject.DepartmentName);
		}
	}
}
