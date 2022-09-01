using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {
       Task<IEnumerable<Category>>GetCategoriesAsync();
       Task<Category>GetByIdAsync(int id);
       Task<Category>CreateAsync(Category category);
       Task<Category>UpdateAsync(Category category);
       Task<Category>RemoveAsync(Category category);
    }
}
