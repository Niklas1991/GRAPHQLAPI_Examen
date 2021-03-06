using GraphQL.Types;
using GRAPHQLAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.GraphQL.Types
{
	public class EmployeeType : ObjectGraphType<Employee>
	{
		public EmployeeType()
		{
			Name = "Employees";
			Field(t => t.EmployeeId, type: typeof(IdGraphType));
			Field(t => t.FirstName, type: typeof(StringGraphType));
			Field(t => t.LastName, type: typeof(StringGraphType));
			Field(t => t.Title, type: typeof(StringGraphType));
			Field(t => t.TitleOfCourtesy, type: typeof(StringGraphType));
			Field(t => t.BirthDate, type: typeof(DateTimeGraphType));
			Field(t => t.HireDate, type: typeof(DateTimeGraphType));
			Field(t => t.Address, type: typeof(StringGraphType));
			Field(t => t.City, type: typeof(StringGraphType));
			Field(t => t.Region, type: typeof(StringGraphType));
			Field(t => t.PostalCode, type: typeof(StringGraphType));
			Field(t => t.Country, type: typeof(StringGraphType));
			Field(t => t.HomePhone, type: typeof(StringGraphType));
			Field(t => t.Extension, type: typeof(StringGraphType));
			Field(t => t.Photo, type: typeof(StringGraphType));
			Field(t => t.Notes, type: typeof(StringGraphType));
			Field(t => t.PhotoPath, type: typeof(StringGraphType));
		}
	}
}
