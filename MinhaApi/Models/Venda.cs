namespace MinhaApi.Models;

public class Venda
{
    public int Id {get; set;}

    public int Cliente_Id {get; set;}

  public DateTime Data_v {get; set;}

    public decimal Valor {get; set;}

    public int Quantidade {get; set;}

    public int Produto_Id {get; set;}

    public bool Ativo {get; set;}
    = true;
}