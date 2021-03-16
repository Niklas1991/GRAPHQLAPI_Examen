using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.GraphQL.Types
{
	public class ProductInputType : InputObjectGraphType
	{
		public ProductInputType()
		{
			Name = "productInput";
			Field<NonNullGraphType<StringGraphType>>("productname");
			Field<NonNullGraphType<IntGraphType>>("productid");
		}
	}
}
