using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheLearningHub.API.Controllers
    {
    public class CheckClaimsAttribute : Attribute, IAuthorizationFilter
        {

        private readonly string _claimType; // RoleId
        private readonly string _claimValue; // 1

        public CheckClaimsAttribute(string claimType, string claimValue) // RoleId , 1
            {
            _claimType = claimType;
            _claimValue = claimValue;
            }

        public void OnAuthorization(AuthorizationFilterContext context)
            {
            if(!context.HttpContext.User.HasClaim(_claimType , _claimValue)) // RoleId , 1
                {
                context.Result = new UnauthorizedResult();
                }
            }
        }
    }
