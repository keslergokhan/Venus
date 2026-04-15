using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms
{
    public class VenusUrlCheckQuery : IRequest<IResultDataControl<bool>>
    {
        public string UrlPath { get; set; } 
    }

    public class VenusUrlCheckQueryHandler : IRequestHandler<VenusUrlCheckQuery, IResultDataControl<bool>>
    {
        private readonly IVenusUrlRepository _readVenusUrlCms;

        public VenusUrlCheckQueryHandler(IVenusUrlRepository readVenusUrlCms)
        {
            _readVenusUrlCms = readVenusUrlCms;
        }

        public async Task<IResultDataControl<bool>> Handle(VenusUrlCheckQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<bool> respones = new ResultDataControl<bool>();

            try
            {
                bool urlCheckResult = _readVenusUrlCms.UrlCheck(request.UrlPath);
                respones.SetData(urlCheckResult);
            }
            catch (Exception ex)
            {
                respones.Fail(ex);
            }
            return respones;
        }
    }
}
