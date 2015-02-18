using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.BLL;
using System.Web.Security;

namespace Suzy.Outside.Web.Admin
{
    public partial class Alogin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            AdministratorBLL bll = new AdministratorBLL();
            Model.Administrator admin = bll.GetModel(name, 0);
            if (admin != null && admin.Password == pwd)
            {
                //登录成功 ,创建身份验证票据
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, admin.RealName, DateTime.Now, DateTime.Now.AddDays(7), false, "admin");

                //加密票据
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie hc = new HttpCookie(FormsAuthentication.FormsCookieName);
                //把加密后的票据信息放入cookie
                hc.Value = encryptedTicket;
                //写cookie
                Response.Cookies.Add(hc);
                Response.Redirect("ContentManage/CheckActivity.aspx");
            }
        }

    }
}