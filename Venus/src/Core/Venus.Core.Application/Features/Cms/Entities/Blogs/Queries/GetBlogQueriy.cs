using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Entities.Blogs;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms
{
    public class GetBlogQueriy : IRequest<IResultDataControl<List<ReadBlogDto>>>, ILanguageRequest
    {
        public Guid LanguageId { get; set; }
    }

    public class GetBlogQueryHandler : IRequestHandler<GetBlogQueriy, IResultDataControl<List<ReadBlogDto>>>
    {
        private readonly IReadBlogRepositories _readBlogRepositories;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IReadBlogRepositories readBlogRepositories, IMediator mediator, IMapper mapper)
        {
            _readBlogRepositories = readBlogRepositories;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadBlogDto>>> Handle(GetBlogQueriy request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadBlogDto>> result = new ResultDataControl<List<ReadBlogDto>>();
            try
            {
                var blogResult = await _readBlogRepositories.GetAllByOnlineAsync(request.LanguageId);

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
