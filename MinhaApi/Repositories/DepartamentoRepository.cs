using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class DepartamentoRepository: IDepartamentoRepository{
    private readonly string _connectionString;

    public DepartamentoRepository(IConfiguration config)
        => _connectionString = config.GetConnectionString("DefaultConnection")!;

    
    public IEnumerable<Departamento> GetAll() {
        var lista = new List<Departamento>();
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT id, nome, id_fornecedores, descricao, ativo FROM departamentos";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read()) {
            lista.Add(new Departamento {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Id_fornecedores = reader.GetInt32("id_fornecedores"),
                Descricao = reader.GetString("descricao"),
                Ativo = reader.GetBoolean("ativo")
            });
        }
           return lista;
    }
    
    public Departamento? GetById(int id)
    {
        foreach (var departamento in GetAll())
        {
            if (departamento.Id == id)
                return departamento;
        }
        return null;
    }

    public void Add(Departamento d) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"INSERT INTO departamento (id, nome, id_forncedores, descricao, ativo)
         VALUES (@Id, @Nome, @Id_fronecedores, @Descricao, @Ativo);
          SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", d.Id);
    cmd.Parameters.AddWithValue("@Nome", d.Nome);
    cmd.Parameters.AddWithValue("@Id_fornecedores", d.Id_fornecedores);
    cmd.Parameters.AddWithValue("@Descricao", d.Descricao);
    cmd.Parameters.AddWithValue("@Ativo", d.Ativo);

    var idGerado = cmd.ExecuteScalar();
    d.Id = Convert.ToInt32(idGerado);
}

        
  public void Update(Departamento d) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"UPDATE departamentos SET id=@Id, nome=@Nome, id_fornecedores=@Id_fornecedores, descricao=@Descricao, ativo=@Ativo
                       WHERE id=@Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", d.Id);
        cmd.Parameters.AddWithValue("@Nome", d.Nome);
        cmd.Parameters.AddWithValue("@Id_fornecedores", d.Id_fornecedores);
        cmd.Parameters.AddWithValue("@Descricao", d.Descricao);
        cmd.Parameters.AddWithValue("@Ativo", d.Ativo);
        cmd.ExecuteNonQuery();
    }
     
  

  public void Delete(int id) {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string  sql = "DELETE FROM DEPARTAMENTOS WHERE id = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
 }
}