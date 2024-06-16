using Microsoft.AspNetCore.Mvc;
using service.NotaFiscal.Core.Domain.Entities;
using service.NotaFiscal.Driving.API.Responses;

namespace service.NotaFiscal.Driving.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NotaFiscalController : ControllerBase
{
    // GET
    [HttpGet]
    public ActionResult<NotaFiscalResponse> GetNotaFiscalById(long id)
    {
        NotaFiscalResponse notasFiscal = new NotaFiscalResponse(32141, "Lucas", "Banco Pan");
        Console.WriteLine(notasFiscal);
        return Ok(notasFiscal);
    }
}