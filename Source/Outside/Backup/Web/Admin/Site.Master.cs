using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Suzy.Outside.Web.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.IsInRole("admin"))
            {
                Response.Redirect("/Admin/Alogin.aspx");
            }
        }
    }
}