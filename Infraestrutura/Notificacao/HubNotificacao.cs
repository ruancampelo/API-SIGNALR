using Dominio.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Infraestrutura.Notificacao
{
    public class HubNotificacao : Hub 
    {
        public async Task EnviarNotificacao(string message)
        {
            await Clients.All.SendAsync(message);
        }

        public async Task EnviarNotificacaoPorConnectionId(string userId, string message)
        {
            await Clients.User(userId).SendAsync("EnviarNotificacaoByUserId", message);
        }
    }
}
