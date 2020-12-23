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

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _mediator.Send(new GetAllTagsQuery());
            var tagsResult = _mapper.Map<IEnumerable<TagDto>>(tags);
            return Ok(tagsResult);
        }

        [HttpGet("{id}", Name = "TagById")]
        public async Task<IActionResult> GetTagById(Guid id)
        {
            var tags = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            var tagsResult = _mapper.Map<TagDto>(tags);
            return Ok(tagsResult);
        }

        [HttpGet("{id}/products", Name = "TagWithDetails")]
        public async Task<IActionResult> GetTagByDetails(Guid id)
        {
            var tags = await _mediator.Send(new GetTagByIdDetailsQuery() { Id = id });
            var tagsResult = _mapper.Map<TagDetailsDto>(tags);
            return Ok(tagsResult);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagDto tag)
        {
            var tagEntity = _mapper.Map<Tag>(tag);
            await _mediator.Send(new CreateTagCommand() { NewTag = tagEntity });
            var createdTag = _mapper.Map<TagDto>(tagEntity);
            return CreatedAtRoute("TagById", new { id = createdTag.Id }, createdTag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            await _mediator.Send(new DeleteTagCommand() { TagDeleted = tag });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(Guid id, [FromBody] TagDto tag)
        {
            var tagEntity = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            _mapper.Map(tag, tagEntity);
            await _mediator.Send(new UpdateTagCommand() { Id = id, TagUpdated = tagEntity });
            return NoContent();
        }
    }
}
