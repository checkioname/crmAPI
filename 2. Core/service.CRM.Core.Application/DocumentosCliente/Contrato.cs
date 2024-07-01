using service.CRM.Core.Domain.Entities;

namespace service.CRM.Core.Application.DocumentosCliente;

public class Contrato
{
    public Cliente cliente;
    
    public void ContratoResponse(Cliente cliente)
    {
        var replacement = "criar um dicionario que mapeia os replaces";
        
        StreamReader reader = new StreamReader("2. Core/service.CRM.Core.Application/DocumentosCliente/PROCURAÇÃO-sistema.docx");
        
        string input = reader.ReadToEnd();

        using (StreamWriter writer = new StreamWriter("2. Core/service.CRM.Core.Application/DocumentosCliente/PROCURAÇÃO-sistema.docx", true))
        {
            {
                string output = input.Replace(cliente.Nome, replacement);
                writer.Write(output);                     
            }
            writer.Close();
        }
    }
}