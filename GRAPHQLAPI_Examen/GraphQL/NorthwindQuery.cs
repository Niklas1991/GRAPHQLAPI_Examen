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
	public class NorthwindQuery: ObjectGraphType
	{
		public NorthwindQuery(ProductRepository productRepository, EmployeeRepository employeeRepository)
		{
			FieldAsync<ListGraphType<ProductType>>(
				"products",
				resolve: async context => await productRepository.GetAllProducts()
				);
			FieldAsync<ProductType>(
				"product",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
				resolve: async context =>
				{
					var id = context.GetArgument<int>("id");
					return await productRepository.GetOneProduct(id);
				}
				);
			FieldAsync<ListGraphType<EmployeeType>>(
				"employees",
				resolve: async context => await employeeRepository.GetAllEmployees()
				);
			FieldAsync<EmployeeType>(
				"employee",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
				resolve: async context =>
				{
					var id = context.GetArgument<int>("id");
					return await employeeRepository.GetOneEmployee(id);
				}
				);
		}
	}
}
