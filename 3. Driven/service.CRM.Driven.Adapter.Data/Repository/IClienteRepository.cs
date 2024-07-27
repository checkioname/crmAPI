using service.CRM.Core.Domain.Entities;

namespace service.CRM.Driven.Adapter.Data.Collections;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> FindAll();

    Task createCliente(Cliente cliente);
}