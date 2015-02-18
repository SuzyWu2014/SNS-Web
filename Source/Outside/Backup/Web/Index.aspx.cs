using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected string type;
        protected string time = "all";
        protected string people;
        protected string repType;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["activityType"];
            time = Request["activityTime"];
            people = Request["people"];
            repType = Request["ReqType"];
            int[] dayrange;
            type = string.IsNullOrEmpty(type) ? "all" : type;
            switch (time)
            {
                case "all":
                case "": dayrange = null; time = "all"; break;
                case "today": dayrange = new int[2] { 0, 0 }; break;
                case "week": dayrange = new int[2] { 0, 7 }; break;
                case "month": dayrange = new int[2] { 0, 30 }; break;
                default: dayrange = new int[2] { -1, -1 }; break;//周末 
            }
            people = string.IsNullOrEmpty(people) ? "all" : people;
            string pid = string.Empty;
            if (people != "all")
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    pid = Page.User.Identity.Name; //登录用户Id
                }
                else
                {
                    //用户未登录
                    string ReturnUrl = "activityType=" + type + "&activityTime";
                    Response.Redirect("/Account/Login.aspx");

                }
            }
            else 
            {
                pid = "all";
            }

            repType = string.IsNullOrEmpty(repType) ? "acts" : repType;
            if (repType == "acts")
            {
                ActivityBLL bll = new ActivityBLL();
                 List<Model.Activity> list=  bll.GetModelList(type, dayrange, pid, 0, 15);
                 if (list .Count>0)
                 {
                     msg.Text = "";
                     rptAct.DataSource = list;
                     rptAct.DataBind();
                 }
                 else
                 {
                     msg.Text = "还没有活动哦~~╮(╯▽╰)╭~~~~";
                 }
            }
            else
            {
                //查看时景照片：今日的活动，上传的活动照片
                PhotoBLL bll = new PhotoBLL();
                List<Model.Photo>  list = bll.GetPagedModelList(type, dayrange, pid, 0, 15);
                if (list.Count>0)
                {
                    msg.Text = "";
                    rptPto.DataSource = list;
                    rptPto.DataBind();
                }
                else
                {
                    msg.Text = "没有相关的照片~~╮(╯▽╰)╭~~";
                }
            }
        }
    }
}