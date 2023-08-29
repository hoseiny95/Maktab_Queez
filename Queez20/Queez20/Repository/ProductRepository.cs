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
        public async Task Create(Product product,CancellationToken cancellationToken)
        {
            product.ManufactureDate = product.ManufactureDate.Substring(0, 4) + "/" + product.ManufactureDate.Substring(4, 2) +
                "/" + product.ManufactureDate.Substring(6, 2);
            _context.Products.Add(product);
         
            await _context.SaveChangesAsync(cancellationToken);
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
            var productold = await _context.Products.FindAsync(product.Id);
            productold.Name = product.Name;
            productold.ManufactureDate = product.ManufactureDate;
            productold.Price = product.Price;
            productold.CategoryId = product.CategoryId;


            await _context.SaveChangesAsync();
        }
    }
}
