using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DepartmentModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "DepartmentId")]
		public int DepartmentId { get; set; }

		[Display(Name = "DepartmentName")]
		public string DepartmentName { get; set; }

		public static DepartmentModel FromEntity(Department obj)
		{
			return obj == null ? null : new DepartmentModel
			{
				DepartmentId = obj.DepartmentId,
				DepartmentName = obj.DepartmentName,
			};
		}

		public static Department ToEntity(DepartmentModel obj)
		{
			return obj == null ? null : new Department(obj.DepartmentId, obj.DepartmentName);
		}

		public static List<DepartmentModel> FromEntitiesList(IEnumerable<Department> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Department> ToEntitiesList(IEnumerable<DepartmentModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
