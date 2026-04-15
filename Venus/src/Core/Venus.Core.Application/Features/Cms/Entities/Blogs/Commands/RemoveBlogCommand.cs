using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Entities.Blogs.Commands
{
    public class RemoveBlogCommand : IRequest<IResultControl>
    {
        public Guid Id { get; set; }
    }

    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand, IResultControl>
    {
        public RemoveBlogCommandHandler()
        {
        }

        public async Task<IResultControl> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
