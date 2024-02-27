namespace Dominio.Interfaces 
{ 
    public interface INotificacao
    {
        Task EnviarNotificacao(string message);

        Task EnviarNotificacaoPorConnectionId(string userId, string message);

    }
}
