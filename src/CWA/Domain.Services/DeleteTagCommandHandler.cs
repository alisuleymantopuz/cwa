using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public DeleteTagCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            Repository.Tag.DeleteTag(request.TagDeleted);
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(DeleteTagCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.TagDeleted == null)
                throw new ArgumentNullException("Tag object can not be null.");
        }
    }
}
