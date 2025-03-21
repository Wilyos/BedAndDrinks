using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

public class AuthorizeByPermissionAttribute : TypeFilterAttribute
{
    public AuthorizeByPermissionAttribute(params string[] permissions) : base(typeof(AuthorizeByPermissionFilter))
    {
        Arguments = new object[] { permissions };
    }
}

public class AuthorizeByPermissionFilter : IAuthorizationFilter
{
    private readonly string[] _permissions;

    public AuthorizeByPermissionFilter(string[] permissions)
    {
        _permissions = permissions;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        var userPermissions = user.Claims.Where(c => c.Type == "Permiso").Select(c => c.Value).ToList();

        // Verifica si el usuario tiene al menos uno de los permisos requeridos
        if (!_permissions.Any(p => userPermissions.Contains(p)))
        {
            context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
        }
    }
}
