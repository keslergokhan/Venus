using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Entities.Blogs;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Domain.Entities;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms
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
        private readonly IBlogRepository _blogRepository;
        private readonly IVenusEntityPageService<Blog> _blogPageService;
        private readonly IVenusUnitOfWork _venusUnitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IVenusUnitOfWork venusUnitOfWork, IMapper mapper, IVenusEntityPageService<Blog> blogPageService)
        {
            _blogRepository = blogRepository;
            _venusUnitOfWork = venusUnitOfWork;
            _mapper = mapper;
            _blogPageService = blogPageService;
        }


        public async Task<IResultDataControl<ReadBlogDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadBlogDto> result = new ResultDataControl<ReadBlogDto>();

            try
            {
                var entityPageUrl = await _blogPageService.GetEntityDetailPageByEntityNameAsync(request.LanguageId);
                var newBlog = _mapper.Map<Blog>(request);

                newBlog.Id = Guid.NewGuid();

                newBlog.Url = new VenusUrl()
                {
                    FullPath = request.UrlPath,
                    Path = request.UrlPath,
                    LanguageId = request.LanguageId,
                    ParentUrlId = entityPageUrl.Url.Id
                };
               

                await _blogRepository.CreateAsync(newBlog,cancellationToken);
                int saveResult = await _venusUnitOfWork.SaveChangesAsync(cancellationToken);

                if (saveResult <= 0)
                    throw new VenusDataCreationFailedException(nameof(ReadBlogDto));

                ReadBlogDto readBlogDto = _mapper.Map<ReadBlogDto>(newBlog);

                result.SetData(readBlogDto);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
