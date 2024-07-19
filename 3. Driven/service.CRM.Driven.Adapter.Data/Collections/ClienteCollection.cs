namespace service.CRM.Driven.Adapter.Data.Collections;

public class ClienteCollection
{
    public string _id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string rg { get; set; }
    public string orgaoEmissor { get; set; }
    public string cnh { get; set; }
    public string dataNascimento { get; set; }
    public string servicoContratado { get; set; }
    public string endereco { get; set; }
    public List<int> celulares { get; set; }
    public string statusPagamento { get; set; }
    public string laudoEspecificar { get; set; }
}