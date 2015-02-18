using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected Model.Customer cmr = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.User.Identity.IsAuthenticated && Page.User.IsInRole("customer"))
            {
                string id = Page.User.Identity.Name;
                CustomerBLL bll = new CustomerBLL();
                cmr = bll.GetModel(id, 0);

            }
            else
            {
                //转到登录
                Response.Redirect("/Account/Login.aspx?ReturnUrl=/Home.aspx");
            }
        }
    }
}