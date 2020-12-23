using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{

    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public CreateTagCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            Repository.Tag.CreateTag(request.NewTag);
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(CreateTagCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.NewTag == null)
                throw new ArgumentNullException("Tag object can not be null.");
        }
    }
}
