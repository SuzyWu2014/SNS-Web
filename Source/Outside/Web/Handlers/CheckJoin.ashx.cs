using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// CheckJoin 的摘要说明 
    ///   检查用户是否已点击参与/感兴趣
    /// </summary>
    public class CheckJoin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string actId = context.Request["actId"];
            string pId = context.User.Identity.Name;


            Model.ActivityParticipantsMap mapJ = new Model.ActivityParticipantsMap()
            {
                Activity = new Model.Activity() { ID = actId },
                Participants = new Model.Customer() { ID = pId },
                RelateType = "join"
            };
            Model.ActivityParticipantsMap mapI = new Model.ActivityParticipantsMap()
            {
                Activity = new Model.Activity() { ID = actId },
                Participants = new Model.Customer() { ID = pId },
                RelateType = "insterested"
            };
            ActivityParticipantsMapBLL bll = new ActivityParticipantsMapBLL();
            context.Response.Write((bll.Exists(mapJ) ? "0" : "1") + (bll.Exists(mapI) ? "0" : "1"));


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