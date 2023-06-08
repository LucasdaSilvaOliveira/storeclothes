using Microsoft.EntityFrameworkCore;
using storeclothes.Contexto;
using storeclothes.Repositorio;
using storeclothes.Sessao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<BancoContext>(item => item.UseSqlServer(configuration.GetConnectionString("DataBase")));
builder.Services.AddScoped<iUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<iProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<iSessao, Sessao>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
