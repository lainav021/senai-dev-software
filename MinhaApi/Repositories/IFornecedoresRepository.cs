using MinhaApi.Models;

namespace MinhaApi.Repositories;

public interface IFornecedoresRepository
{
    IEnumerable<Fornecedores> GetAll();
    
    Fornecedores? GetById(int id);

    Fornecedores? GetByNome(string nome);

    Fornecedores? GetByCNPJ(string CNPJ);
    void Add(Fornecedores fornecedores);
    void Update(Fornecedores fornecedores);

    void Delete(int id);
}