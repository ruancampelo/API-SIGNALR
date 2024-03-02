using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infraestrutura.Notificacao
{
    public class HubNotificacao : Hub 
    {

        public async Task AdicionarUsuarioAoGrupo(string userId, string groupName)
        {
            await Groups.AddToGroupAsync(userId, groupName);
        }

        public async Task RemoverUsuarioDoGrupo(string userId, string groupName)
        {
            await Groups.RemoveFromGroupAsync(userId, groupName);
        }
    }
}
