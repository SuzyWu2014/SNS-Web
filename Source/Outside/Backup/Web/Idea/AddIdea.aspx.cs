using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Idea
{
    public partial class AddIdea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Model.ActivityIdeas idea = new Model.ActivityIdeas()
                {
                    ActivityType = Request["main_t"] + (string.IsNullOrEmpty(Request["sub_t"]) ? "" : "-" + Request["sub_t"]),
                    Creator = new Model.Customer() { ID = Page.User.Identity.Name },
                    Des = Request["des"],
                    ID = Assistant.GetID(),
                    Scope = Request["scope"],
                    Title = Request["topic"],
                    University = Request["proc"] + "-" + Request["city"] + "-" + Request["utc"],
                    Tag = Request["tag"]
                };
                ActivityIdeasBLL bll = new ActivityIdeasBLL();
                bll.Add(idea);
                Response.Redirect("/idea/IdeaDetail.aspx?id="+idea.ID);

            }
        }
    }
}