using Dominio.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Infraestrutura.Notificacao
{
    public class NotificacaoRepository :INotificacao
    {
        private readonly IHubContext<HubNotificacao> _hubContext;

        public NotificacaoRepository(IHubContext<HubNotificacao> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task EnviarNotificacao(string message)
        {
            await _hubContext.Clients.All.SendAsync("EnviarNotificacao", message);
        }

        public async Task EnviarNotificacaoPorConnectionId(string userId, string message)
        {
            await _hubContext.Clients.User(userId).SendAsync("EnviarNotificacaoByUserId", message);
        }
    }
}
