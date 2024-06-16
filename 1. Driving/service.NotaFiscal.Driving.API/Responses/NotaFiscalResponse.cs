namespace service.NotaFiscal.Driving.API.Responses
{
    public class NotaFiscalResponse
    {
        public long NumeroNotaFiscal { get; set; }
        public string Nome { get; set; }
        public string EmpresaContribuinte { get; set; }

        public NotaFiscalResponse(long numeroNotaFiscal, string nome, string empresa)
        {
            NumeroNotaFiscal = numeroNotaFiscal;
            Nome = nome;
            EmpresaContribuinte = empresa;
        }
    }
}