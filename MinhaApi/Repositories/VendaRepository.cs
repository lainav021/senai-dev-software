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

 }
