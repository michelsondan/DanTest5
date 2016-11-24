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