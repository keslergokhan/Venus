using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Claims;
using System.Text;
using Venus.Core.Application.Dtos.Systems.Users;
using Venus.Core.Application.Exceptions.Cms;
using Venus.Core.Application.Helpers;
using Venus.Core.Application.Repositories.Interfaces.Cms;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Domain.Entities.Systems;

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
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IConfiguration _config;


        public VenusAuthenticationHandlerQuery(IVenusAuthenticationRepository venusAuth, IHttpContextAccessor httpAccessor, IConfiguration config)
        {
            _venusAuth = venusAuth;
            _httpAccessor = httpAccessor;
            _config = config;
        }

        public async Task<IResultDataControl<ReadVenusUserDto>> Handle(VenusAuthenticationQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadVenusUserDto> result = new ResultDataControl<ReadVenusUserDto>();
            try
            {

                string domain = this._config.GetValue<string>("domain");

                if (string.IsNullOrEmpty(domain))
                {
                    throw new ArgumentException($" domain config not null !");
                }

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
                    issuer: "venusapp",
                    audience: "venusapp",
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

                ReadVenusUserDto userDto = EntityConvertion.Instance.EntityToDto(user);

                userDto.JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                var sss = this._httpAccessor.HttpContext.Request.Cookies["venus_user"];

                var cookieOptions = new CookieOptions
                {
                    Secure = false,               // localhost için
                    HttpOnly = true,
                    Domain = null,                // localhost’ta boş bırak
                    Path = "/",
                    SameSite = SameSiteMode.None, // cross-origin
                    Expires = DateTime.UtcNow.AddDays(1)
                };

                this._httpAccessor.HttpContext.Response.Cookies.Append("venus_user",userDto.JwtToken, cookieOptions);
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
