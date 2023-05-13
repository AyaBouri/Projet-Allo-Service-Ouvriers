using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace AlloServicePFA.Filtres
{
    public class IsAdmin:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Role") != null && context.HttpContext.Session.GetString("Role") == "WebMaster" != null)
            {
                //context.HttpContext.Response.Redirect("/User/Login");
                context.Result = new RedirectResult("/User/Login");
            }
        }
        
    }
}