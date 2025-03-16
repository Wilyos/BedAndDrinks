using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class AuthorizeByRoleIdAttribute : Attribute, IAuthorizationFilter
{
    private readonly int _roleId; // ID del rol permitido

    public AuthorizeByRoleIdAttribute(int roleId)
    {
        _roleId = roleId;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        // Verificar si el usuario está autenticado
        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        // Obtener el ID del rol desde los Claims
        var roleIdClaim = user.FindFirst("RolId")?.Value;

        if (roleIdClaim == null || !int.TryParse(roleIdClaim, out int roleId) || roleId != _roleId)
        {
            // Redirigir a página de acceso denegado si no tiene el rol permitido
            context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
        }
    }
}
