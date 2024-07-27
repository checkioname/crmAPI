using Microsoft.AspNetCore.Mvc;
using service.CRM.Core.Application.Services;
using service.CRM.Core.Domain.Entities;
using service.CRM.Driven.Adapter.Data.Collections;

namespace service.CRM.Driving.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    //private ClienteService _clienteService;
    private readonly IClienteRepository _clienteRepository;
    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
        //_clienteService = clienteService;
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
        try
        {
            //await _clienteService.CadastrarCliente(client);
            await _clienteRepository.createCliente(client);
        
            return Ok("Cliente criado com sucesso");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }

    
    [HttpGet("{cpf}/Procuracao")]
    public ActionResult<Cliente> DownloadDocumentosByClienteCpf(string cpf)
    {
        // Cliente cliente = _clienteRepository.BuscarClientePorCpf(cpf);
        // procuracao = _bucketRepository.GetDocumentos(cliente.ProcuracaoPath);
        return Ok();
    }
    
    [HttpPost("SubirArquivosDoCliente")]
    public IActionResult SubirArquivosDoCliente(IFormFile arquivos)
    {
        
        return Ok("Arquivos recebidos com sucesso!");
    }
    
}