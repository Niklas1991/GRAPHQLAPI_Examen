using GRAPHQLAPI_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.Repositories
{
	public class ProductRepository
	{
		private readonly CoreDbContext _dbContext;

		public ProductRepository(CoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Product>> GetAllProducts()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<Product> GetOneProduct(int id)
		{
			return await _dbContext.Products.SingleOrDefaultAsync(c => c.ProductId == id);
		}
	}
}
