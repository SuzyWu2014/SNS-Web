using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL; 

namespace Suzy.Outside.Web
{
    public partial class Search : System.Web.UI.Page
    {
        protected string key = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
             key=Request["key"];
            ActivityBLL bll = new ActivityBLL();
            rptAct.DataSource = bll.GetSearchResult(key);
            rptAct.DataBind();
       
            CustomerBLL ubll = new CustomerBLL();
            rptUser.DataSource = ubll.GetSearchResult(key);
            rptUser.DataBind();
        }
    }
}