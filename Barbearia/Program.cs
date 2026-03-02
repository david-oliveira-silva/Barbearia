using REPOSITORY.DATA;
using REPOSITORY.MAPEADORES.BARBEIROS;
using REPOSITORY.MAPEADORES.Clientes;
using SERVICE.FACHADA.BARBEIROS;
using SERVICE.FACHADA.CLIENTES;
using SERVICE.PROCESSO.BARBEIRO;
using SERVICE.PROCESSO.CLIENTES;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? conexaoString = builder.Configuration.GetConnectionString("FirebirdConnection");

if (string.IsNullOrEmpty(conexaoString))
{
    throw new InvalidOperationException("A string de conexão 'FirebirdConnection' não foi encontrada.");
}

DBHelper.Inicializar(conexaoString);
builder.Services.AddScoped<IClienteMapeador, ClienteMapeador>();
builder.Services.AddScoped<ClienteProcesso>();
builder.Services.AddScoped<ClienteFachada>();

builder.Services.AddScoped<IBarbeiroMapeador, BarbeiroMapeador>();
builder.Services.AddScoped<BarbeiroProcesso>();
builder.Services.AddScoped<BarbeiroFachada>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cliente}/{action=ListarClientes}/{id?}")
    .WithStaticAssets();


app.Run();
