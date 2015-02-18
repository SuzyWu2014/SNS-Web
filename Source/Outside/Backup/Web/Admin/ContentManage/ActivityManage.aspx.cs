using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Admin.ContentManage
{
    public partial class ActivityManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lv_activityCheck_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            ActivityBLL bll = new ActivityBLL();
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "pass":
                    bll.SetChecked(id);
                    break;
                case "refuse":
                    bll.SetRefused(id);
                    break;
                case "recommend":
                    bll.SetRecommended(id);
                    break;
                default:
                    break;
            }
            lv_activity.DataBind();
        }



        protected void btnRecommend_Click(object sender, EventArgs e)
        {
            string str = Request["ckb"];
            string[] ids = str.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = "'" + ids[i] + "'";
            }
            if (!string.IsNullOrEmpty(str))
            {
                ActivityBLL bll = new ActivityBLL();
                bll.SetActsRecommended(string.Join(",", ids));
                lv_activity.DataBind();
            }
        }

        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            string str = Request["ckb"];
            string[] ids = str.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = "'" + ids[i] + "'";
            }
            if (!string.IsNullOrEmpty(str))
            {
                ActivityBLL bll = new ActivityBLL();
                bll.SetActsRefused(string.Join(",", ids));
                lv_activity.DataBind();
            }
        }
    }


}