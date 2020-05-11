using Helpers.Security.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Helper.Security.Attributes
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(Claim claim) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { claim };
        }
    }
}
