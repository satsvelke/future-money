using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Logic.Filters
{
    public class VerifyToken : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // var token1 = context.HttpContext.Request.Headers["Authorization"];
            // var d = token1.ToString().Split(" ");
            // var s = d[1];
            // var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
            // Task<FirebaseToken> task = FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(s);
            // task.Wait();
            // var sss = task.Result.Uid;
        }
    }
}
