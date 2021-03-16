using GraphQL;
using GraphQL.Types;
using GRAPHQLAPI_Examen.GraphQL.Types;
using GRAPHQLAPI_Examen.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.GraphQL
{
	public class NorthwindMutation : ObjectGraphType
	{
		public NorthwindMutation(ProductRepository productRepository, EmployeeRepository employeeRepository)
		{
			
		}
	}
	
}
