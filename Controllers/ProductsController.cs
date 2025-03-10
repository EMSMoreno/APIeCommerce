﻿using APIeCommerce.Entities;
using APIeCommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string productType, int? categoryId = null)
        {
            IEnumerable<Product> _products;

            if (productType == "category" && categoryId != null)
            {
                _products = await _productRepository.GetProductsByCategoryAsync(categoryId.Value);
            }
            else if (productType == "popular")
            {
                _products = await _productRepository.GetPopularProductsAsync();
            }
            else if (productType == "bestseller")
            {
                _products = await _productRepository.GetBestSellerProductsAsync();
            }
            else
            {
                return BadRequest("Invalid product type.");
            }

            var Products = _products.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                UrlImage = p.UrlImage
            });

            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var product = await _productRepository.GetProductDetailsAsync(id);

            if (product is null)
            {
                return NotFound($"Product with id={id} not found.");
            }

            var productDetail = new
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Details = product.Details,
                UrlImage = product.UrlImage
            };

            return Ok(productDetail);
        }
    }
}