using Microsoft.EntityFrameworkCore;
using FloripaSurfClub.Data;
using FloripaSurfClub.Repositories;
using FloripaSurfClub.Services;
using Microsoft.OpenApi.Models;
using FloripaSurfClub.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o serviço DbContext para usar PostgreSQL
builder.Services.AddDbContext<FloripaSurfClubContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<Pessoa>()
    .AddEntityFrameworkStores<FloripaSurfClubContext>();

builder.Services.AddControllers();

// Adiciona e configura o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FloripaSurfClub API", Version = "v1" });
});

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Ativa o middleware do Swagger para gerar a documentação JSON e a interface UI
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
