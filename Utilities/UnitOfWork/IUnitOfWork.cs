namespace Utilities.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        void Save();
    }
}