using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetPhotos 的摘要说明
    ///     查询照片信息 包括：1--> 活动关联照片  2-->个人相册   3-->相册对应照片信息  4--获得用户上传的所有照片
    ///     
    /// </summary>
    public class GetPhotos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Application/json";

            string type = context.Request["type"];
            string uid = context.Request["uid"];
            PhotoBLL bll = new PhotoBLL();
            string jsonStr = string.Empty;
            if (type == "1")
            {
                //1--> 活动关联照片
                string actID = context.Request["actId"];
                jsonStr = JsonConvert.SerializeObject(bll.GetModelList("Activity_ID='" + actID + "'"));

            }
            else if (type == "2")
            {
                //获得用户的相册列表
            }
            else if (type == "3")
            {
                //获得相册的照片列表
                string albumId = context.Request["albumId"];
                if (albumId == "all")
                {
                    jsonStr = JsonConvert.SerializeObject(bll.GetModelList("Uploader_ID='" + uid + "'"));
                }
                else
                {
                    jsonStr = JsonConvert.SerializeObject(bll.GetModelList("Uploader_ID='" + uid + "' and Album_ID='" + albumId + "'"));
                }
            }
            else if (type == "4")
            {
                // 4--获得用户上传的所有照片
                jsonStr = JsonConvert.SerializeObject(bll.GetModelList("Uploader_ID='" + uid + "'"));
            }
            context.Response.Write(jsonStr);

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