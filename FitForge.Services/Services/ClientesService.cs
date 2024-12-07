using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitForge.Services.Services;

public class ClientesService(IDbContextFactory<ApplicationDbContext> DbFactory) : IClientesService
{
	// Guardar
	public async Task<bool> Guardar(ClientesDto clienteDto)
	{
		if (!await Existe(clienteDto.ClienteId))
			return await Insertar(clienteDto);
		else
			return await Modificar(clienteDto);
	}

	// Existe
	private async Task<bool> Existe(int id)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Clientes
							  .AnyAsync(c => c.ClienteId == id);
	}

	// Insertar
	private async Task<bool> Insertar(ClientesDto clienteDto)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		// Verificar si el ApplicationUserId es válido
		var usuarioExiste = await _contexto.Users.AnyAsync(u => u.Id == clienteDto.UserId);
		if (!usuarioExiste)
		{
			throw new Exception("El usuario relacionado no existe en AspNetUsers.");
		}

		var cliente = new Clientes()
		{
			ClienteId = clienteDto.ClienteId,
			Nombres = clienteDto.Nombres,
			ApplicationUserId = clienteDto.UserId,
			Cedula = clienteDto.Cedula,
			FechaNacimiento = clienteDto.FechaNacimiento,
			Pin = clienteDto.Pin,
			UrlFotoPerfil = clienteDto.UrlFotoPerfil,

			// ESTE CODIGO ES DE PRUEBA NO ESTOY SEGURO PERO CREO QUE YA NO HAY QUE HACER
			// ESTO PORQUE PARA ESO LE HAREMOS SERVICIOS A INSCRIPCIONES, TARJETAS Y PAGOS

			//Inscripciones = clienteDto.Inscripciones
			//.Select(inscripcionesDto => new Inscripciones()
			//{
			//	InscripcionId = inscripcionesDto.InscripcionId,
			//})
			//Tarjetas = clienteDto.Tarjetas
			//.Select(tarjetasDto => new Tarjetas()
			//{
			//	TarjetaId = tarjetasDto.TarjetaId,
			//	NumeroTarjeta = tarjetasDto.NumeroTarjeta,
			//	FechaVencimiento = tarjetasDto.FechaVencimiento,
			//	Cvv = tarjetasDto.Cvv,
			//	Pagos = tarjetasDto.Pagos
			//	.Select(pagosDto => new Pagos()
			//	{
			//		PagoId = pagosDto.PagoId,
			//		FechaPago = pagosDto.FechaPago,
			//		Monto = pagosDto.Monto,
			//		FormasPagoId = pagosDto.FormaPago.FormasPagoId,
			//	}).ToList()
			//}).ToList()
		};
		_contexto.Clientes.Add(cliente);
		clienteDto.ClienteId = cliente.ClienteId;
		return await _contexto.SaveChangesAsync() > 0;
	}

	// Modificar
	private async Task<bool> Modificar(ClientesDto clienteDto)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var cliente = await _contexto.Clientes
			.Include(c => c.ApplicationUser)
			.FirstOrDefaultAsync(c => c.ClienteId == clienteDto.ClienteId);

		if (cliente == null)
			throw new KeyNotFoundException("El cliente no fue encontrado.");

		if (cliente.ApplicationUser == null)
			throw new KeyNotFoundException("El usuario asociado al cliente no fue encontrado.");

		cliente.Nombres = clienteDto.Nombres;
		cliente.Cedula = clienteDto.Cedula;
		cliente.FechaNacimiento = clienteDto.FechaNacimiento;
		cliente.UrlFotoPerfil = clienteDto.UrlFotoPerfil;
		cliente.ApplicationUser.Email = clienteDto.Email;
		cliente.ApplicationUser.PhoneNumber = clienteDto.Telefono;

		return await _contexto.SaveChangesAsync() > 0;
	}

	// Eliminar
	public async Task<bool> Eliminar(int id)
	{
		if (id <= 0)
			return false;

		await using var contexto = await DbFactory.CreateDbContextAsync();

		var existeCliente = await contexto.Clientes.AnyAsync(c => c.ClienteId == id);
		if (!existeCliente) return false;

		return await contexto.Clientes
			.Where(c => c.ClienteId == id)
			.ExecuteDeleteAsync() > 0;
	}


	// Buscar
	public async Task<ClientesDto> Buscar(int id)
	{
		if (id <= 0)
			return new ClientesDto();

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		var registroEncontrado = await _contexto.Clientes
			.Where(x => x.ClienteId == id)
			.Select(x => new ClientesDto
			{
				ClienteId = x.ClienteId,
				Nombres = x.Nombres,
				Email = x.ApplicationUser.Email,
				Telefono = x.ApplicationUser.PhoneNumber,
				UserId = x.ApplicationUserId,
				Cedula = x.Cedula,
				Pin = x.Pin,
			})
			.FirstOrDefaultAsync();
		return registroEncontrado ?? new ClientesDto();
	}

	// Listar
	public async Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var clientesDto = await _contexto.Clientes
			.AsNoTracking()
			.Select(x => new ClientesDto
			{
				ClienteId = x.ClienteId,
				Email = x.ApplicationUser.Email,
				Telefono = x.ApplicationUser.PhoneNumber,
				UserId = x.ApplicationUserId,
				Cedula = x.Cedula,
				Nombres = x.Nombres,
				FechaNacimiento = x.FechaNacimiento,
				Pin = x.Pin,
				UrlFotoPerfil = x.UrlFotoPerfil,
			})
			.Where(criterio)
			.ToListAsync();

		return clientesDto;
	}

	// Validar Cedula
	public async Task<bool> ValidarCedula(string cedula)
	{
		if (cedula.Length != 11)
			return false;

		if (await ExisteCedula(cedula))
			return false;

		int[] pesos = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
		int suma = 0;

		for (int i = 0; i < 10; i++)
		{
			int multiplicacion = (cedula[i] - '0') * pesos[i]; // Convertir carácter a número y multiplicar
			if (multiplicacion >= 10)
			{
				// Sumar los dígitos de un número mayor o igual a 10
				multiplicacion = (multiplicacion / 10) + (multiplicacion % 10);
			}
			suma += multiplicacion;
		}

		int decenaSuperior = (int)Math.Ceiling(suma / 10.0) * 10; // Calcular la decena superior más cercana
		int digitoVerificadorCalculado = decenaSuperior - suma;

		int digitoVerificadorReal = cedula[10] - '0'; // Último dígito de la cédula

		return digitoVerificadorCalculado == digitoVerificadorReal ? true : false;
	}

	private async Task<bool> ExisteCedula(string cedula)
	{
		if (string.IsNullOrWhiteSpace(cedula))
			return true;

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Clientes.AnyAsync(c => c.Cedula == cedula);

	}
}
