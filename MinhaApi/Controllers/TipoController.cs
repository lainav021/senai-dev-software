/*using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("api/[controller]")]

public class TipoController : ControllerBase {
    
    private readonly ITipoService _service;

    public TipoController (ITipoService service) => _service = service;

    [HttpGet]

    public IActionResult GetAll() {
        var tipo = _service.GetAll();
        return Ok (tipo);
    }
    [HttpGet(*{id}*)]

    public IActionResult GetById (int id) {
    var tipo = _service.GetById (int id);
    if(tipo == null)
    return NotFound();
    return Ok (tipo);
}

[HttPost]
public IActionResult Create(
    [FromBody] Tipo tipo) {

        if (!ModelState.IsValid)
    return BadRequest(ModelState);

    var criado = _service.Create(tipo);

    return CreatedAtAction(
        nameof(GetById),
        new { id = criado.Id},
        criado);
    }

    [HttpPut("{id}")]
public IActionResult Update(
    int id,
    [FromBody] Tipo tipo)
{
    var atualizado =
    _service.Update(id, produto);

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
*/