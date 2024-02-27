using Dominio.Interfaces;
using Infraestrutura.Repository;
using Infraestrutura.Notificacao;

using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura
{
    public static class InjecaoDependencia
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ITransacao, Transacao>();
            services.AddTransient<INotificacao, NotificacaoRepository>();

        }
    }
}
