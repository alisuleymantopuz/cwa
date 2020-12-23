using Domain.Infrastructure.Logging;
using Domain.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        public ILoggerManager Logger;
        public IRepositoryWrapper Repository { get; }
        public UpdateTagCommandHandler(ILoggerManager logger, IRepositoryWrapper repository)
        {
            Repository = repository;
            Logger = logger;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var tagEntity = await Repository.Tag.GetTagByIdAsync(request.Id);
            if (tagEntity == null)
                throw new Exception("Record not found.");

            Repository.Tag.UpdateTag(request.TagUpdated);
            await Repository.SaveAsync();
            return Unit.Value;
        }

        public void Validate(UpdateTagCommand request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.TagUpdated == null)
                throw new ArgumentNullException("Tag object can not be null.");
        }
    }
}
