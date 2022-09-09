using CleanArch.WebUI.Blazor.Models;

namespace CleanArch.WebUI.Blazor.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CategoryDto> Add(CategoryDto categoryDto)
        {
            await _httpClient.PostAsJsonAsync("api/categories", categoryDto);
            return categoryDto;
        }
        public async Task<CategoryDto> GetById(int id) => await _httpClient.GetFromJsonAsync<CategoryDto>($"api/categories/{id}");

        public async Task<IEnumerable<CategoryDto>> GetCategories() => await _httpClient.GetFromJsonAsync<CategoryDto[]>("api/categories");

        public async Task Remove(int id) => await _httpClient.DeleteAsync($"api/categories/{id}");

        public async Task<CategoryDto> Update(CategoryDto categoryDto, int Id)
        {
            await _httpClient.PutAsJsonAsync($"api/categories/{Id}", categoryDto);
            return categoryDto;
        }
    }
}
