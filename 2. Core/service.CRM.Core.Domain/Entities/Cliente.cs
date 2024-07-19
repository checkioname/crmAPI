using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using service.CRM.Core.Domain.Enums;

namespace service.CRM.Core.Domain.Entities;

public class Cliente
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id;
    
    [BsonElement("Name")]
    public string Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Rg { get; set; }
    
    public string? OrgaoEmissor { get; set; }
    
    public Cnh? Cnh { get; set; }
    public string DataNascimento { get; set; }
    public Servicos? ServicoContratado { get; set; }
    public Endereco? endereco { get; set; }
    public List<int> Celulares { get; set; }
    public string StatusPagamento { get; set; }
    public string LaudoEspecificar { get; set; }

    //public IFormFile Contrato;

    //public IFormFile Procuracao;
    
    //public IFormFile RelacaoCondutores; 

    //public List<IFormFile> DocumentosAdicionais;

}