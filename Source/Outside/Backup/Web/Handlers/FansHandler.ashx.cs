using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// FansHandler 的摘要说明  //添加关注，取消关注
    /// </summary>
    public class FansHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string fansId = context.Request["fansId"];
            string idolId = context.Request["idolId"];
            string type = context.Request["type"];
            if (!string.IsNullOrEmpty(fansId) && !string.IsNullOrEmpty(idolId))
            {
                Model.FansIdolMap model = new Model.FansIdolMap()
                {
                    ID = Assistant.GetID(),
                    Idol = new Model.Customer() { ID = idolId },
                    Fans = new Model.Customer() { ID = fansId }
                };
                FansIdolMapBLL bll = new FansIdolMapBLL();//0:存在或成功 1：失败或不存在
                if (type == "0")
                {
                    //关注
                    context.Response.Write(bll.Add(model) ? "0" : "1");
                }
                else if (type == "1")
                {
                    //取消关注 
                    context.Response.Write(bll.Delete(model) ? "0" : "1");
                }
                else
                {
                    //检查是否已关注
                    context.Response.Write(bll.Exists(model) ? "0" : "1");
                }
            }
            else
            {
                context.Response.Write("-1");
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