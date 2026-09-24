using System.ComponentModel.Design;
using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class FornecedoresRepository: IFornecedoresRepository{
    private readonly string _connectionString;

    public FornecedoresRepository(IConfiguration config)
        => _connectionString = config.GetConnectionString("DefaultConnection")!;

  
    public IEnumerable<Fornecedores> GetAll() {
        var lista = new List<Fornecedores>();
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT id, nome, data_e, CNPJ, id_produtoF, ativo FROM fornecedores";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read()) {
            lista.Add(new Fornecedores {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Data_e = reader.GetDateTime("data_e"),
                CNPJ = reader.GetString("CNPJ"),
                Id_produtoF = reader.GetInt32("id_produtoF"),
                Ativo = reader.GetBoolean("ativo")
            });
        }
           return lista;
    }
    
   
    public void Add(Fornecedores f) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"INSERT INTO fornecedores (id, nome, data_e, CNPJ, id_produtoF, ativo)
         VALUES (@Id, @Nome, @Data_e, @CNPJ, @Id_produtoF, @Ativo);
          SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", f.Id);
    cmd.Parameters.AddWithValue("@Nome", f.Nome);
     cmd.Parameters.AddWithValue("@Data_e", f.Data_e);
    cmd.Parameters.AddWithValue("@CNPJ", f.CNPJ);
    cmd.Parameters.AddWithValue("@Id_produtoF", f.Id_produtoF);
    cmd.Parameters.AddWithValue("@Ativo", f.Ativo);

    var idGerado = cmd.ExecuteScalar();
    f.Id = Convert.ToInt32(idGerado);
}

        
  public void Update(Fornecedores f) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = @"UPDATE fornecedores SET id=@Id, nome=@Nome, Data_e=@data_e, CNPJ=@CNPJ, id_produtoF=@Id_produtoF, ativo=@Ativo
                   WHERE id=@Id";
    using var cmd = new MySqlCommand(sql, conn);
   cmd.Parameters.AddWithValue("@Id", f.Id);
    cmd.Parameters.AddWithValue("@Nome", f.Nome);
    cmd.Parameters.AddWithValue("@Data_e", f.Data_e);
    cmd.Parameters.AddWithValue("@CNPJ", f.CNPJ);
    cmd.Parameters.AddWithValue("@Id_produtoF", f.Id_produtoF);
    cmd.Parameters.AddWithValue("@Ativo", f.Ativo);
    cmd.ExecuteNonQuery();
  }

  public Fornecedores? GetById(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = "SELECT id, nome, data_e, id_produtoF, CNPJ, ativo FROM fornecedores WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read()) {
            return new Fornecedores {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Data_e = reader.GetDateTime("data_e"),
                Id_produtoF = reader.GetInt32("id_produtoF"),
                CNPJ = reader.GetString("CNPJ"),
                Ativo = reader.GetBoolean("ativo")
            };
        }
        return null;
    }

    public Fornecedores? GetByNome(string nome) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = "SELECT id, nome, CNPJ, id_produtoF, data_e, ativo FROM fornecedores WHERE nome = @Nome";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Nome", nome);

    using var reader = cmd.ExecuteReader();
    if (reader.Read()) {
        return new Fornecedores {
            Id = reader.GetInt32("id"),
            Nome = reader.GetString("nome"),
            CNPJ = reader.GetString("CNPJ"),
            Id_produtoF = reader.GetInt32("id_produtoF"),
            Data_e = reader.GetDateTime("data_e"),
            Ativo = reader.GetBoolean("ativo")
        };
    }
    return null;
}
  public Fornecedores? GetByCnpj(string cnpj) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = "SELECT id, nome, cnpj, id_produtoF, data_e, ativo FROM fornecedores WHERE cnpj = @Cnpj";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Cnpj", cnpj);

    using var reader = cmd.ExecuteReader();
    if (reader.Read()) {
        return new Fornecedores {
            Id = reader.GetInt32("id"),
            Nome = reader.GetString("nome"),
            CNPJ = reader.GetString("CNPJ"),
            Id_produtoF = reader.GetInt32("id_produtoF"),
            Data_e = reader.GetDateTime("data_e"),
            Ativo = reader.GetBoolean("ativo")
        };
    }
    return null;
}

  

  public void Delete(int id) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string  sql = "DELETE FROM FORNECEDORES WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public Fornecedores? GetByCNPJ(string CNPJ)
    {
        throw new NotImplementedException();
    }
}