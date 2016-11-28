using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanTest5
{
    /// <summary>
    /// Summary description for geoService
    /// </summary>
    public class geoService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int userCounts;
            if (context.Application["userCounts"] == null)
                userCounts = 0;
            else
                userCounts = (int)context.Application["userCounts"];


            if (context.Application[context.Request["user"]] == null)
            {
                userCounts++;
                context.Application[context.Request["user"]] = "{lat=
                context.Application[context.Request["user"] + "_lat"] = context.Request["lat"];
                context.Application[context.Request["user"] + "_lon"] = context.Request["lon"];
            }

            context.Application["userCounts"] = userCounts;

            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}