using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Department = Entities.Department;

namespace BL
{
	public class DepartmentsBL
	{
		public async Task<int> AddOrUpdateAsync(Department entity)
		{
			entity.DepartmentId = await new DepartmentsDal().AddOrUpdateAsync(entity);
			return entity.DepartmentId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new DepartmentsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(DepartmentsSearchParams searchParams)
		{
			return new DepartmentsDal().ExistsAsync(searchParams);
		}

		public Task<Department> GetAsync(int id)
		{
			return new DepartmentsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new DepartmentsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Department>> GetAsync(DepartmentsSearchParams searchParams)
		{
			return new DepartmentsDal().GetAsync(searchParams);
		}
	}
}

