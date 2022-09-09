using CleanArch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        //Task<IEnumerable<ProductDTO>> GetProductsCategory();
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> GetProductCategory(int id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int id);
    }
}
