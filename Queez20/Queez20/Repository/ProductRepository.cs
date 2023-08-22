using Dapper;
using Queez20.Data;
using Queez20.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net;

namespace Queez20.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;

        public ProductRepository(ApplicationContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task Create(Product product)
        {
            _context.Products.Add(product);
         
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("AppContext"));
            var products = await connection.QueryAsync<Product>("select * from Products");
            return products;
        }
    
        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            
            return product;
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
