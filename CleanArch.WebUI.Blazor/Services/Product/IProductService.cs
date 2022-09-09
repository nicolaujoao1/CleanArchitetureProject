using CleanArch.WebUI.Blazor.Models;

namespace CleanArch.WebUI.Blazor.Services.Product;
public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetById(int id);
    Task<ProductDto> GetProductCategory(int id);
    Task Add(ProductDto productDTO);
    Task Update(ProductDto productDTO);
    Task Remove(int id);
}
