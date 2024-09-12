using DAL.Data;

namespace DAL.Repositories
{
    public class StockHistoryRepository : Repository<StockHistory>, IStockHistoryRepository
    {
        public StockHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}