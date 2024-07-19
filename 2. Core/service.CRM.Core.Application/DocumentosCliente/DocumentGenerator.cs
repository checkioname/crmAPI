using System.Text;
using System.Text.RegularExpressions;
using service.CRM.Core.Domain.Entities;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace service.CRM.Core.Application.DocumentosCliente
{
    public class DocumentGenerator
    {
        static readonly Regex pattern = new Regex(@"\{{(\w+)\}}", RegexOptions.Compiled);

        public void GerarDocumento(string caminhoTemplate, string caminhoNovoDocumento, Cliente cliente)
        {
            // Ler o conteúdo do template original
            string docText;

            using (DocX document = DocX.Load(caminhoTemplate))
            {
                document.ReplaceText(new StringReplaceTextOptions() { SearchValue = "{{Nome Completo}}", NewValue= cliente.Nome });
                document.ReplaceText(new StringReplaceTextOptions() { SearchValue = "{{CPF}}", NewValue= cliente.Cpf });
                document.ReplaceText(new StringReplaceTextOptions() { SearchValue = "{{RG}}", NewValue= cliente.Rg });
                
                document.SaveAs(caminhoNovoDocumento);
            }
        }
    }
}