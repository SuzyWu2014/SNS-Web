using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Admin.Outside.SysManage
{
    public partial class AdminUserManage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LVadmin_OnItemInserting(object sender, ListViewInsertEventArgs e)
        {
            e.Values["ID"] = Assistant.GetID();
        }

        protected void LVadmin_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
           
        }
    }
}