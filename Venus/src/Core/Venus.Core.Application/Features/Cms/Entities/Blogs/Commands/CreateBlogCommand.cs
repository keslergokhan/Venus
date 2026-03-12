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
using Venus.Core.Domain.Entities;
using Venus.Core.Domain.Entities.Systems;

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
        private readonly IWriteBlogRepository _writeBlogRepository;
        private readonly IVenusUnitOfWork _venusUnitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IWriteBlogRepository writeBlogRepository, IVenusUnitOfWork venusUnitOfWork, IMapper mapper)
        {
            _writeBlogRepository = writeBlogRepository;
            _venusUnitOfWork = venusUnitOfWork;
            _mapper = mapper;
        }


        public async Task<IResultDataControl<ReadBlogDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadBlogDto> result = new ResultDataControl<ReadBlogDto>();

            try
            {

                var newBlog = _mapper.Map<Blog>(request);

                newBlog.Id = Guid.NewGuid();

                newBlog.Url = new VenusUrl()
                {
                    FullPath = request.UrlPath,
                    Path = request.UrlPath,
                    LanguageId = request.LanguageId,
                };
               

                await _writeBlogRepository.CreateAsync(newBlog,cancellationToken);
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
