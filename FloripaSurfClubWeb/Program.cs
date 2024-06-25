var builder = WebApplication.CreateBuilder(args);

// Configura o serviço DbContext para usar PostgreSQL

// Adicione outros serviços necessários aqui
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
