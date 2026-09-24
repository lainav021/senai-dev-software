using MinhaApi.Models;
using MinhaApi.Repositories;
using MinhaApi.Services;

public class FornecedoresService : IFornecedoresService
{
  private readonly IFornecedoresRepository _repo;

  public FornecedoresService(IFornecedoresRepository repo)
      => _repo = repo;

  public IEnumerable<Fornecedores> GetAll()
      => _repo.GetAll();

  public Fornecedores? GetById(int id)
      => _repo.GetById(id);

  public Fornecedores Create(Fornecedores fornecedores)
  {

      _repo.Add(fornecedores);
      return fornecedores;
  }

  public Fornecedores? Update(int id, Fornecedores f)
  {
      if (_repo.GetById(id) == null) return null;
      f.Id = id;
      _repo.Update(f);
      return f;
  }

  public bool Delete(int id) {
    if(_repo.GetById(id) != null) {
        _repo.Delete(id);
        return true;
    }
    return false;
  }

}