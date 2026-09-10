using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class VendaRepository: IVendaRepository{
    private readonly string _connectionString;

    public VendaRepository(IConfiguration config)
        => _connectionString = config.GetConnectionString("DefaultConnection")!;

    
    public IEnumerable<Venda> GetAll() {
        var lista = new List<Venda>();
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT id, valor, data, cliente_id FROM vendas";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read()) {
            lista.Add(new Venda {
                Id = reader.GetInt32("id"),
                Valor = reader.GetDecimal("valor"),
                Data_v = reader.GetDateTime("data"),
                Cliente_Id = reader.GetInt32("cliente_id")
            });
        }
           return lista;
    }
    
    public Venda? GetById(int id)
    {
        foreach (var venda in GetAll())
        {
            if (venda.Id == id)
                return venda;
        }
        return null;
    }

    public void Add(Venda v) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"INSERT INTO vendas (valor, data, cliente_id)
         VALUES (@Valor, @Data_v, @Cliente_Id);
          SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Valor", v.Valor);
    cmd.Parameters.AddWithValue("@Data", v.Data_v);
    cmd.Parameters.AddWithValue("@ClienteId", v.Cliente_Id);

    var idGerado = cmd.ExecuteScalar();
    v.Id = Convert.ToInt32(idGerado);
}

        
  public void Update(Venda v) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"UPDATE vendas SET valor=@Valor, data_v=@Data, cliente_id=@ClienteId
                       WHERE id=@Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", v.Id);
        cmd.Parameters.AddWithValue("@Valor", v.Valor);
        cmd.Parameters.AddWithValue("@Data", v.Data_v);
        cmd.Parameters.AddWithValue("@ClienteId", v.Cliente_Id);
        cmd.ExecuteNonQuery();
    }
     
  

     
  


 }
