using DimDim.Infra.Data;
using DimDim.Infra.Repositories;
using DimDim.Repositories;
using DimDim.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DimDim.Web
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
						builder => 
						{
							builder.AllowAnyHeader();
							builder.AllowAnyMethod();
							builder.AllowAnyOrigin();
							builder.AllowCredentials();
						});
			}
				);

			services.AddMvc(options =>
			{
				options.InputFormatters.Add(new XmlSerializerInputFormatter());
				options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
				options.RespectBrowserAcceptHeader = true;
				
			}
				);

			services.AddDbContext<DimDimDbContext>(options => options.UseSqlServer(
				"Server=(localdb)\\mssqllocaldb;Database=DimDim;Trusted_Connection=True;MultipleActiveResultSets=true",
				b => b.MigrationsAssembly("DimDim.Web")
				));
			services.AddScoped<IDespesaService, DespesaService>();
			services.AddScoped<IDespesaRepository, DespesaRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("AllowAll");
			app.UseMvcWithDefaultRoute();
		}
	}
}
