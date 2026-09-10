using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase {
    private readonly IVendaService _service;

    public VendaController(IVendaService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() {
           var vendas = _service.GetAll();
           return Ok(vendas);
    }

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
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        [FromBody] Venda venda)
    {
        var atualizado =
        _service.Update(id, venda);

        if(atualizado == null)
        return NotFound();

        return Ok(atualizado);
    }

    
}