using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Maticsoft.Common;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// AlbumHandler 的摘要说明:相册的增删改
    /// </summary>
    public class AlbumHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string type = context.Request["type"];//0:新增；1：更新；2：删除 
            if (type == "0")
            {
                Model.Album model = new Model.Album()
                {
                    ID = Assistant.GetID(),
                    CreateTime = DateTime.Now,
                    Customer = new Model.Customer() { ID = context.User.Identity.Name },
                    Title = context.Request["title"],
                    Des = context.Request["des"] 
                };
                AlbumBLL bll = new AlbumBLL();
                context.Response.Write(bll.Add(model) ? model.ID: "-1");//成功返回ID，否则返回-1
            }

            
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