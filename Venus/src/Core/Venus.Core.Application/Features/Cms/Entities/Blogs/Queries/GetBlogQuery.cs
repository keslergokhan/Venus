using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Entities.Blogs;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms
{
    public class GetBlogQuery : IRequest<IResultDataControl<List<ReadBlogDto>>>, ILanguageRequest
    {
        public Guid LanguageId { get; set; }
    }

    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, IResultDataControl<List<ReadBlogDto>>>
    {
        private readonly IBlogRepository _blogRepositories;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository readBlogRepositories, IMediator mediator, IMapper mapper)
        {
            _blogRepositories = readBlogRepositories;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadBlogDto>>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadBlogDto>> result = new ResultDataControl<List<ReadBlogDto>>();
            try
            {
                var blogResult = await _blogRepositories.GetAllAsync(x=>x.LanguageId == request.LanguageId && x.State != (byte)EntityStateEnum.Deleted ,cancellationToken);

                var blogDtos = _mapper.Map<List<ReadBlogDto>>(blogResult);  

                result.SuccessSetData(blogDtos);    
            }
            catch (Exception ex)
            {

                result.Fail(ex);
            }

            return result;
        }
    }
}
