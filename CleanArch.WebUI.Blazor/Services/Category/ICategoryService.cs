using CleanArch.WebUI.Blazor.Models;

namespace CleanArch.WebUI.Blazor.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> Add(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto, int Id);
        Task<CategoryDto> GetById(int id);
        Task Remove(int id);
    }
}
