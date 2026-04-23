using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Systems.Pages.Queries
{
    public class GetEntityDetailVenusPageByEntityName : IRequest<IResultDataControl<ReadVenusPageDto>>
    {
        public string EntityTypeFullName { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class GetEntityDetailVenusPageByEntityNameHandler : IRequestHandler<GetEntityDetailVenusPageByEntityName, IResultDataControl<ReadVenusPageDto>>
    {
        private readonly IVenusPageRepository _venusPageRepository;
        private readonly IMapper _mapper;

        public GetEntityDetailVenusPageByEntityNameHandler(IVenusPageRepository venusPageRepository, IMapper mapper)
        {
            _venusPageRepository = venusPageRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusPageDto>> Handle(GetEntityDetailVenusPageByEntityName request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusPageDto> result = new ResultDataControl<ReadVenusPageDto>();

            try
            {
                var page = await _venusPageRepository.GetEntityDetailPageByEntityNameAsync(request.EntityTypeFullName, request.LanguageId);
                result.SuccessSetData(_mapper.Map<ReadVenusPageDto>(page));
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }

}
