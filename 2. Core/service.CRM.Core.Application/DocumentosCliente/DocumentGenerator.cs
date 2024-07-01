using DocumentFormat.OpenXml.Packaging;
using service.CRM.Core.Domain.Entities;
using DocumentFormat.OpenXml.Wordprocessing;

namespace service.CRM.Core.Application.DocumentosCliente;

public class DocumentGenerator
{
    public void SubstituirPlaceholders(string caminhoArquivo, Cliente cliente)
    {
        // Abrir o arquivo .docx
        using (WordprocessingDocument doc = WordprocessingDocument.Open(caminhoArquivo, false))
        {
            File.Copy(caminhoArquivo, caminhoArquivo + "/" + cliente.Nome, true);

            using (WordprocessingDocument docNovo = WordprocessingDocument.Open(caminhoArquivo + "/" + cliente.Nome, true))
            {
                var body = doc.MainDocumentPart.Document.Body;

                // Obter todos os elementos de texto no corpo do documento
                var textElements = body.Descendants<Text>();

                foreach (var text in textElements)
                {
                    string texto = text.Text;
                    if (texto.Contains("{{"))
                    {
                        // Substituir cada placeholder pelo valor correspondente do modelo Cliente
                        texto = texto.Replace("{{Nome Completo}}", cliente.Nome)
                            .Replace("{{CPF}}", cliente.Cpf)
                            .Replace("{{RG}}", cliente.Rg)
                            .Replace("{{Órgão Emissor}}", cliente.OrgaoEmissor)
                            .Replace("{{Endereço}}", cliente.endereco.Rua)
                            .Replace("{{Número}}", cliente.endereco.Numero.ToString())
                            .Replace("{{Complemento}}", cliente.endereco.Complemento)
                            .Replace("{{Bairro}}", cliente.endereco.Bairro)
                            .Replace("{{Município}}", cliente.endereco.Municipio)
                            .Replace("{{CEP}}", cliente.endereco.Cep)
                            .Replace("{{Estado}}", cliente.endereco.Estado);
                        // Aplicar o texto modificado de volta ao elemento Text
                        text.Text = texto;
                    }
                }
            docNovo.Save();
            }

        }
    }
}