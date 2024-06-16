namespace service.NotaFiscal.Core.Domain.Entities;

public class NotaFiscal
{
    private long Id;
    private long NumeroNotaFiscal;
    public string Nome;
    public string EmpresaContribuinte;
    private string LocalVenda;
    private string Comprador;
    public string ProdutoVendido;
    public DateTime DataHoraVenda;
    public double impostos;
    public string Transportadora;

    public NotaFiscal(string nome, string  empresa)
    {
        this.Nome = nome;
        this.EmpresaContribuinte = empresa;
    }
}