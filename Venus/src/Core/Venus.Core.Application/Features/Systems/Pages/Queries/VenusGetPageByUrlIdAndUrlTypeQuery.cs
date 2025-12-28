using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Mappers.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems.Pages.Queries
{
    public class VenusGetPageByUrlIdAndUrlTypeQuery : IRequest<IResultDataControl<ReadVenusPageDto>>
    {
        public Guid UrlId { get; set; }
        public Guid? ParentUrlId { get; set; }
        public short UrlType { get; set; }  
    }

    public class VenusGetPageByUrlIdAndUrlTypeQueryHandler : IRequestHandler<VenusGetPageByUrlIdAndUrlTypeQuery, IResultDataControl<ReadVenusPageDto>>
    {
        private readonly IReadVenusPageSystemRepository _readVenusPageSystemRepository;
        private readonly IMapperProvider _mapperProvider;

        public VenusGetPageByUrlIdAndUrlTypeQueryHandler(IReadVenusPageSystemRepository readVenusPageSystemRepository, IMapperProvider mapperProvider)
        {
            _readVenusPageSystemRepository = readVenusPageSystemRepository;
            _mapperProvider = mapperProvider;
        }

        public async Task<IResultDataControl<ReadVenusPageDto>> Handle(VenusGetPageByUrlIdAndUrlTypeQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusPageDto> result = new ResultDataControl<ReadVenusPageDto>();
            try
            {
                VenusPage page = null;

                if (request.UrlType == (short)UrlTypeEnum.Detail)
                {
                    page = await _readVenusPageSystemRepository.GetPageByUrlIdAsync(request.ParentUrlId.Value);
                }
                else
                {
                    page = await _readVenusPageSystemRepository.GetPageByUrlIdAsync(request.UrlId);
                }


                if (page == null)
                {
                    throw new VenusNotFoundPageException();
                }

                ReadVenusPageDto pageDto = _mapperProvider.VenusPageMapper.ToDto(page);
                result.SetData(pageDto);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
