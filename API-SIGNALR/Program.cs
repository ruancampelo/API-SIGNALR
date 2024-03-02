using Aplicacao.Mediator.Album.Alterar;
using Infraestrutura;
using Infraestrutura.Data;
using Infraestrutura.Notificacao;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddDbContext<Contexto>(options =>
                                        options.UseSqlite(Environment.GetEnvironmentVariable("ConnectionString")));


builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(AlterarAlbumResponse).Assembly));
builder.Services.ConfigureDependencies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials());
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<HubNotificacao>("/notificacao");
app.MapControllers();
app.Run();
