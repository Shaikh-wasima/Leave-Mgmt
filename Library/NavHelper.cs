using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Library
{
    public static class NavHelper
    {
        public static string IsActive(this IUrlHelper urlHelper, string controller, string action, string currentController, string currentAction)
        {
            return (controller == currentController && action == currentAction) ? "active" : "";
        }
    }
}
