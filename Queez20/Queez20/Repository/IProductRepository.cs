using Queez20.Models;
using System.Net;

namespace Queez20.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task Create(Product product, CancellationToken cancellationToken);
        Task Update(Product product);
        Task Delete(int id);
    }
}
