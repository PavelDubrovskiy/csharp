using Mfc.Health.Corner.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;


namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Id { get; }

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            var claimsMap = _httpContextAccessor?.HttpContext?.User.Claims;

            var idClaim = claimsMap.FirstOrDefault(x => x.Type == ClaimTypes.Sid);

            if (idClaim != null)
            {
                Id = idClaim.Value;
            }
        }
    }
}
