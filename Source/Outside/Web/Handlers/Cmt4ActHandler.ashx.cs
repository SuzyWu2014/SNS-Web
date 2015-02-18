using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// Cmt4ActHandler 的摘要说明
    ///   获取活动评论及提交评论
    /// </summary>
    public class Cmt4ActHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string type = context.Request["type"];

            if (type == "1")
            {
                //获得评论
                string actId = context.Request["actId"];
                Comment4ActivityBLL bll = new Comment4ActivityBLL();

                ReqData data = new ReqData()
                {
                    list = bll.GetModelList("Activity_ID='" + actId + "'")
                };

                if (data.list != null && data.list.Count > 0)
                {

                    data.HasData = 1;
                }
                else
                {

                    data.HasData = 0;
                }
                string jsonStr = JsonConvert.SerializeObject(data);
                context.Response.Write(jsonStr);
            }


        }

        [Serializable]
        public class ReqData
        {
            public int HasData { get; set; }
            public List<Model.Comment4Activity> list { get; set; }
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