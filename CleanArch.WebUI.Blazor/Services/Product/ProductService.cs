using CleanArch.WebUI.Blazor.Models;

namespace CleanArch.WebUI.Blazor.Services.Product;
public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(HttpClient httpClient)=>_httpClient = httpClient; 
    public Task Add(ProductDto productDTO)
    {
        throw new NotImplementedException();
    }
   
    public async Task<ProductDto> GetById(int id) => await _httpClient.GetFromJsonAsync<ProductDto>($"api/product/{id}");
    public Task<ProductDto> GetProductCategory(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<ProductDto>> GetProducts() => await _httpClient.GetFromJsonAsync<ProductDto[]>("api/product");
  
    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProductDto productDTO)
    {
        throw new NotImplementedException();
    }
}
