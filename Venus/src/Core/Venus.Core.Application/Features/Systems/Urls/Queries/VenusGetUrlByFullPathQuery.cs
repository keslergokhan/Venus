using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems.Urls.Queries
{
    public class VenusGetUrlByFullPathQuery : IRequest<IResultDataControl<ReadVenusUrlDto>>
    {
        public string FullPath { get; set; }
    }

    public class VenusGetUrlByFullPathQueryHandler : IRequestHandler<VenusGetUrlByFullPathQuery, IResultDataControl<ReadVenusUrlDto>>
    {
        private readonly IReadVenusUrlRepository _urlRepo;

        public VenusGetUrlByFullPathQueryHandler(IReadVenusUrlRepository urlRepo)
        {
            _urlRepo = urlRepo;
        }

        public async Task<IResultDataControl<ReadVenusUrlDto>> Handle(VenusGetUrlByFullPathQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusUrlDto> result = new ResultDataControl<ReadVenusUrlDto>();
            try
            {
                VenusUrl urlList = await this._urlRepo.GetUrlByFullPathAsync(request.FullPath);
                if (urlList==null)
                {
                    throw new VenusNotFoundUrlException(request.FullPath);
                }

                

                
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
