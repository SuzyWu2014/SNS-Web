using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// AddCmt 的摘要说明
    /// </summary>
    public class AddCmt : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string type = context.Request["type"];
            string uid = context.Request["uid"];
            string oid = context.Request["oid"];//对应评论对象的id
            string content = context.Request["content"];

            switch (type)
            {
                case "0":
                    //添加活动评论
                    Model.Comment4Activity cmt0 = new Model.Comment4Activity()
                    {
                        Activity = new Model.Activity() { ID = oid },
                        Commentator = new Model.Customer() { ID = uid },
                        Content = content,
                        CreateTime = DateTime.Now,
                        ID = Assistant.GetID(),
                        IsTop = true 
                    };

                    BLL.Comment4ActivityBLL bll0 = new BLL.Comment4ActivityBLL();
                    if (bll0.Add(cmt0))
                    {
                        context.Response.Write(1);
                    }
                    else
                    {
                        context.Response.Write(0);
                    }

                    break;
                case "1":
                    //添加照片评论
                    Model.Comment4Photo cmt1 = new Model.Comment4Photo()
                    {
                        Photo = new Model.Photo() { ID = oid },
                        Content = content,
                        CreateTime = DateTime.Now,
                        ID = Assistant.GetID(),
                        Commentator = new Model.Customer() {  ID=uid},
                         IsTop=true
                    };

                    BLL.Comment4PhotoBLL bll1 = new BLL.Comment4PhotoBLL();
                    if (bll1.Add(cmt1))
                    {
                        context.Response.Write(1);
                    }
                    else
                    {
                        context.Response.Write(0);
                    }

                    break;
                case "2":
                    //添加idea评论
                    Model.Comment4Idea cmt2 = new Model.Comment4Idea()
                    {
                        ActivityIdeas = new Model.ActivityIdeas() { ID = oid },
                        Content = content,
                        CreateTime = DateTime.Now,
                        ID = Assistant.GetID(),
                        Commentator = new Model.Customer() {  ID=uid}
                         
                    };

                    BLL.Comment4IdeaBLL bll2 = new BLL.Comment4IdeaBLL();
                    if (bll2.Add(cmt2))
                    {
                        context.Response.Write(1);
                    }
                    else
                    {
                        context.Response.Write(0);
                    }
                    break;
                default:
                    break;
            }

           
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