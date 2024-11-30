using FitForge.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitForge.Data.DI;

public static class DbContextRegister
{
	public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
	{
		
		services.AddDbContextFactory<ApplicationDbContext>(x => x.UseSqlServer("Name=SqlConStr"));
		return services;
	}
}
