using Dominio.Interfaces;
using Infraestrutura.Data;

namespace Infraestrutura.Repository
{
    public class Transacao : ITransacao
    {
        private readonly Contexto _contexto;

        public Transacao(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Begin()
        {
            if (_contexto != null)
            {
                _contexto.Database.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (_contexto != null)
            {
                _contexto.Database.CommitTransaction();
            }
        }

        public void RollBack()
        {
            if (_contexto != null)
            {
                _contexto.Database.RollbackTransaction();
            }
        }
    }
}
