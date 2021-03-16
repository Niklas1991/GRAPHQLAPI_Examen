using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GRAPHQLAPI_Examen.GraphQL
{
	public class NorthwindSchema: Schema
	{
		public NorthwindSchema(IServiceProvider serviceProvider) : base(serviceProvider)
		{
			Query = serviceProvider.GetRequiredService<NorthwindQuery>();
			//Mutation
			//Subscription			
		}
	}
}
