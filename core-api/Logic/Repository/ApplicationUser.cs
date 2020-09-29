using System.Linq;
using Api.Logic.Interface;
using Microsoft.AspNetCore.Http;

namespace Api.Logic.Repository
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            return this._httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(claim => claim.Type == "user_id")?.Value ?? string.Empty;
        }
    }
}
