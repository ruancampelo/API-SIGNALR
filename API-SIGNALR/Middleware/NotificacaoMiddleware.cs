using Dominio.Interfaces;

namespace API_SIGNALR.Middleware
{
    public class NotificacaoMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly INotificacao _notificacao;

        public NotificacaoMiddleware(RequestDelegate next, INotificacao notificacao)
        {
            _next = next;
            _notificacao = notificacao;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            var stastusCodeList = new List<int>{ 201, 204 };
            var statusCode = context.Response.StatusCode;
            var resultado = MetodoValido(context.Request);

            if (resultado.valido && stastusCodeList.Contains(statusCode))
                await _notificacao.EnviarNotificacao(resultado.tipo + " " + DateTime.Now.ToString());
        }

        private (string tipo, bool valido) MetodoValido(HttpRequest request)
        {
            (string tipo, bool valido) valido = (string.Empty, false);

            valido = request.Method switch
            {
                "POST" => ("Criou", true),
                "PUT" => ("Alterou", true),
                "DELETE" => ("Apagou", true),
                _ => (string.Empty, true),
            };
            return valido;
        }

    }
}
