using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetCmt 的摘要说明
    /// </summary>
    public class GetCmt : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string type = context.Request["type"];
            string oid = context.Request["oid"];//对应评论对象的id

            string jsonStr = string.Empty;
            switch (type)
            {
                case "0":
                    //获取活动评论 
                    BLL.Comment4ActivityBLL bll0 = new BLL.Comment4ActivityBLL();
                    jsonStr = JsonConvert.SerializeObject(bll0.GetModelList(10, "Activity_ID='" + oid+"'", "CreateTime DESC"));

                    break;
                case "1":
                    //获取照片评论 
                    BLL.Comment4PhotoBLL bll1 = new BLL.Comment4PhotoBLL();
                    jsonStr = JsonConvert.SerializeObject(bll1.GetModelList(10, "Photo_ID='" + oid + "'", "CreateTime DESC"));
                    break;
                case "2":
                    //添加idea评论 
                    BLL.Comment4IdeaBLL bll2 = new BLL.Comment4IdeaBLL();
                    jsonStr = JsonConvert.SerializeObject(bll2.GetModelList(10, "ActivityIdeas_ID='" + oid + "'", "CreateTime DESC"));
                    break;
                default:
                    break;
            }

            context.Response.Write(jsonStr);

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