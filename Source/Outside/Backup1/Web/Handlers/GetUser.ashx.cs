using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetUser 的摘要说明  0:获得fansList  1:获得IdolList 2:获得活动参与者列表 3 ：获得对活动感兴趣者列表
    /// </summary>
    public class GetUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";

            string id = context.Request["id"];
            string type = context.Request["type"];

            CustomerBLL bll = new CustomerBLL();
            string jsonStr = string.Empty;

            switch (type)
            {
                case "0":
                    //获得fansList 
                    jsonStr = JsonConvert.SerializeObject(bll.GetFansModelList(id));
                    break;
                case "1":
                    //获得IdolList
                    jsonStr = JsonConvert.SerializeObject(bll.GetIdolsModelList(id));
                    break;
                case "2":
                   //获得活动参与者列表
                    jsonStr = JsonConvert.SerializeObject(bll.GetJoinedList(id));
                    break;
                case "3":
                    //获得对活动感兴趣者列表
                    jsonStr = JsonConvert.SerializeObject(bll.GetInterestedList(id));
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