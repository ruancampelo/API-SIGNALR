namespace Dominio.Interfaces
{
    public interface ITransacao
    {
        void Begin();
        void Commit();
        void RollBack();
    }
}
