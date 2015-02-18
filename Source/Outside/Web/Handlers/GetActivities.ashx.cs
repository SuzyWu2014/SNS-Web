using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;
using System.Text;
using System.Web.UI;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetActivities 的摘要说明：主页筛选
    /// </summary>
    public class GetActivities : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";//text/javascript
            string type = context.Request["activityType"];
            string time = context.Request["activityTime"];
            string people = context.Request["people"];
            string repType = context.Request["ReqType"];
            int page = string.IsNullOrEmpty(context.Request["page"]) ?1 : Convert.ToInt32(context.Request["page"]);
            int[] dayrange;
            switch (time)
            {
                case "all": dayrange = null; break;
                case "today": dayrange = new int[2] { 0, 0 }; break;
                case "week": dayrange = new int[2] { 0, 7 }; break;
                case "month": dayrange = new int[2] { 0, 30 }; break;
                default: dayrange = new int[2] { -1, -1 }; break;//周末 
            }

            if (people != "all")
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    people = context.User.Identity.Name; //登录用户Id
                }
                else
                {
                    //用户未登录
                    context.Response.Redirect("/Account/Login.aspx");
                }
            }
            string jsonStr = string.Empty;
            if (repType == "acts")
            {
                ActivityBLL bll = new ActivityBLL();
                List<Model.Activity> list = bll.GetModelList(type, dayrange, people, page*15, (page+1)+15);
                List<ActivityIntro> aiList = new List<ActivityIntro>();
                for (int i = 0; i < list.Count; i++)
                {
                    aiList.Add(new ActivityIntro()
                    {
                        ActivityStatus = list[i].ActivityStatus,
                        ActivityType = list[i].ActivityType,
                        AdminAttitude = list[i].AdminAttitude,
                        Detail = list[i].Detail,
                        Id = list[i].ID,
                        PlaceType = list[i].PlaceType,
                        PosterPath = list[i].PosterPath,
                        SponsorId = list[i].Sponsor.ID,
                        SponsorName = string.IsNullOrEmpty(list[i].Sponsor.Nickname )? "< User Lazy >" : list[i].Sponsor.Nickname,
                        Tag = list[i].Tag,
                        TimeCycle = list[i].TimeCycle,
                        TimeDes = list[i].TimeDes,
                        Topic = list[i].Topic,
                        University = list[i].University
                    });
                }
                jsonStr = JsonConvert.SerializeObject(aiList);
            }
            else
            {
                PhotoBLL bll = new PhotoBLL();
                jsonStr = JsonConvert.SerializeObject(bll.GetListByPage(type, dayrange, people, page * 15, (page + 1) * 15));
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

        [Serializable]
        public class ActivityIntro
        {
            public string Id { get; set; }
            public string Topic { get; set; }
            public string ActivityType { get; set; }
            public string TimeDes { get; set; }
            public string TimeCycle { get; set; }
            public string PosterPath { get; set; }
            public string PlaceType { get; set; }
            public string University { get; set; }
            public string ActivityStatus { get; set; }
            public string AdminAttitude { get; set; }
            public string Detail { get; set; }
            public string Tag { get; set; }
            public string SponsorId { get; set; }
            public string SponsorName { get; set; }
        }
    }
}