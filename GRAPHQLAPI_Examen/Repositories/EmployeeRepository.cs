using GRAPHQLAPI_Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRAPHQLAPI_Examen.Repositories
{
	public class EmployeeRepository
	{
		private readonly CoreDbContext _dbContext;

		public EmployeeRepository(CoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Employee>> GetAllEmployees()
		{
			return await _dbContext.Employees.ToListAsync();
		}
		public async Task<Employee> GetOneEmployee(int id)
		{
			return await _dbContext.Employees.SingleOrDefaultAsync(c => c.EmployeeId == id);
		}
	}
}
