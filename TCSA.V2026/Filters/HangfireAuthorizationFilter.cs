using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace TCSA.V2026.Filters;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize([NotNull] DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        if (httpContext.User.Identity?.IsAuthenticated ?? false)
        {
            return httpContext.User.IsInRole("Admin");
        }

        return false;
    }
}
