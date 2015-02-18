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
    public partial class EditInfo : System.Web.UI.Page
    {
        protected Customer cmr;
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerBLL bll = new CustomerBLL();
            cmr = bll.GetModel(Page.User.Identity.Name, 0);
            if (IsPostBack)
            { 
                 cmr.College=Request["txtCollege"];
                 cmr.Email = Request["txtEmail"];
                 cmr.EntranceYear=Request["txtEntranceYear"];
                 cmr.Major = Request["txtMajor"];
                 cmr.Nickname = Request["txtNickname"];
                 cmr.RealName = Request["txtRealname"];
                 cmr.Sex = Request["sex"];
                 cmr.University=Request["proc"]+"-"+Request["city"]+"-"+Request["utc"];
                 cmr.IntroSelf = txtDetail.Value;
                 cmr.IsCollegePrivate = Request["ckCollege"]=="on"?true:false;
                 cmr.IsMajorPrivate = Request["ckMajor"] == "on" ? true : false;
                 cmr.IsEntraceYearPrivate = Request["ckYear"] == "on" ? true : false;
                 cmr.IsRealNamePrivate = Request["ckRealname"] == "on" ? true : false;

                 bll.Update(cmr);
            }
        }
    }
}