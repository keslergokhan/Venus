using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Enums.Systems;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Features.Interfaces;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms
{
    public class CreateVenusPageCommand : IRequest<IResultDataControl<ReadVenusPageDto>>,
         ILanguageRequest
    {
        public string UrlPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PageAboutId { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class CreateVenusPageCommandHandler : IRequestHandler<CreateVenusPageCommand, IResultDataControl<ReadVenusPageDto>>
    {
        private readonly IWriteVenusPageCmsRepository _writeVenusPageCmsRepository;
        private readonly IVenusUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVenusPageCommandHandler(IVenusUnitOfWork unitOfWork, IWriteVenusPageCmsRepository writeVenusPageCmsRepository,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _writeVenusPageCmsRepository = writeVenusPageCmsRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusPageDto>> Handle(CreateVenusPageCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusPageDto> result = new ResultDataControl<ReadVenusPageDto>(); 
            try
            {
                Guid ID = Guid.NewGuid();
                VenusPage newVenusPage = new VenusPage();
                newVenusPage.Id = ID;
                newVenusPage.Name = request.Title;
                newVenusPage.Description = request.Description;
                newVenusPage.PageAboutId = request.PageAboutId;
                newVenusPage.LanguageId = request.LanguageId;
                newVenusPage.State = (int)EntityStateEnum.Online;

                VenusUrl newPageUrl = new VenusUrl();
                newPageUrl.Path = request.UrlPath;
                newPageUrl.LanguageId = request.LanguageId;
                newPageUrl.FullPath = request.UrlPath;
                newVenusPage.Url = newPageUrl;

                await _writeVenusPageCmsRepository.CreateAsync(newVenusPage,cancellationToken);
                
                int saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);
                if (saveResult <= 0)
                    throw new VenusDataCreationFailedException(nameof(ReadVenusPageDto));

                ReadVenusPageDto readVenusPageDto = _mapper.Map<ReadVenusPageDto>(newVenusPage);
                result.SetData(readVenusPageDto);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
