using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.LanguageResource;
using Venus.Core.Application.Dtos.Systems.Localizations;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Repositories.Interfaces;
using Venus.Core.Application.Repositories.Interfaces.Systems;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Features.Cms
{
    public class UpdateVenusLanguageResourceCommand : IRequest<IResultControl>
    {
        public string LanguageResourceValue { get; set; }
        public Guid LanguageId { get; set; }
        public Guid ResourceId { get; set; }

    }

    public class UpdateVenusLanguageResourceCommandHandler :
        IRequestHandler<UpdateVenusLanguageResourceCommand, IResultControl>
    {
        private readonly IVenusUnitOfWork _unitOfWork;
        private readonly IVenusLanguageResourceValueRepository  _venusLanguageResourceValueRepository;

        public UpdateVenusLanguageResourceCommandHandler(IVenusLanguageResourceValueRepository venusLanguageResourceValueRepository, IVenusUnitOfWork unitOfWork)
        {
            _venusLanguageResourceValueRepository = venusLanguageResourceValueRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResultControl> Handle(UpdateVenusLanguageResourceCommand request, CancellationToken cancellationToken)
        {

            IResultControl result = new ResultControl();
            try
            {
                var resourceValue = await _venusLanguageResourceValueRepository.GetByLanguageIdAndResourceKeyIdAsync(request.LanguageId, request.ResourceId);

                if (resourceValue == null)
                    throw new VenusCmsBusinessException("Resource value not found");


                resourceValue.Value = request.LanguageResourceValue;
                resourceValue.ModifiedDate = DateTime.Now;
                await _unitOfWork.SaveChangesAsync();


                result.Success();
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }
            return result;
        }
    }
}
