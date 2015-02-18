using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.SessionState;
using Maticsoft.Common;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// UploadPhotos 的摘要说明
    /// </summary>
    public class UploadPhotos : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.CacheControl = "no-cache";

            string album = context.Request["album"];
            string actId = context.Request["actId"];
            string uid = context.User.Identity.Name;
            Model.Album am = new Model.Album();
            if (string.IsNullOrEmpty(album) || album.Trim() == "null")
            { 
                AlbumBLL bll = new AlbumBLL();
                am = bll.GetModel(uid, 0);
                if (am == null)
                {
                    //新建一个默认相册 
                    am = new Model.Album();
                    am.Customer = new Model.Customer() { ID = uid };
                    am.Title = "Default";
                    am.CreateTime = DateTime.Now;
                    am.ID = Assistant.GetID();
                    bll.Add(am);
                }
            }
            else
            {
                am.ID = album;
            }
            string updir = string.Empty;
            if (string.IsNullOrEmpty(actId) || actId == "none")
            {
                updir = "/Resource/Images/Upload/personal/" + uid+"/";
            }
            else
            {
                updir = "/Resource/Images/Upload/" + actId + "/";
            }


            if (context.Request.Files.Count > 0)
            {
                PhotoBLL bll = new PhotoBLL();
                try
                {

                    for (int j = 0; j < context.Request.Files.Count; j++)
                    {

                        HttpPostedFile uploadFile = context.Request.Files[j];

                        if (uploadFile.ContentLength > 0)
                        {
                            if (!Directory.Exists(context.Server.MapPath(updir)))
                            {
                                //Directory.CreateDirectory(updir);
                                Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(updir)));//创建文件夹.

                            }
                            string extname = Path.GetExtension(uploadFile.FileName);
                            string fullname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            string filename = fullname + uploadFile.FileName;
                            //插入数据库
                            Model.Photo p = new Model.Photo()
                            {
                                ID = Assistant.GetID(),
                                Activity = new Model.Activity() { ID = actId },
                                Album = am,
                                ImageBigPath = updir + "/" + filename,
                                Title = filename,
                                UploadTime = DateTime.Now,
                                Uploader = new Model.Customer() { ID = uid }
                            };
                            bll.Add(p);
                            uploadFile.SaveAs(context.Server.MapPath(string.Format("{0}/{1}", updir, filename)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write("Message" + ex.ToString());
                }


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