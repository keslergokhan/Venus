using MapsterMapper;
using MediatR;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems
{
    public class GetVenusPageByUrlIdAndUrlTypeQuery : IRequest<IResultDataControl<ReadVenusPageDto>>
    {
        public Guid UrlId { get; set; }
        public Guid? ParentUrlId { get; set; }
        public short UrlType { get; set; }  
    }

    public class VenusGetPageByUrlIdAndUrlTypeQueryHandler : IRequestHandler<GetVenusPageByUrlIdAndUrlTypeQuery, IResultDataControl<ReadVenusPageDto>>
    {
        private readonly IVenusPageRepository _readVenusPageRepository;
        private readonly IMapper _mapper;

        public VenusGetPageByUrlIdAndUrlTypeQueryHandler(IVenusPageRepository readVenusPageRepository, IMapper mapper)
        {
            _readVenusPageRepository = readVenusPageRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusPageDto>> Handle(GetVenusPageByUrlIdAndUrlTypeQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusPageDto> result = new ResultDataControl<ReadVenusPageDto>();
            try
            {
                VenusPage page = null;

                //if (request.UrlType == (short)PageTypeEnum.Entity)
                //{
                //    page = await _readVenusPageRepository.GetPageByUrlIdAsync(request.ParentUrlId.Value);
                //}
                //else
                //{
                //    page = await _readVenusPageRepository.GetPageByUrlIdAsync(request.UrlId);
                //}


                if (page == null)
                {
                    throw new VenusNotFoundPageException();
                }

                ReadVenusPageDto pageDto = this._mapper.Map<ReadVenusPageDto>(page);
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
