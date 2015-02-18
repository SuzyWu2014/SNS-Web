using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// PortraitHandler 的摘要说明
    /// </summary>
    public class PortraitHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            string uid = context.User.Identity.Name;

            if (action == "up")
            {
                HttpPostedFile File = context.Request.Files["Filedata"];//接收SWFupload传递过来的文件数据.//Filedata:通过代码示例可以查看。 
                string FileName = Path.GetFileName(File.FileName);//获取文件名.
                string FileExt = Path.GetExtension(FileName).ToLower();//获取文件的扩展名。
                if (FileExt == ".jpg" || FileExt == ".jpeg" || FileExt == ".png" || FileExt == ".gif")
                {
                    string fullDir = "/Resource/Images/Upload/portrait/big/" + uid + FileExt;
                    File.SaveAs(context.Server.MapPath(fullDir));
                    using (Image img = Image.FromStream(File.InputStream))//根据上传的文件流，来创建Image的实例（这就是一张图片）
                    {
                        //保证原始图片的高宽比例

                        int smallWidth = 300;
                        int smallHeight = 300;

                        if (img.Width > img.Height)
                        {
                            smallHeight = smallWidth * img.Height / img.Width;
                        }
                        else
                        {
                            smallWidth = smallHeight * img.Width / img.Height;
                        }
                        //缩略图
                        using (Bitmap bitmap = new Bitmap(smallWidth, smallHeight))
                        {
                            //
                            using (Graphics g = Graphics.FromImage(bitmap))
                            {
                                g.DrawImage(img, 0, 0, bitmap.Width, bitmap.Height);
                                bitmap.Save(context.Server.MapPath(fullDir));
                                //输出
                                context.Response.Write("ok:" + fullDir + ":" + smallWidth + ":" + smallHeight);
                            }
                        }


                    }
                }



            }
            else if (action == "cut")//头像截取
            {
                string top = context.Request.Form["top"];//纵坐标
                string left = context.Request.Form["left"];//横坐标
                string width = context.Request.Form["width"];//宽度
                string height = context.Request.Form["height"];//高度
                string imgUrl = context.Request.Form["url"];//接收传递过来的图片路径
                using (Bitmap map = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height)))//创建画布。画布的大小就是我截取的图片的大小
                {
                    using (Graphics g = Graphics.FromImage(map))//创建画笔
                    {
                        using (Image img = Image.FromFile(context.Server.MapPath(imgUrl)))//获取上传的图片
                        {
                            //根据传递过来的参数，用户画笔，将图片画到画布上

                            //第一个参数:表示画哪张图片
                            //第二：画的图片的大小。
                            //三：画原图的哪一部分.
                            g.DrawImage(img, new Rectangle(0, 0, Convert.ToInt32(width), Convert.ToInt32(height)), new Rectangle(Convert.ToInt32(left), Convert.ToInt32(top), Convert.ToInt32(width), Convert.ToInt32(height)), GraphicsUnit.Pixel);

                            // string newFile = Guid.NewGuid().ToString().Substring(0, 8);
                            string fName = "/Resource/Images/Upload/portrait/" + uid + ".jpg";
                            map.Save(context.Server.MapPath(fName));
                            CustomerBLL bll = new CustomerBLL();
                            if (bll.UpdatePortrait(uid, fName))
                            {
                                context.Response.Write(fName);
                            }
                            else
                            {
                                context.Response.Write(-1);
                            }

                        }
                    }
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