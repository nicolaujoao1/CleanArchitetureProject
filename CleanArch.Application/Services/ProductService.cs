using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository??throw new ArgumentException(nameof(productRepository));
            _mapper = mapper;
        }
        public async Task Add(ProductDTO productDTO)
        {
            var produtEntity=_mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(produtEntity);
        }
        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity =await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);          
        }
        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity=await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        //public async Task<IEnumerable<ProductDTO>> GetProductsCategory()
        //{
        //    var productEntity=await _productRepository.GetProductsCategoryAsync();
        //    return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        //}

        public async Task Remove(int id)
        {
            var productEntity =_productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);  
        }
        public async Task Update(ProductDTO productDTO)
        {
            var productEntity=_mapper.Map<Product>(productDTO); 
            await _productRepository.UpdateAsync(productEntity);    
        }
    }
}
