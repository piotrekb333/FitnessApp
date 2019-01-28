using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitnessApp.Helpers
{
    public static class ClaimsPrincipalHelper
    {
        public static int CurrentUserId(this ClaimsPrincipal principal)
        {
            int userId = -1;
            var user = principal.Claims.FirstOrDefault(m => m.Type == ClaimTypes.Name);
            int.TryParse(user?.Value, out userId);
            return userId;
        }
    }
}
