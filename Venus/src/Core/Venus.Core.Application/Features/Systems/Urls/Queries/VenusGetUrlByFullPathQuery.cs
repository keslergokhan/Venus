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
using Venus.Core.Application.Helpers;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.VenusDbContext.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems.Urls.Queries
{
    public class VenusGetUrlByFullPathQuery : IRequest<IResultDataControl<List<ReadVenusUrlDto>>>
    {
        public string FullPath { get; set; }
    }

    public class VenusGetUrlByFullPathQueryHandler : IRequestHandler<VenusGetUrlByFullPathQuery, IResultDataControl<List<ReadVenusUrlDto>>>
    {
        private readonly IReadVenusUrlRepository _urlRepo;

        public VenusGetUrlByFullPathQueryHandler(IReadVenusUrlRepository urlRepo)
        {
            _urlRepo = urlRepo;
        }

        public async Task<IResultDataControl<List<ReadVenusUrlDto>>> Handle(VenusGetUrlByFullPathQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusUrlDto>> result = new ResultDataControl<List<ReadVenusUrlDto>>();
            try
            {
                List<VenusUrl> urlList = await this._urlRepo.GetUrlByFullPathAsync(request.FullPath);
                if (urlList==null && !urlList.Any()){
                    throw new VenusNotFoundUrlException(request.FullPath);
                }

                var sss = urlList.Select(x=>EntityConvertion.Instance.EntityToDto(x)).ToList();
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
