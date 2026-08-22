using Microsoft.AspNetCore.Mvc;

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
}
