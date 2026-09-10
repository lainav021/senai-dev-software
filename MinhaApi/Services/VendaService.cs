using MinhaApi.Models;
using MinhaApi.Repositories;
using MinhaApi.Services;

public class VendaService : IVendaService
{
  private readonly IVendaRepository _repo;

  public VendaService(IVendaRepository repo)
      => _repo = repo;

 public IEnumerable<Venda> GetAll()
      => _repo.GetAll();
  public Venda? GetById(int id)
      => _repo.GetById(id);


  public Venda? Update(int id, Venda v)
  {
      if (_repo.GetById(id) == null) return null;
      v.Id = id;
      _repo.Update(v);
      return v;
  }

}