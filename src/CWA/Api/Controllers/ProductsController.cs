using Api.Filters;
using Api.Models;
using AutoMapper;
using Domain;
using Domain.Pagination;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet(Name = "get-all-products")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParametersInfo productParameters)
        {
            var productParametersEntity = _mapper.Map<ProductParameters>(productParameters);
            var products = await _mediator.Send(new GetAllProductsQuery() { Parameters = productParametersEntity });
            Response.Headers.Add("X-Pagination", products.GetMetadata());
            var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsResult);
        }

        [HttpGet("{id}", Name = "get-product-by-id")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var products = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            var productsResult = _mapper.Map<ProductDto>(products);
            return Ok(productsResult);
        }

        [HttpGet("{id}/tags", Name = "get-product-details")]
        public async Task<IActionResult> GetProductByDetails(Guid id)
        {
            var products = await _mediator.Send(new GetProductByIdDetailsQuery() { Id = id });
            var productsResult = _mapper.Map<ProductDetailDto>(products);
            return Ok(productsResult);
        }

        [HttpPost(Name = "create-product")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto product)
        {
            var products = await _mediator.Send(new GetAllProductsQuery() { Parameters = new ProductParameters { Name = product.Name } });
            if (products.Any()) return BadRequest("This record is already available!");
            var productEntity = _mapper.Map<Product>(product);
            await _mediator.Send(new CreateProductCommand() { NewProduct = productEntity });
            return Ok();
        }

        [HttpDelete("{id}", Name = "delete-product")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            await _mediator.Send(new DeleteProductCommand() { ProductDeleted = product });
            return Ok();
        }

        [HttpPut("{id}", Name = "update-product")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto product)
        {
            var productEntity = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            _mapper.Map(product, productEntity);
            await _mediator.Send(new UpdateProductCommand() { Id = id, ProductUpdated = productEntity });
            return Ok();
        }
    }
}
