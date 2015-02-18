using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetAlbums 的摘要说明
    /// </summary>
    public class GetAlbums : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";

            string uid = context.Request["uid"];

            AlbumBLL bll = new AlbumBLL();
            List<Model.Album> list = bll.GetModelList("Customer_ID='" + uid+"'"); 
            context.Response.Write(JsonConvert.SerializeObject(list));
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