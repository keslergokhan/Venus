using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Venus.Core.Application.Dtos.Systems.Users;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Helpers;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;
using System.Security.Claims;

namespace Venus.Core.Application.Features.Cms.Authentications.Queries
{
    public  class VenusAuthenticationQuery : IRequest<IResultDataControl<ReadVenusUserDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }    
    }

    public class VenusAuthenticationHandlerQuery : IRequestHandler<VenusAuthenticationQuery, IResultDataControl<ReadVenusUserDto>>
    {
        private readonly IVenusAuthenticationRepository _venusAuth;
        

        public VenusAuthenticationHandlerQuery(IVenusAuthenticationRepository venusAuth)
        {
            _venusAuth = venusAuth;
        }

        public async Task<IResultDataControl<ReadVenusUserDto>> Handle(VenusAuthenticationQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusUserDto> result = new ResultDataControl<ReadVenusUserDto>();
            try
            {
                VenusUser user = await this._venusAuth.FindUserAsync(request.Email,request.Password);

                if (user == null)
                {
                    throw new VenusCmsUserNotFoundException();
                }

                var claims = new[]
                {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key-very-long-12345!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    issuer: "yourapp",
                    audience: "yourapp",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                ReadVenusUserDto userDto = EntityConvertion.Instance.EntityToDto(user);

                userDto.JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                result.SuccessSetData(userDto);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}
