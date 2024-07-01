using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using service.CRM.Core.Application.Services;
using service.CRM.Core.Domain.Entities;
using service.CRM.Core.Domain.Enums;
using service.CRM.Driven.Adapter.Data.Data;
using service.CRM.Driving.API.Requests;
using service.CRM.Driving.API.Responses;

namespace service.CRM.Driving.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private ClienteService _clienteService = new ClienteService();
    private readonly IMongoCollection<Cliente> _cliente;
    
    [HttpGet]
    public ActionResult<Cliente> GetClientes()
    {
        Cliente cliente = new Cliente
        {
            Nome = "Fulano de Tal",
            Cpf = "123.456.789-00",
            Rg = "1234567-9",
            DataNascimento = DateTime.Now,
            Cnh = new Cnh { NumeroCnh = 12349182, ValidadeCnh = DateTime.Now, MunicipioCnh = "Atibaia" }, 
            ServicoContratado = Servicos.IPI,
            endereco = new Endereco { Bairro = "Tapajos", Cep = "098213-20"}, 
            Celulares = new List<int> { 99999999, 88888888 }, 
            StatusPagamento = "Pago",
            LaudoEspecificar = "Bom estado geral"
        };

        _clienteService.CadastrarCliente(cliente);
        return Ok(cliente);
    }

    [HttpPost("CadastrarCliente")]
    [ProducesResponseType<Cliente>(StatusCodes.Status201Created)]
    public async Task<ActionResult> CadastrarCliente(Cliente client)
    {
        await _cliente.InsertOneAsync(client);
        return Created();
    }

    
    [HttpGet("{cpf}/Procuracao")]
    public ActionResult<Cliente> DownloadDocumentosByClienteCpf(string cpf)
    {
        //Cliente cliente = _clienteRepository.BuscarClientePorCpf(cpf);
        //procuracao = _bucketRepository.GetDocumentos(cliente.ProcuracaoPath);
        return Ok();
    }
    
    [HttpPost("SubirArquivosDoCliente")]
    public IActionResult SubirArquivosDoCliente(IFormFile arquivos)
    {
        
        return Ok("Arquivos recebidos com sucesso!");
    }
    
}