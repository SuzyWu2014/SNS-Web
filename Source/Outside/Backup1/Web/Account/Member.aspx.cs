using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.Model;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Account
{
    public partial class Member : System.Web.UI.Page
    {
        protected Customer cmr = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request["uid"];
            CustomerBLL bll = new CustomerBLL();
            cmr = bll.GetModel(uid, 0);
            if(uid==Page.User.Identity.Name)
            {
                Response.Redirect("/Home.aspx");
            }
        }
    }
}