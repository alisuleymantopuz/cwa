using Domain.Infrastructure.Logging;
using Domain.Pagination;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, PagedList<Tag>>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public GetAllTagsQueryHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }
        public async Task<PagedList<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            Validate(request);
            var tags = await Repository.Tag.GetTagsAsync(request.Parameters) ;
            Logger.LogInfo($"all tags returned from database.");
            return tags;
        }

        private void Validate(GetAllTagsQuery request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.Parameters == null)
                throw new ArgumentNullException("Parameters object can not be null.");
        }
    }
}
