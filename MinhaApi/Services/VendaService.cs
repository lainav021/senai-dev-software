using MinhaApi.Models;
using MinhaApi.Repositories;
using MinhaApi.Services;

public class VendaService : IVendaService {
  private readonly IVendaRepository _repo;

  private readonly IClienteRepository _clienteRepo;

private readonly IProdutoRepository _produtoRepo;
  public VendaService(IVendaRepository repo, IClienteRepository clienterepo, IProdutoRepository produtorepo) {

       _repo = repo;
      _clienteRepo = clienterepo;
        _produtoRepo = produtorepo;
  }
      public Venda Create(Venda venda) {
        
        var cliente = _clienteRepo.GetById(venda.Cliente_Id);
        if (cliente == null)
            throw new ArgumentException("Cliente não encontrado");

        var produto = _produtoRepo.GetById(venda.Produto_Id);
        if (produto == null)
            throw new ArgumentException("Produto não encontrado");

        var Quantidade = venda.Quantidade;
        if (Quantidade <= 0)
            throw new ArgumentException("Quantidade inválida");

        _repo.Add(venda);
        return venda;
    }
    public int calcularValorTotal(Venda venda) {
        var produto = _produtoRepo.GetById(venda.Produto_Id);
        if (produto == null)
            throw new ArgumentException("Produto não encontrado");

        var valorTotal = produto.Preco * venda.Quantidade;
        return (int)valorTotal;
    }

}