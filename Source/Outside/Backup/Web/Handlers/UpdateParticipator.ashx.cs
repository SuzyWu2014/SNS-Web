using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Maticsoft.Common;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// UpdateParticipator 的摘要说明 登录用户点击参与/感兴趣
    /// </summary>
    public class UpdateParticipator : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           
            string actId = context.Request["actId"];
            string pId = context.User.Identity.Name;
            string type = context.Request["type"];//0:参加 1：感兴趣  

            Model.ActivityParticipantsMap map = new Model.ActivityParticipantsMap()
            {
                Activity = new Model.Activity() { ID = actId },
                Participants = new Model.Customer() { ID = pId },
                CreateTime = DateTime.Now,
                ID = Assistant.GetID(),
                 Email=context.Request["email"],
                 Tel=context.Request["tel"]
            };
            ActivityBLL actbll = new ActivityBLL();
            switch (type)
            {
                case "00":
                    actbll.UpdateCountJoin(actId, 0);
                    map.RelateType = "join";
                    break;
                case "10":
                    actbll.UpdateCountInterest(actId, 0);
                    map.RelateType = "insterested";
                    break;
                case "01"://删除参与关系
                    actbll.UpdateCountJoin(actId, 1);
                    map.RelateType = "join";
                    break;
                case "11"://删除兴趣关系
                    actbll.UpdateCountInterest(actId, 1);
                    map.RelateType = "insterested";
                    break;
                default:
                    break;
            }

            ActivityParticipantsMapBLL bll = new ActivityParticipantsMapBLL();
            if (type.EndsWith("1"))
            {
                if (bll.Delete(map))
                {
                    //删除映射
                    context.Response.Write("0");

                }
                else
                {
                    context.Response.Write("-1");

                }
            }
            else
            {
                if (bll.Add(map))
                {
                    context.Response.Write("0");

                }
                else
                {
                    context.Response.Write("-1");

                }


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