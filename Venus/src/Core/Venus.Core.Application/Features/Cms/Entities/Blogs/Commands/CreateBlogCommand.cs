using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Entities.Blogs;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Entities.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<IResultDataControl<ReadBlogDto>>, ILanguageRequest, IDynamicPropertyRequest
    {
        public Guid LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string JsonData { get; set; }
        public string UrlPath { get; set; }
    }

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, IResultDataControl<ReadBlogDto>>
    {
        public async Task<IResultDataControl<ReadBlogDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
