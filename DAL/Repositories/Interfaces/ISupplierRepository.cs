namespace DAL.Repositories.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierWithProductsByIdAsync(int id);
    }
}