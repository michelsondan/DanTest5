using Newtonsoft.Json;
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
            List<useInfo> users;

            if (context.Application["users"] == null)
            {
                users = new List<useInfo>();
            }
            else
            {
                users = (List<useInfo>)context.Application["users"];
            }

            var user = from r in users where r.user == context.Request["user"] select r;
            if (user.Count() == 0)
                users.Add(new useInfo() { user = context.Request["user"], lat = context.Request["lat"], lon = context.Request["lon"] });
            else
            {
                users[0].lat = context.Request["lat"];
                users[0].lon = context.Request["lon"];
            }

            context.Application["users"] = users;

            context.Response.Write(JsonConvert.SerializeObject(users));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class useInfo
    {
        public string user { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }
}