using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }

		public Department(int departmentId, string departmentName)
		{
			DepartmentId = departmentId;
			DepartmentName = departmentName;
		}
	}
}
