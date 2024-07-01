using service.CRM.Core.Application.DocumentosCliente;
using service.CRM.Core.Domain.Entities;

namespace service.CRM.Core.Application.Services;

public class ClienteService
{
    private DocumentGenerator _docGenerator = new();
    //Deve cadastrar um cliente no banco

    public async Task CadastrarCliente(Cliente cliente)
    {
        try
        {
            //_clienteRepo.CadastraCliente(cliente);
            string absPath =
                "/home/king/Documents/Personal Projects/AtibaiaIsencoes/2. Core/service.CRM.Core.Application/DocumentsTemplate/PROCURAÇÃO-sistema.docx"; 
            _docGenerator.SubstituirPlaceholders(absPath, cliente);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    //Deve Gerar um contrato para o cliente quando cadastar-lo
    public async Task GerarContratos(Cliente cliente)
    {
        
    }
}