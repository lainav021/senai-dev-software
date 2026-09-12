using MinhaApi.Models;

namespace MinhaApi.Repositories;

public interface IVendaRepository
{
    
    Venda? GetById(int id);
    void Add(Venda venda);
    
    
}