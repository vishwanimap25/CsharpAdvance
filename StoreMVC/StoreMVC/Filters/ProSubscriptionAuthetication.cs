using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreMVC.Services;

namespace StoreMVC.Filters
{
    public class ProSubscriptionAuthetication : IAsyncAuthorizationFilter  //or IAuthorizationFilter 
    {
        private readonly ApplicationDBcontext dbcontext;

        public ProSubscriptionAuthetication(ApplicationDBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if(user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Accessdenied", "Home", null);
                return;
            }
            var userid = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(string.IsNullOrEmpty(userid))
            {
                context.Result = new RedirectToActionResult("Accessdenied", "Home", null);
                return;
            }


            //get the user's subscription plan from the database
            var userPlan = await dbcontext.User.Where(x => x.UserId == userid).Select(u => u.userPlan).FirstOrDefaultAsync();
        }
    }
}
