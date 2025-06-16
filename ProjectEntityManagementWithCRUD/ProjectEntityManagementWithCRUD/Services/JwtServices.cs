using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjectEntityManagementWithCRUD.Services
{
    public class JwtServices
    {
        private readonly IConfiguration _configuration;
        public JwtServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      
    }
}
