using MinhaApi.Repositories;
using MinhaApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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