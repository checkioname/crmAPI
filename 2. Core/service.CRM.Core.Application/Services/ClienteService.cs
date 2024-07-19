using service.CRM.Core.Application.DocumentosCliente;
using service.CRM.Core.Domain.Entities;
using service.CRM.Driven.Adapter.Data.Collections;
using service.CRM.Driven.Adapter.Data.Connections;

namespace service.CRM.Core.Application.Services;

public class ClienteService
{
    private DocumentGenerator _docGenerator = new();
    private ClienteRepository _clienteRepository;
    
    //Deve cadastrar um cliente no banco

    public async Task CadastrarCliente(Cliente cliente)
    {
        try
        {

            //_clienteRepo.CadastraCliente(cliente);
            string absPath = "Utils/DocumentsTemplates/PROCURAÇÃO-sistema.docx";
            string newFilePath = $"Utils/DocumentsTemplates/{cliente.Nome}.docx";
            _docGenerator.GerarDocumento(absPath, newFilePath, cliente);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}