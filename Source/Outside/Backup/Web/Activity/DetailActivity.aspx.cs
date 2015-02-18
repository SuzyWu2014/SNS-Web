using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Activity
{
     
    public partial class DetailActivity : System.Web.UI.Page
    {
        protected Model.Activity act;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id=Request["id"];

            ActivityBLL bll = new ActivityBLL();
            act = bll.GetModel(id);
           
        }
    }
}