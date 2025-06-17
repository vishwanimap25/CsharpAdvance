using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ProjectEntityManagementWithCRUD.DBcontext;

namespace ProjectEntityManagementWithCRUD.Services
{
    public class JwtServices
    {
        private readonly IConfiguration _configuration;
        private readonly DBContextFile _dbContextFile;
        public JwtServices(DBContextFile dbcontext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContextFile = dbcontext;
        }

 

      
    }
}
