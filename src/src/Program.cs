using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using src.Data;
using src.Data.BusinessLogic;
using src.Data.BusinessLogic.SubFeiras;
using src.Data.BusinessLogic.SubFeiras;
using src.Data.BusinessLogic.SubUsers;
using src.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<SubFeirasFacade>();

//DAOConfig.createDatabase();

SubFeirasFacade f = new SubFeirasFacade();
//SubUtilizadoresFacade uf = new SubUtilizadoresFacade();

//Feira f1 = new Feira("feira de ponte de lima", "Rural", "Muito boa", "Ponte de lima");
//Feira f2 = await f.GetFeira(f1.nomeFeira);
//Console.WriteLine(f1.Equals(f2));

//Vendedor v = new Vendedor(223, "joao", "p", "joao@gmail.com", "123");
//uf.AddVendedor(v);
//Vendedor v1 = await uf.GetVendedor(223);
//Console.WriteLine(v1.Equals(v));



//Cliente c = new Cliente(12245677, "joao", "p", "joao@gmail.com", "123");
//uf.AddCliente(c);
//Cliente c1 = await uf.GetCliente(12245677);
//Console.WriteLine(c1.Equals(c));




    

//Produto p = new Produto("couves", (float)3.45, 200, "Batatas de Qualidade", "Produtos Agrícolas", 0, (float)0.2, (float)0.2, (float)0.2, "feira de ponte de lima", 223);
//Produto pcp = f.AddProduto(p);
//Console.WriteLine(pcp);
/*Console.WriteLine(f.GetProdutosFeira("arcosverde"));
Console.WriteLine(f.GetAvaliacaoMediaProduto(1));
Console.WriteLine(f.GetProduto(1));
Console.WriteLine(f.GetProdutosVendedor(1));
Console.WriteLine(f.GetProdutosFavoritos(1));*/






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

