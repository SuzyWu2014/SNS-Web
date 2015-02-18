using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using Maticsoft.Common;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile File = context.Request.Files["Filedata"];//接收SWFupload传递过来的文件数据.//Filedata:通过代码示例可以查看。
            string id = context.Request["actId"];
           string FileName= Path.GetFileName(File.FileName);//获取文件名.
           string FileExt = Path.GetExtension(FileName).ToLower();//获取文件的扩展名。
           if (FileExt == ".jpg" || FileExt == ".jpeg" || FileExt == ".png" || FileExt == ".gif")
           { 
               //1:怎样解决上传的文件放在不同文件夹中
               string dir = "/Resource/Images/Upload/"+ id + "/";
               //2:对文件进行重命名.
              //  string fullDir = dir + Assistant.GetStreamMD5(File.InputStream) + FileExt;//构建好了一个完整的文件保存的最终路径.
               string fullDir = dir + id + FileExt;
               Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(dir)));//创建文件夹.

               File.SaveAs(context.Server.MapPath(fullDir));//将图片进行保存.
               context.Response.Write("ok:"+fullDir);

           }
           else
           {
               throw new Exception("上传的文件类型错误!");
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
