﻿using Dapper;
using Queez20.Data;
using Queez20.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Queez20.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;

        public CategoryRepository(ApplicationContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task Create(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var query = "select * from Category ";
            using var connection = new SqlConnection(_config.GetConnectionString("constring"));
            var category = await connection.QueryAsync<Category>("select * from Product");
            return category;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task Update(Category category)
        {
            _context.Entry(category).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}