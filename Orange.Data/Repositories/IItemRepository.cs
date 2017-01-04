using Orange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.Data.Repositories
{
    public interface IItemRepository
    {
        Task<IQueryable<MarketingItem>> GetAllProductsAsync();
        Task<MarketingItem> GetProductByIdAsync(int id);
        Task<int> CreateItem(MarketingItem item);
        Task<bool> UpdateItem(int id, MarketingItem item);
        Task<bool> DeleteItem(int id);
    }
}
