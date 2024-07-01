namespace service.CRM.Driving.API.Responses;

public class ClienteResponse
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public DateTime DataNascimento;
    //public Servicos ServicoContratado;
    public string StatusPagamento;
}