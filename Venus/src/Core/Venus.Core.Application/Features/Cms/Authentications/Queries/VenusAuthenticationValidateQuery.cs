using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Systems.Users;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

namespace Venus.Core.Application.Features.Cms.Authentications.Queries
{

    public class VenusAuthenticationValidateQuery : IRequest<IResultDataControl<ReadVenusUserDto>>
    {
        public string JwtToken { get; set; }
    }

    public class VenusAuthenticationValidateQueryHandler :
        IRequestHandler<VenusAuthenticationValidateQuery, IResultDataControl<ReadVenusUserDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly IVenusAuthenticationCmsRepository _authRepo;
        private readonly IMapper _mapper;

        public VenusAuthenticationValidateQueryHandler(IConfiguration configuration, IVenusAuthenticationCmsRepository authRepo, IMapper mapper)
        {
            this._configuration = configuration;
            this._authRepo = authRepo;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadVenusUserDto>> Handle(VenusAuthenticationValidateQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusUserDto> result = new ResultDataControl<ReadVenusUserDto>();

            var tokenHandler = new JwtSecurityTokenHandler();
            string symmetricSecurityKey = this._configuration.GetValue<string>("SymmetricSecurityKey");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricSecurityKey));

            var parameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidIssuer = "venusapp",
                ValidateAudience = true,
                ValidAudience = "venusapp",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(5) // süresi dolmuş token hemen geçersiz olsun
            };
            

            try
            {
                var principal = tokenHandler.ValidateToken(request.JwtToken, parameters, out SecurityToken validatedToken);

                string userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    throw new VenusCmsUserNotFoundException();
                }

               VenusUser user = await this._authRepo.FindUserByIdAsync(Guid.Parse(userId));

                if (string.IsNullOrEmpty(userId))
                {
                    throw new VenusCmsUserNotFoundException();
                }

                ReadVenusUserDto userDto = this._mapper.Map<ReadVenusUserDto>(user);

                result.SuccessSetData(userDto);

                return result;
            }
            catch(Exception e)
            {
                result.Fail(e);
            }

            return result;
            throw new NotImplementedException();
        }
    }
}
