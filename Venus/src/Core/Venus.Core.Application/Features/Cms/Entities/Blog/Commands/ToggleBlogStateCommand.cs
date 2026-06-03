using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Entities;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms.Command
{
    public class ToggleBlogStateCommand : IRequest<IResultControl>
    {
        public Guid Id { get; set; }
    }

    public class ToggleBlogStateHandlerHandler : IRequestHandler<ToggleBlogStateCommand, IResultControl>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IVenusUnitOfWork   _venusUnitOfWork;
        public ToggleBlogStateHandlerHandler(IBlogRepository blogRepository, IVenusUnitOfWork venusUnitOfWork)
        {
            _blogRepository = blogRepository;
            _venusUnitOfWork = venusUnitOfWork;
        }
        public async Task<IResultControl> Handle(ToggleBlogStateCommand request, CancellationToken cancellationToken)
        {
            IResultControl resultControl = new ResultControl();
            try
            {
                var blog = await _blogRepository.GetByIdAsync(request.Id);
                if (blog == null)
                    throw new VenusCmsBusinessException("Blog not found.");

                if (blog.State == (int)EntityStateEnum.Online)
                {
                    blog.State = (int)EntityStateEnum.Offline;
                }
                else if(blog.State == (int)EntityStateEnum.Offline)
                {
                    blog.State = (int)EntityStateEnum.Online;
                }

                await _venusUnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                resultControl.Fail(ex);
            }

            return resultControl;
        }
    }
}
