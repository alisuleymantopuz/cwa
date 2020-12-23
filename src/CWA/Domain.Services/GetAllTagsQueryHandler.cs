using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<Tag>>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetAllTagsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<IEnumerable<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await Repository.Tag.GetAllTagsAsync();
            Logger.LogInfo($"all tags returned from database.");
            return tags;
        }
    }
}
