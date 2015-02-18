using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Idea
{
    public partial class IdeaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActivityIdeasBLL bll = new ActivityIdeasBLL();
            rptIdea.DataSource = bll.GetList("");
            rptIdea.DataBind();
        }
    }
}