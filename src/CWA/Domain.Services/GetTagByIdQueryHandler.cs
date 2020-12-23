using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, Tag>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetTagByIdQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<Tag> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await Repository.Tag.GetTagByIdAsync(request.Id);
            Logger.LogInfo($"tag returned from database.");
            return tag;
        }
    }
}
