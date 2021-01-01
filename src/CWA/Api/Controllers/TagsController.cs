using Api.Filters;
using Api.Hubs;
using Api.Models;
using AutoMapper;
using Domain;
using Domain.Pagination;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IHubContext<MessageHub> _messageHubContext;

        public TagsController(IMediator mediator, IMapper mapper, IHubContext<MessageHub> messageHubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _messageHubContext = messageHubContext;
        }

        [HttpGet(Name = "get-all-tags")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetAllTags([FromQuery] TagsParametersInfo tagsParameters)
        {
            var tagParametersEntity = _mapper.Map<TagParameters>(tagsParameters);
            var tags = await _mediator.Send(new GetAllTagsQuery() { Parameters = tagParametersEntity });
            Response.Headers.Add("X-Pagination", tags.GetMetadata());
            var tagsResult = _mapper.Map<IEnumerable<TagDto>>(tags);
            return Ok(tagsResult);
        }

        [HttpGet("{id}", Name = "get-tag-by-id")]
        public async Task<IActionResult> GetTagById(Guid id)
        {
            var tags = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            var tagsResult = _mapper.Map<TagDto>(tags);
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
            var tags = await _mediator.Send(new GetAllTagsQuery() { Parameters = new TagParameters { Name = tag.Name } });
            if (tags.Any()) return BadRequest("This record is already available!");
            var tagEntity = _mapper.Map<Tag>(tag);
            await _mediator.Send(new CreateTagCommand() { NewTag = tagEntity });
            await _messageHubContext.Clients.All.SendAsync("ReceiveMessage", $"New tag added. Tag name: {tag.Name}");
            return Ok();
        }

        [HttpDelete("{id}", Name = "delete-tag")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            await _mediator.Send(new DeleteTagCommand() { TagDeleted = tag });
            await _messageHubContext.Clients.All.SendAsync("ReceiveMessage", $"tag deleted. Tag name: {tag.Name}");
            return Ok();
        }

        [HttpPut("{id}", Name = "update-tag")]
        public async Task<IActionResult> UpdateTag(Guid id, [FromBody] TagDto tag)
        {
            var tagEntity = await _mediator.Send(new GetTagByIdQuery() { Id = id });
            _mapper.Map(tag, tagEntity);
            await _mediator.Send(new UpdateTagCommand() { Id = id, TagUpdated = tagEntity });
            await _messageHubContext.Clients.All.SendAsync("ReceiveMessage", $"tag updated. Tag name: {tagEntity.Name}");
            return Ok();
        }
    }
}
