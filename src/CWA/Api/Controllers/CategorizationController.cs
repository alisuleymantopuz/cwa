using Api.Filters;
using Api.Models;
using AutoMapper;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategorizationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(Name = "get-categorizations")]
        public async Task<IActionResult> GetAllCategorizations()
        {
            var categorizations = await _mediator.Send(new GetProductsTagsQuery());
            var categorizationsResult = _mapper.Map<IEnumerable<CategorizationDto>>(categorizations);
            return Ok(categorizationsResult);
        }

        [HttpPost(Name = "add-tag-to-product")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddTagToProductDto([FromBody] AddTagToProductDto tagProductInfo)
        {
            await _mediator.Send(new AddTagToProductCommand() { ProductId = tagProductInfo.ProductId, TagId = tagProductInfo.TagId });
            return NoContent();
        }
    }
}
