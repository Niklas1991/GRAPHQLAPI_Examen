using GraphQL.DataLoader;
using GraphQL.Language.AST;
using GraphQL.Types;
using GRAPHQLAPI_Examen.Models;
using GRAPHQLAPI_Examen.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.GraphQL.Types
{
	public class ProductType: ObjectGraphType<Product>
	{
		public ProductType(ProductReviewRepository reviewRepository)
		{
			Name = "Products";
			Field(t => t.ProductId, type: typeof(IdGraphType));
			Field(t => t.ProductName, type: typeof(StringGraphType)).Description("The name of the product");			
			Field(t => t.QuantityPerUnit, type: typeof(StringGraphType));
			Field(t => t.UnitPrice, nullable: true, type: typeof(DecimalGraphType));
			Field(t => t.UnitsInStock, nullable: true, type: typeof(ShortGraphType));
			Field(t => t.UnitsOnOrder, nullable: true, type: typeof(ShortGraphType));
			Field(t => t.ReorderLevel, nullable: true, type: typeof(ShortGraphType));
			Field(t => t.Discontinued, type: typeof(BooleanGraphType));
			Field<ListGraphType<ProductReviewType>>(
				"reviews",
				resolve: context => reviewRepository.GetForProduct(context.Source.ProductId)
				);
		}
	}
}
