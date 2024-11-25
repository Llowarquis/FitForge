using FitForge.Abstractions.Interfaces;
using FitForge.Data.DI;
using FitForge.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitForge.Services.DI;

public static class RegistrarServicios
{
	public static IServiceCollection InyectarServicios(this IServiceCollection servicios)
	{
		servicios.RegisterDbContextFactory();
		servicios.AddScoped<IClientesService, ClientesService>();
		servicios.AddScoped<IPagosService, PagosService>();
		servicios.AddScoped<IEmpleadosService, EmpleadosService>();
		servicios.AddScoped<IUsuariosService, UsuariosService>();
		servicios.AddScoped<ITarjetasService, TarjetasService>();
		return servicios;
	}
}
