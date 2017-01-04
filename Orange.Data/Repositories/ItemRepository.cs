using Orange.Data;
using Orange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    public class ItemRepository : Repository<MarketingItem>, IItemRepository, IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public ItemRepository(ApplicationDbContext dataContext)
           : base(dataContext)
        {
            _unitOfWork = new UnitOfWork();
        }

        public Task<int> CreateItem(MarketingItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<MarketingItem>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MarketingItem> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItem(int id, MarketingItem item)
        {
            throw new NotImplementedException();
        }
    }
}
