using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FornecedoresController : ControllerBase {
    private readonly IFornecedoresService _service;

    public FornecedoresController(IFornecedoresService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() {
           var fornecedores = _service.GetAll();
           return Ok(fornecedores);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        var fornecedores = _service.GetById(id);
        if(fornecedores == null)
        return NotFound();
        return Ok(fornecedores);
    }

    [HttpPost]
    public IActionResult Create(
        [FromBody] Fornecedores fornecedores)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

        var criado = _service.Create(fornecedores);

        return CreatedAtAction(
            nameof(GetById),
            new { id = criado.Id},
            criado);
    }
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        [FromBody] Fornecedores fornecedores)
    {
        var atualizado =
        _service.Update(id, fornecedores);

        if(atualizado == null)
        return NotFound();

        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var deletado = _service.Delete(id);

        if(!deletado)
        return NotFound();

        return NoContent();
    }
}