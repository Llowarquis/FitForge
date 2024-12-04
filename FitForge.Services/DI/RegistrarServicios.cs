using BlazorBootstrap;
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
		servicios.AddScoped<ClientesService>();
		servicios.AddScoped<IPagosService, PagosService>();
		servicios.AddScoped<EntrenadoresService>();
		servicios.AddScoped<ITarjetasService, TarjetasService>();
		servicios.AddBlazorBootstrap();
		servicios.AddSingleton<ToastService>();
		return servicios;
	}
}
