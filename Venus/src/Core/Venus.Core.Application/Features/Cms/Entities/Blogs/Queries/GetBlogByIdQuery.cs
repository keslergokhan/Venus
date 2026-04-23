using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Entities.Blogs;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Entities.Blogs.Queries
{
    public class GetBlogByIdQuery : IRequest<IResultDataControl<ReadBlogDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, IResultDataControl<ReadBlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadBlogDto>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadBlogDto> result = new ResultDataControl<ReadBlogDto>();

            try
            {
                var blog = await _blogRepository.GetByIdAsync(request.Id,cancellationToken);
                if (blog == null)
                {
                    throw new VenusCmsBusinessException("Blog not found");
                }

                result.SetData(_mapper.Map<ReadBlogDto>(blog)).Success();

            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
