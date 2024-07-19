namespace service.CRM.Driven.Adapter.Data.Config;

public class DocumentDbConfiguration
{
    public string ConnectionString { get; set; }
    public string DefaultDatabase { get; set; }
    public string Parameters { get; set; }
    public string SecretName { get; set; }
}