using DAL.Data;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<Supplier> GetSupplierWithProductsByIdAsync(int id)
        {
            return await _context.Suppliers
                .Include(s => s.Products) // Include related products
                .FirstOrDefaultAsync(s => s.SupplierId == id);
        }
    }
}