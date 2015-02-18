using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Photo
{
    public partial class PhotoDetail : System.Web.UI.Page
    {
        protected Model.Photo pto;
        protected void Page_Load(object sender, EventArgs e)
        {
            string pid=Request["id"];
            if (pid != "")
            {
                PhotoBLL bll = new PhotoBLL();
                pto = bll.GetModel(pid);
                
            }
            else
            { 
            
            }

        }
    }
}