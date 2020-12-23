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
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TagsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(Name = "get-all-tags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _mediator.Send(new GetAllTagsQuery());
            var tagsResult = _mapper.Map<IEnumerable<CategorizationDto>>(tags);
            return Ok(tagsResult);
        }

        [HttpGet("{id}", Name = "get-tag-by-id")]
        public async Task<IActionResult> GetTagById(Guid id)
        {
            var tags = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            var tagsResult = _mapper.Map<CategorizationDto>(tags);
            return Ok(tagsResult);
        }

        [HttpGet("{id}/products", Name = "get-tag-details")]
        public async Task<IActionResult> GetTagByDetails(Guid id)
        {
            var tags = await _mediator.Send(new GetTagByIdDetailsQuery() { Id = id });
            var tagsResult = _mapper.Map<TagDetailsDto>(tags);
            return Ok(tagsResult);
        }

        [HttpPost(Name = "create-tag")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagDto tag)
        {
            var tagEntity = _mapper.Map<Tag>(tag);
            await _mediator.Send(new CreateTagCommand() { NewTag = tagEntity }); 
            return NoContent();
        }

        [HttpDelete("{id}", Name = "delete-tag")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            await _mediator.Send(new DeleteTagCommand() { TagDeleted = tag });
            return NoContent();
        }

        [HttpPut("{id}", Name = "update-tag")]
        public async Task<IActionResult> UpdateTag(Guid id, [FromBody] CategorizationDto tag)
        {
            var tagEntity = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            _mapper.Map(tag, tagEntity);
            await _mediator.Send(new UpdateTagCommand() { Id = id, TagUpdated = tagEntity });
            return NoContent();
        }
    }
}
