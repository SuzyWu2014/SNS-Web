using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetActByUid 的摘要说明: 获得指定用户感兴趣的，参加的，发起的活动列表
    /// </summary>
    public class GetActByUid : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";
            string uid = context.Request["uid"];
            string type = context.Request["type"];

            ActivityBLL bll = new ActivityBLL();
            List<Model.Activity> list = new List<Model.Activity>();
            switch (type)
            {
                case "0":
                    //感兴趣的活动
                    list = bll.GetInterestedModelList(uid);
                    break;
                case "1":
                    //参与的活动
                    list = bll.GetJoinedModelList(uid);
                    break;
                case "2":
                    //发布的活动
                    list = bll.GetLaurchedModelList(uid);
                    break;

                default:
                    break;
            }
           
            context.Response.Write( JsonConvert.SerializeObject(list));
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