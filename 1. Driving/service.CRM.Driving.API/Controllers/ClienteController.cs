using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using service.CRM.Core.Application.Services;
using service.CRM.Core.Domain.Entities;
using service.CRM.Core.Domain.Enums;
using service.CRM.Driven.Adapter.Data.Collections;
using service.CRM.Driven.Adapter.Data.Data;
using service.CRM.Driving.API.Requests;
using service.CRM.Driving.API.Responses;

namespace service.CRM.Driving.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private ClienteService _clienteService = new ClienteService();
    private readonly ClienteRepository _clienteRepository;
    public ClienteController(ClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Cliente>> GetClientes()
    {
        IEnumerable<Cliente> clientes = await _clienteRepository.FindAll();
        return Ok(clientes);
    }

    [HttpPost("CadastrarCliente")]
    [ProducesResponseType<Cliente>(StatusCodes.Status201Created)]
    public async Task<ActionResult> CadastrarCliente([FromForm]Cliente client)
    {
        await _clienteService.CadastrarCliente(client);
        //banco ainda nao implementado
        //await _cliente.InsertOneAsync(client);
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