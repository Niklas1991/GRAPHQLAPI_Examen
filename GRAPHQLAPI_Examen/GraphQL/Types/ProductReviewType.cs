using GraphQL.Types;
using GRAPHQLAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.GraphQL.Types
{
	public class ProductReviewType: ObjectGraphType<ProductReview>
	{
		public ProductReviewType()
		{
			Field(t => t.Id);
			Field(t => t.Title);
			Field(t => t.Review);
		}
	}
}
