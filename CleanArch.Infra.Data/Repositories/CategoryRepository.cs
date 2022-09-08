using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories;
public class CategoryRepository:ICategoryRepository
{
    private AppDbContext _categoryContext;
    public CategoryRepository(AppDbContext appDbContext)=>_categoryContext=appDbContext;

    public async Task<Category> CreateAsync(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();  
        return category;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryContext.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
