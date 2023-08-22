using Queez20.Models;

namespace Queez20.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}
