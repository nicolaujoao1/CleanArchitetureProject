using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    { 

        private AppDbContext _productContext;
        public ProductRepository(AppDbContext appDbContext)=>_productContext = appDbContext;
        
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public Task<Product> GetProductCategoryAsync(int? id)
        {
            return _productContext.Products.Include(c => c.Category).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
           return await _productContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;

        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
