using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.MvcWebUI.AuthFilter
{
    public class AdminAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("SessionAuthorId") == null)
            {
                context.Result = new RedirectResult("/Anasayfa/Index/");
            }
        }
    }
}
