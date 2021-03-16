using GRAPHQLAPI_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.Repositories
{
	public class ProductReviewRepository
	{
		private readonly CoreDbContext _dbContext;

		public ProductReviewRepository(CoreDbContext coreDbContext)
		{
			_dbContext = coreDbContext;
		}

		public async Task<IEnumerable<ProductReview>> GetForProduct(int productId)
		{
			return await _dbContext.ProductReviews.Where(pr => pr.ProductId == productId).ToListAsync();
		}

		public async Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds)
		{
			var reviews = await _dbContext.ProductReviews.Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();
			return reviews.ToLookup(r => r.ProductId);
		}

		public async Task<ProductReview> AddReview(ProductReview review)
		{
			_dbContext.ProductReviews.Add(review);
			await _dbContext.SaveChangesAsync();
			return review;
		}
	}
}
