using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms
{
    public class RemoveBlogCommand : IRequest<IResultControl>
    {
        public Guid Id { get; set; }
    }

    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand, IResultControl>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IVenusUnitOfWork _venusUnitOfWork;

        public RemoveBlogCommandHandler(IBlogRepository blogRepository, IVenusUnitOfWork venusUnitOfWork)
        {
            _blogRepository = blogRepository;
            _venusUnitOfWork = venusUnitOfWork;
        }


        public async Task<IResultControl> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            IResultControl result = new ResultControl();    
            try
            {
                await _blogRepository.RemoveAsync(request.Id, cancellationToken);
                await _venusUnitOfWork.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
