using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GetTagByIdDetailsQueryHandler : IRequestHandler<GetTagByIdDetailsQuery, Tag>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetTagByIdDetailsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<Tag> Handle(GetTagByIdDetailsQuery request, CancellationToken cancellationToken)
        {
            var tag = await Repository.Tag.GetTagWithDetailsAsync(request.Id);
            Logger.LogInfo($"tag returned from database.");
            return tag;
        }
    }
}
