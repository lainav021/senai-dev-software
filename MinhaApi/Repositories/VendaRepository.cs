using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class VendaRepository: IVendaRepository {
    private readonly string _connectionString;

    public VendaRepository(IConfiguration config)
        => _connectionString = config.GetConnectionString("DefaultConnection")!;

    
    

    public void Add(Venda v) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"INSERT INTO venda (valor, data_v, cliente_id, produto_id, ativo) 
         VALUES (@Valor, @Data_v, @Cliente_Id, @Produto_Id, @Ativo);
          SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Valor", v.Valor);
    cmd.Parameters.AddWithValue("@Data_v", v.Data_v);
    cmd.Parameters.AddWithValue("@Cliente_Id", v.Cliente_Id);
    cmd.Parameters.AddWithValue("@Produto_Id", v.Produto_Id);
    cmd.Parameters.AddWithValue("@Ativo", v.Ativo);
    var idGerado = cmd.ExecuteScalar();
    v.Id = Convert.ToInt32(idGerado);
}
public IEnumerable<Venda> GetAll() {
        var lista = new List<Venda>();
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT id, valor, data_v, cliente_id, produto_id, ativo FROM venda";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read()) {
            lista.Add(new Venda {
                Id = reader.GetInt32("id"),
                Valor = reader.GetDecimal("valor"),
                Data_v = reader.GetDateTime("data_v"),
                Cliente_Id = reader.GetInt32("cliente_id"),
                Produto_Id = reader.GetInt32("produto_id"),
                Ativo = reader.GetBoolean("ativo")
            });
        }

        return lista;
    }
 public Venda? GetById(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = "SELECT id, valor, data_v, cliente_id, produto_id, ativo FROM venda WHERE id=@Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read()) {
            return new Venda {
                Id = reader.GetInt32("id"),
                Valor = reader.GetDecimal("valor"),
                Data_v = reader.GetDateTime("data_v"),
                Cliente_Id = reader.GetInt32("cliente_id"),
                Produto_Id = reader.GetInt32("produto_id"),
                Ativo = reader.GetBoolean("ativo")
            };
        }
        return null;
    }
}