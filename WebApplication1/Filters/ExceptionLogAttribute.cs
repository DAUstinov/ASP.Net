using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Filters
{
    public class ExceptionLogAttribute : FilterAttribute , IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            ExceptionDetail exceptionDetail = new ExceptionDetail();
            {
                exceptionDetail.ExceptionMessage = filterContext.Exception.Message;
                exceptionDetail.StackTrace = filterContext.Exception.StackTrace;
                exceptionDetail.ControllerName = filterContext.RouteData.Values["controller"].ToString();
                exceptionDetail.ActionName = filterContext.RouteData.Values["action"].ToString();
                exceptionDetail.Date = DateTime.UtcNow;
                
            };

            using ( BookContext db = new BookContext())
            {
                db.ExceptionDetails.Add(exceptionDetail);
                db.SaveChangesAsync();
            }
            filterContext.ExceptionHandled = true;
        }
    }
}