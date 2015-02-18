using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Idea
{
    public partial class IdeaDetail : System.Web.UI.Page
    {
        protected Model.ActivityIdeas idea = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           string ideaId=Request ["id"];
           ActivityIdeasBLL bll = new ActivityIdeasBLL();
           idea = bll.GetModel(ideaId);

        }
    }
}