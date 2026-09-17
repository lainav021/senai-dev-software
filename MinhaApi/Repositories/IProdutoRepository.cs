using MinhaApi.Models;

namespace MinhaApi.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> GetAll();
    Produto? GetById(int id);
    void Add(Produto produto);
    void Update(Produto produto);
    void UpddateEstoque(int id, int estoque);
    void Delete(int id);
}