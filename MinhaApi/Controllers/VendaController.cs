using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase {
    private readonly IVendaService _service;

    public VendaController(IVendaService service) => _service = service;

    

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        var venda = _service.GetById(id);
        if(venda == null)
        return NotFound();
        return Ok(venda);
    }

    [HttpPost]
    public IActionResult Create(
        [FromBody] Venda venda)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

        var criado = _service.Create(venda);

        return CreatedAtAction(
            nameof(GetById),
            new { id = criado.Id},
            criado);
    }
   
    
}