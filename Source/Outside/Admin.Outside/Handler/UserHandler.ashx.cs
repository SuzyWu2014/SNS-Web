using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;

namespace Admin.Outside.Handler
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            AdministratorBLL bll = new AdministratorBLL();
            context.Response.Write(JsonConvert.SerializeObject(  bll.GetModelList("")));
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