using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Suzy.Outside.BLL;
using Suzy.Outside.Model;
using Maticsoft.Common;
using System.Web.Security;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// Login 的摘要说明:处理登录及注册 
    /// Type：0--> 登录 ，1-->验证用户名  ， 2-->注册 , 3 退出
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string uName = context.Request["userName"];
            string pwd = context.Request["pwd"];
            string type = context.Request["type"];

            int result = -1;//未知错误
            CustomerBLL bll = new CustomerBLL();
            if (type == "0")
            {
                //----login-----0：登录成功  1：用户名不存在  2：密码错误    3：验证码错误
                string code = context.Request["Code"];
                if (code.ToLower() == context.Session["CheckCode"].ToString().ToLower())
                {

                    Customer user = bll.GetModel(uName);
                    if (user != null)
                    {
                        if (pwd == user.Password)
                        {
                            //登录成功 ,创建身份验证票据
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.ID, DateTime.Now, DateTime.Now.AddDays(7), false, "customer");

                            //加密票据
                            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                            HttpCookie hc = new HttpCookie(FormsAuthentication.FormsCookieName);
                            //把加密后的票据信息放入cookie
                            hc.Value = encryptedTicket;
                            //写cookie
                           
                            context.Response.Cookies.Add(hc);
                            context.Response.Cookies.Add(SetCookie(user.UserName, user.Password));
                            result = 0;
                        }
                        else
                        {
                            //密码错误
                            result = 2;
                        }
                    }
                    else
                    {
                        //用户不存在
                        result = 1;
                    }
                }
                else
                {
                    //验证码错误
                    result = 3;
                }
            }
            else if (type == "1")
            {
                //CheckUser:   0 用户名可用，1：用户名已存在
                result = bll.Exists(uName) ? 1 : 0;
            }
            else if (type == "2")
            {
                //注册   0 ：注册成功  1：注册失败  
                if (!bll.Exists(uName))
                {

                    Customer user = new Customer()
                    {
                        ID = Assistant.GetID(),
                        UserName = uName,
                        Password = pwd,
                        CreateTime = DateTime.Now
                    };
                    result = bll.Add(user) ? 0 : 1;
                }
                else
                {
                    result = 1;
                }
            }
            else if (type == "3")
            {
                FormsAuthentication.SignOut();
                result = 1;
            }

            context.Response.Write(result);

        }

        public HttpCookie SetCookie(string name, string pwd)
        {
            HttpCookie cookie = new HttpCookie("cmr");
            cookie.Values["name"] = name;
            cookie.Values["pwd"] = pwd;

            cookie.Expires = DateTime.Now.AddDays(7);

            return cookie;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}