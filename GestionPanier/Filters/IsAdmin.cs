using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestionPanier.Filters
{
    public class IsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Role") == null || context.HttpContext.Session.GetString("Role") != "admin")
            {
              //  context.HttpContext.Response.Redirect("Login/User");
              context.Result = new RedirectResult("/Users/Login");
            }
        }
    }
}
