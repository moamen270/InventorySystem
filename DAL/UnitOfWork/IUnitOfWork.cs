namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        void Save();
    }
}