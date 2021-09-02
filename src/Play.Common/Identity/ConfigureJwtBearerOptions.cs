using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Play.Common.Settings;

namespace Play.Common.Identity
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        
        #region Fields
        private readonly IConfiguration _configuration;
        #endregion


        #region Ctor
        public ConfigureJwtBearerOptions(IConfiguration configuration)
        {
            this._configuration = configuration;
        }          
        #endregion


        #region Public methods


        public void Configure(string name, JwtBearerOptions options)
        {
            if (name == JwtBearerDefaults.AuthenticationScheme)
            {
                var serviceSettings = _configuration.GetSection(nameof(ServiceSettings))
                                                    .Get<ServiceSettings>();
                options.Authority = serviceSettings.Authority;
                options.Audience = serviceSettings.ServiceName;
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                };

            }
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(Options.DefaultName,options);
        }
             
        #endregion
    }

}