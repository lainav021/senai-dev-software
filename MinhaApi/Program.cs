using MinhaApi.Repositories;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => {
    options.AddPolicy("FrontendPolicy", policy => {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ✅ Registra o Repository
builder.Services.AddScoped<
    IProdutoRepository,
    ProdutoRepository>();

// ✅ Registra a Repository
    builder.Services.AddScoped<
    IClienteRepository,
    ClienteRepository>();

    // ✅ Registra a Repository
    builder.Services.AddScoped<
    IVendaRepository,
    VendaRepository>();
    
    // ✅ Registra o Repository
builder.Services.AddScoped<
    IFornecedoresRepository,
    FornecedoresRepository>();

    // ✅ Registra a Repository
    builder.Services.AddScoped<
    IDepartamentoRepository,
    DepartamentoRepository>();

// ✅ Registra a Service
builder.Services.AddScoped<
    IProdutoService,
    ProdutoService>();
    
// ✅ Registra a Service
builder.Services.AddScoped<
    IClienteService,
    ClienteService>();

    // ✅ Registra a Service
    builder.Services.AddScoped<
    IVendaService,
    VendaService>();

    // ✅ Registra a Service
builder.Services.AddScoped<
    IFornecedoresService,
    FornecedoresService>();

    // ✅ Registra a Service
builder.Services.AddScoped<
    IDepartamentoService,
    DepartamentoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("FrontendPolicy");
app.MapControllers();
app.Run();

//USE minha_api_db;
//CREATE TABLE IF NOT EXISTS fornecedores (
//id INT PRIMARY KEY AUTO_INCREMENT,
//nome VARCHAR(500),
//CNPJ VARCHAR(14),
//id_produtoF INT,
 //data_e DATE,
//ativo TINYINT(1) NOT NULL DEFAULT 1, 
//FOREIGN KEY (id_produtoF) REFERENCES produtos(id)
 
//);

//CREATE DATABASE minha_api_db;
//USE minha_api_db;
//CREATE TABLE IF NOT EXISTS clientes (
//id INT PRIMARY KEY AUTO_INCREMENT,
//nome VARCHAR(500),
//email VARCHAR(100),
//cpf VARCHAR(12),
//ativo TINYINT(1) NOT NULL DEFAULT 1
//);

//SELECT * FROM clientes;


/*USE minha_api_db;
CREATE TABLE IF NOT EXISTS produtos (
id INT PRIMARY KEY AUTO_INCREMENT,
nome VARCHAR(500),
estoque INT,
preco INT,
ativo TINYINT(1) NOT NULL DEFAULT 1
);

SELECT * FROM produtos;*/

/*CREATE DATABASE minha_api_db;
USE minha_api_db;
CREATE TABLE IF NOT EXISTS venda (
id INT PRIMARY KEY AUTO_INCREMENT,
cliente_Id INT,
produto_Id  INT,
cpf VARCHAR(12),
ativo TINYINT(1) NOT NULL DEFAULT 1
);

SELECT * FROM clientes;*/