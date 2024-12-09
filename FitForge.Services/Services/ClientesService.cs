using BlazorBootstrap;
using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Domain.DTO;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

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
			Email = clienteDto.Email,
			ApplicationUserId = clienteDto.UserId,
			Cedula = clienteDto.Cedula,
			FechaNacimiento = clienteDto.FechaNacimiento,
			Pin = clienteDto.Pin,
			UrlFotoPerfil = clienteDto.UrlFotoPerfil,
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
		cliente.Email = clienteDto.Email;
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

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		var cliente = await _contexto.Clientes
			.FirstOrDefaultAsync(x => x.ClienteId == id);

		if (cliente == null) return false;

		_contexto.Clientes.Remove(cliente);
		return await _contexto.SaveChangesAsync() > 0;
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
				UrlFotoPerfil = x.UrlFotoPerfil,
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
	public async Task<string> ValidarCedula(string cedula)
	{
		if (cedula.Length != 11)
			return "muyLarga";

		if (await ExisteCedula(cedula))
			return "yaExiste";

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

		if (digitoVerificadorCalculado != digitoVerificadorReal)
			return "noValida";
		return "valida";
	}

	// Existe la cedula??
	private async Task<bool> ExisteCedula(string cedula)
	{
		if (string.IsNullOrWhiteSpace(cedula))
			return true;

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Clientes.AnyAsync(c => c.Cedula == cedula);

	}


	// Validar numero telefono
	public async Task<bool> ValidarTelefono(string telefono)
	{
		await ExisteTelefono(telefono);

		string pattern = @"^[(]?[0-9]{0,9}[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}[)]?$";
		Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

		return regex.IsMatch(telefono);
	}

	private async Task<bool> ExisteTelefono(string telefono)
	{
		if (string.IsNullOrWhiteSpace(telefono))
			return true;

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Users.AnyAsync(c => c.PhoneNumber == telefono);
	}

    public async Task<List<ClientesDto>> ObtenerClientes()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Clientes
            .Select(c => new ClientesDto()
            {
                ClienteId = c.ClienteId,
                Nombres = c.Nombres,
            })
            .AsNoTracking().ToListAsync();
    }

    public async Task<ClientesDto?> ObtenerClientePorId(int clienteId)
    {
        try
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            var cliente = await _contexto.Clientes
                .Where(c => c.ClienteId == clienteId)
                .Select(c => new ClientesDto
                {
                    ClienteId = c.ClienteId,
                    Nombres = c.Nombres,
                })

                .FirstOrDefaultAsync();

            return cliente;
        }
        catch (Exception ex)
        {
            // Manejo de errores (puedes agregar logs aquí)
            Console.WriteLine($"Error al obtener cliente: {ex.Message}");
            return null;
        }
    }



    private readonly IWebHostEnvironment _webHostEnvironment;

    // Método para guardar la URL de la imagen de perfil en la base de datos
    public async Task<bool> GuardarUrlFotoPerfil(ClientesDto clienteDto, IBrowserFile file)
    {
        // Subir la imagen al servidor y obtener la URL
        var urlImagen = await SubirImagenAsync(file);

        if (!string.IsNullOrEmpty(urlImagen))
        {
            // Guardar la URL de la imagen en la base de datos
            await using var _contexto = await DbFactory.CreateDbContextAsync();
            var cliente = await _contexto.Clientes
                                         .FirstOrDefaultAsync(c => c.ClienteId == clienteDto.ClienteId);

            if (cliente != null)
            {
                cliente.UrlFotoPerfil = urlImagen;
                _contexto.Clientes.Update(cliente);
                return await _contexto.SaveChangesAsync() > 0;
            }
        }
        return false;
    }

    // Método para subir la imagen al servidor y generar una URL accesible
    private async Task<string> SubirImagenAsync(IBrowserFile file)
    {
        if (file == null) return string.Empty;

        // Ruta donde se almacenarán las imágenes
        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "uploads");
        Directory.CreateDirectory(uploadsFolder);  // Asegúrate de que la carpeta exista

        // Nombre único para evitar sobrescribir imágenes existentes
        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Guardar el archivo
        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.OpenReadStream().CopyToAsync(stream);
        }

        // Devolver la URL accesible
        return $"/images/uploads/{uniqueFileName}";
    }

    public async Task<int?> ObtenerClienteIdPorEmail(string email)
    {
        try
        {
            await using var _contexto = await DbFactory.CreateDbContextAsync();

            var clienteId = await _contexto.Clientes
                .Where(c => c.Email == email)
                .Select(c => c.ClienteId)
                .FirstOrDefaultAsync();

            return clienteId == 0 ? null : clienteId; // Retorna null si no se encuentra el cliente
        }
        catch (Exception ex)
        {
            // Manejo de errores (puedes agregar logs aquí)
            Console.WriteLine($"Error al obtener ClienteId por email: {ex.Message}");
            return null;
        }
    }
}
