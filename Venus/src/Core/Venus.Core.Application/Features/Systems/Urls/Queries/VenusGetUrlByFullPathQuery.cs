using MapsterMapper;
using MediatR;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems.Urls.Queries
{
    public class VenusGetUrlByFullPathQuery : IRequest<IResultDataControl<List<ReadVenusUrlDto>>>
    {
        public string FullPath { get; set; }
    }

    public class VenusGetUrlByFullPathQueryHandler : IRequestHandler<VenusGetUrlByFullPathQuery, IResultDataControl<List<ReadVenusUrlDto>>>
    {
        private readonly IReadVenusUrlSystemRepository _urlRepo;
        private readonly IMapper _mapper;
        public VenusGetUrlByFullPathQueryHandler(IReadVenusUrlSystemRepository urlRepo, IMapper mapper)
        {
            _urlRepo = urlRepo;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusUrlDto>>> Handle(VenusGetUrlByFullPathQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusUrlDto>> result = new ResultDataControl<List<ReadVenusUrlDto>>();

            try
            {
                List<VenusUrl> urlList = await this._urlRepo.GetUrlByFullPathAsync(request.FullPath);

                List<ReadVenusUrlDto> listUrlData = this._mapper.Map<List<ReadVenusUrlDto>>(urlList);

                if (listUrlData.Count == 0)
                    throw new VenusNotFoundUrlException(request.FullPath);

                ReadVenusUrlDto url = listUrlData.FirstOrDefault();

                result.SetData(listUrlData);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
