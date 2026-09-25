using System.Data;

namespace MinhaApi.Models;

public class Departamento
{
    public int Id {get; set;}

    public string Nome {get; set;}
    = string.Empty;

 public int Id_fornecedores {get; set;}

    public string Descricao {get; set;}
    =string.Empty;

    public bool Ativo {get; set;}
    = true;
}