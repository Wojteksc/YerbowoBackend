using System.Collections.Generic;
using System.Threading.Tasks;
using Yerbowo.Domain.Products;
using Yerbowo.Infrastructure.Data.SeedWork;
using Yerbowo.Infrastructure.Helpers;

namespace Yerbowo.Infrastructure.Data.Products
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<Product> GetAsync(string slug);

        Task<PagedList<Product>> BrowseAsync(int pageNumber, int pageSize, string category, string subcategory);

        Task<IEnumerable<Product>> BrowseRandomAsync(int quantity);
	}
}
