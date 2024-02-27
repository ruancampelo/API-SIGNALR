using API_SIGNALR.Middleware;
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
IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables() 
            .Build();
builder.Services.AddDbContext<Contexto>(options =>
                                        options.UseSqlite(configuration["ConnectionString:DefaultConnection"]));


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
app.UseMiddleware<NotificacaoMiddleware>();

app.Run();
