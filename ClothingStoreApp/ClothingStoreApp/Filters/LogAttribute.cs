using ClothingStoreApp.Models;
using System;
using System.Web.Mvc;

namespace ClothingStoreApp.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            Visitor visitor = new Visitor()
            {
                Ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Url = request.RawUrl,
                Date = DateTime.UtcNow
            };

            using (ClothesAppDbContext db = new ClothesAppDbContext())
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
            }

            base.OnActionExecuting(filterContext);

        }
    }
}