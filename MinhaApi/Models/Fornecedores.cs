using System.Data;

namespace MinhaApi.Models;

public class Fornecedores
{
    public int Id {get; set;}

    public string Nome {get; set;}
    = string.Empty;

    public string CNPJ {get; set;}
    =string.Empty;

    public int Id_produtoF {get; set;}
    
    public DateTime Data_e {get; set;}
    public bool Ativo {get; set;}
    = true;
}