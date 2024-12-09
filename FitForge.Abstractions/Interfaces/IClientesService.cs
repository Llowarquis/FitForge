using FitForge.Domain.DTO;
using System.Linq.Expressions;

namespace FitForge.Abstractions.Interfaces;

public interface IClientesService
{
	public Task<bool> Guardar(ClientesDto clienteDto);
	public Task<bool> Eliminar(int id);
	public Task<ClientesDto> Buscar(int id);
	public Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio);
    Task<List<ClientesDto>> ObtenerClientes();

    Task<ClientesDto?> ObtenerClientePorId(int clienteId);

    Task<int?> ObtenerClienteIdPorEmail(string email);
}
