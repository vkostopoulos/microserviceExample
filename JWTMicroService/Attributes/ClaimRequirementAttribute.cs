using JWTMicroService.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTMicroService.Attributes
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
