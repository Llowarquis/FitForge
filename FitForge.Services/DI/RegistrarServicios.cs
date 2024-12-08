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
        servicios.AddScoped<IClientesService, ClientesService>();
        servicios.AddScoped<ClientesService>();
        servicios.AddScoped<IPagosService, PagosService>();
        servicios.AddScoped<IEstadoMembresiasService, EstadosMembresiasService>();
        servicios.AddScoped<IMembresiasService, MembresiasService>();
        servicios.AddScoped<EntrenadoresService>();
        servicios.AddScoped<ITarjetasService, TarjetasService>();
        servicios.AddScoped<IItinerariosService, ItinerariosService>();
        servicios.AddScoped<IClasesService, ClasesService>();
        servicios.AddScoped<IInscripcionesService, InscripcionesService>();
        servicios.AddScoped<IEntrenadoresService, EntrenadoresService>();
        servicios.AddScoped<IDiasHorariosService, DiasHorariosService>();
        servicios.AddBlazorBootstrap();
        servicios.AddSingleton<ToastService>();
        return servicios;
    }
}
