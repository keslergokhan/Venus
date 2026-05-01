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
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Domain.Entities;

namespace Venus.Core.Application.Features.Cms.Entities.Blogs.Commands
{
    public class UpdateBlogCommand : IRequest<IResultDataControl<ReadBlogDto>>, IDynamicPropertyRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlPath { get; set; }
        public string DynamicProperties { get; set; }
    }

    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, IResultDataControl<ReadBlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IVenusEntityPageService<Blog> _blogPageService;
        private readonly IVenusUnitOfWork _venusUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IVenusUnitOfWork venusUnitOfWork, IMapper mapper, IVenusEntityPageService<Blog> blogPageService)
        {
            _blogRepository = blogRepository;
            _venusUnitOfWork = venusUnitOfWork;
            _mapper = mapper;
            _blogPageService = blogPageService;
        }

        public async Task<IResultDataControl<ReadBlogDto>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadBlogDto> result = new ResultDataControl<ReadBlogDto>();
            try
            {
                var blog = await _blogRepository.GetByIdAsync(request.Id, cancellationToken);

                if (blog == null)
                    throw new VenusCmsBusinessException("Blog not found !");

                blog.Title = request.Title;
                blog.Description = request.Description;
                blog.Url.Path = request.UrlPath;
                blog.DynamicProperties = request.DynamicProperties;

                _blogRepository.Update(blog);

                await _venusUnitOfWork.SaveChangesAsync(cancellationToken);
                var blogDto = _mapper.Map<ReadBlogDto>(blog);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
