using service.CRM.Core.Domain.Entities;
using service.CRM.Core.Domain.Enums;

namespace service.CRM.Driving.API.Requests;

public class ClienteRequest
{
    private string Nome;
    private string Cpf;
    private string Rg;
    private DateTime DataNascimento;
    private Servicos servico;
    private Endereco endereco;
}