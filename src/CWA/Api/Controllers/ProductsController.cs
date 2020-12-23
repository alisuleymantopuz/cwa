using Api.Filters;
using Api.Models;
using AutoMapper;
using Domain;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsResult);
        }

        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var products = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            var productsResult = _mapper.Map<ProductDto>(products);
            return Ok(productsResult);
        }

        [HttpGet("{id}/tags", Name = "ProductWithDetails")]
        public async Task<IActionResult> GetProductByDetails(Guid id)
        {
            var products = await _mediator.Send(new GetProductByIdDetailsQuery() { Id = id });
            var productsResult = _mapper.Map<ProductDetailDto>(products);
            return Ok(productsResult);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _mediator.Send(new CreateProductCommand() { NewProduct = productEntity });
            var createdProduct = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            await _mediator.Send(new DeleteProductCommand() { ProductDeleted = product });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto product)
        {
            var productEntity = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            _mapper.Map(product, productEntity);
            await _mediator.Send(new UpdateProductCommand() { Id = id, ProductUpdated = productEntity });
            return NoContent();
        }

        [HttpPost("AddTagToProduct")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddTagToProductDto([FromBody] AddTagToProductDto tagProductInfo)
        {
            await _mediator.Send(new AddTagToProductCommand() { ProductId = tagProductInfo.ProductId, TagId = tagProductInfo.TagId });
            return NoContent();
        }
    }
}
