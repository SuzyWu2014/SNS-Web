using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Suzy.Outside.Web.Photo
{
    public partial class PhotoWall : System.Web.UI.Page
    {
        protected string uid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            uid=Request["uid"];
        }
    }
}