﻿using AutoMapper;
using server.Dto;
using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;
using System.Xml.Linq;

namespace server.Service
{
    public class CatalogService: ICatalogService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public CatalogService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IImageService imageService,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.brandRepository = brandRepository;
            this.imageService = imageService;
            this.mapper = mapper;
        }

        public async Task<Brand> CreateBrand(CreateBrandReq inData)
        {
            Image image = await this.imageService.SaveImageAsync(inData.Image);
            Brand brand = mapper.Map<Brand>(inData);
            brand.ImageId = image.Id;
             return await brandRepository.AddAsync(brand);

        }

        public async Task<Category> CreateCategery(CreateCategoryReq inData)
        {
            Image image = await this.imageService.SaveImageAsync(inData.Image);

            Category category = mapper.Map<Category>(inData);
            category.Image = image;
            return await categoryRepository.AddAsync(category);
        }

        public async Task<Product> CreateProduct(CreateProductReq inData)
        {
            var category = await this.categoryRepository.GetByIdAsync(inData.CategoryId);
            var brand = await this.brandRepository.GetByIdAsync(inData.BrandId);

            if (category == null) { throw new Exception($"Invalid Category Id {inData.CategoryId}"); }
            if (brand == null) { throw new Exception($"Invalid Brand Id {inData.BrandId}"); }

            Image image = await this.imageService.SaveImageAsync(inData.Thumbnail);

            Product newProduct = new Product
            {
                Name = inData.Name,
                Description = inData.Description,
                OriginalPrice = inData.OriginalPrice,
                DiscountPercentage = inData.DiscountPercentage,
                DiscountAmount = inData.DiscountAmount,
                StockQuantity = inData.StockQuantity,
                IsFeatured = inData.IsFeatured,
                Category = category,
                Brand = brand,
                Thumbnail = image,

                // **New Fields**
              
            
            };

            return await this.productRepository.AddAsync(newProduct);
        }


        public async Task DeleteBrand(int brandId)
        {
            Brand? brand = await this.brandRepository.GetByIdAsync(brandId);
            if (brand == null) { throw new Exception($"Invalid Brand Id {brandId}"); };

            if (brand.ImageId != null)
            {
                await imageService.DeleteImageAsync((int)brand.ImageId);
            }

            await brandRepository.DeleteAsync(brand);
        }

        public async Task DeleteCategery(int categeryId)
        {
            Category? category = await this.categoryRepository.GetByIdAsync(categeryId);
            if (category == null) { throw new Exception($"Invalid Category Id {categeryId}"); };

            if (category.ImageId != null)
            {
                await imageService.DeleteImageAsync((int)category.ImageId);
            }
            await categoryRepository.DeleteAsync(category);

        }

        public async Task DeleteProduct(int productId)
        {
            Product? product = await productRepository.GetByIdAsync(productId);
            if (product == null) { throw new Exception($"Invalid Product Id {productId}"); };

            if(product.ThumbnailId != null)
            {
                await imageService.DeleteImageAsync((int)product.ThumbnailId);
            }

            await productRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<Brand>> GetAllBrand()
        {
            return await brandRepository.GetAllIncludingImage();
        }

        public async Task<IEnumerable<Category>> GetAllCategery()
        {
            return await categoryRepository.GetAllIncludingImage();
        }

        public async Task<ProductPagination> GetAllProducts(CatalogSpec inData)
        {
            return await productRepository.GetAllIncludingChlidEntities(inData);
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await productRepository.GetProductByIdIncludingChlidEntities(id);
        }
    }
}
