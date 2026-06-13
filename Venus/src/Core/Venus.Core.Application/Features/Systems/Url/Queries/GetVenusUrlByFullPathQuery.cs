using MapsterMapper;
using MediatR;
using Venus.Core.Application.Dtos.Systems.Urls;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Systems.Queries
{
    /// <summary>
    /// <c>FullPath</c> dikkat ederek <see cref="VenusUrl"/> getirir.
    /// </summary>
    /// <remarks>
    /// <c>FullPath</c> değerini <see cref="IVenusUrlRepository.GetUrlByFullPathAsync(string)"/> filtresinden geçirir.
    /// </remarks>
    public class GetVenusUrlByFullPathQuery : IRequest<IResultDataControl<List<ReadVenusUrlDto>>>
    {
        public string FullPath { get; set; }
    }

    public class VenusGetUrlByFullPathQueryHandler : IRequestHandler<GetVenusUrlByFullPathQuery, IResultDataControl<List<ReadVenusUrlDto>>>
    {
        private readonly IVenusUrlRepository _urlRepo;
        private readonly IMapper _mapper;
        public VenusGetUrlByFullPathQueryHandler(IVenusUrlRepository urlRepo, IMapper mapper)
        {
            _urlRepo = urlRepo;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadVenusUrlDto>>> Handle(GetVenusUrlByFullPathQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadVenusUrlDto>> result = new ResultDataControl<List<ReadVenusUrlDto>>();

            try
            {
                List<VenusUrl> urlList = await this._urlRepo.GetUrlByFullPathAsync(request.FullPath);

                List<ReadVenusUrlDto> listUrlData = this._mapper.Map<List<ReadVenusUrlDto>>(urlList);

                if (listUrlData.Count == 0)
                    throw new VenusNotFoundUrlSystemException(request.FullPath);

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
