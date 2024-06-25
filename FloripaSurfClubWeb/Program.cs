var builder = WebApplication.CreateBuilder(args);

// Configura o servi�o DbContext para usar PostgreSQL

// Adicione outros servi�os necess�rios aqui
builder.Services.AddControllers();

var app = builder.Build();

// Configura��o do middleware
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
