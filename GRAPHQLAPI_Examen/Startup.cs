using GraphQL;
using GRAPHQLAPI_Examen.GraphQL;
using GRAPHQLAPI_Examen.Models;
using GRAPHQLAPI_Examen.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Collections.Generic;
using System;

namespace GRAPHQLAPI_Examen
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddDbContext<CoreDbContext>(options =>
				options.UseSqlServer(Configuration["ConnectionStrings:Database"]), ServiceLifetime.Transient);
			services.AddScoped<ProductRepository>();
			services.AddScoped<EmployeeRepository>();
			services.AddScoped<ProductReviewRepository>();

			services.AddScoped<NorthwindSchema>();

			services.AddGraphQL()
				.AddSystemTextJson(o => o.PropertyNameCaseInsensitive = true)			
				.AddGraphTypes(ServiceLifetime.Scoped)
				.AddUserContextBuilder(httpContext => new Dictionary<string, object> { { "User", httpContext.User } })
				.AddDataLoader()
				.AddWebSockets();
			services.AddGraphQL(options =>
			{
				options.EnableMetrics = false;

			}).AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
			.AddWebSockets()
			.AddDataLoader()
			.AddGraphTypes(typeof(NorthwindSchema));

			services.AddCors();
			services.Configure<KestrelServerOptions>(options =>
			{
				options.AllowSynchronousIO = false;
			});
			

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			app.UseCors(builder =>
				builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseWebSockets();
			app.UseGraphQLWebSockets<NorthwindSchema>("/graphql");
			app.UseGraphQL<NorthwindSchema>();			
			app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());		
			
		}
	}
}
