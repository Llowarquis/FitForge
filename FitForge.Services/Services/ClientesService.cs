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

        var cliente = await _contexto.Clientes.FindAsync(clienteDto.ClienteId);
        if (cliente == null)
            throw new KeyNotFoundException("El cliente no fue encontrado.");

        cliente.Nombres = clienteDto.Nombres;
        cliente.Cedula = clienteDto.Cedula;
        cliente.FechaNacimiento = clienteDto.FechaNacimiento;
        cliente.UrlFotoPerfil = clienteDto.UrlFotoPerfil;

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

    //Listar Usuarios con rol de cliente
    //   public async Task<List<ApplicationUser>> ListarUsers(Expression<Func<ApplicationUser, bool>> criterio)
    //   {
    //       await using var _contexto = await DbFactory.CreateDbContextAsync();

    //	var userIdConRolCliente = await _contexto.UserRoles
    //		.Where(user => user.RoleId.StartsWith("cba"))
    //		.Select(user => user.UserId)
    //		.ToListAsync();

    //	return await _contexto.Users
    //		.AsNoTracking()
    //		.Where(user => userIdConRolCliente.Contains(user.Id))
    //		.Where(criterio)
    //		.ToListAsync();
    //}

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

}
