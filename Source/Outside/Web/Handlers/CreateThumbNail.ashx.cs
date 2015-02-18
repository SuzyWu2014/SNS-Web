using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// CreateThumbNail 的摘要说明
    /// </summary>
    public class CreateThumbNail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            //获取url上的路径
            string path = context.Request.QueryString["url"];
            string wth = context.Request.QueryString["wdh"];
            string hgt = context.Request["hgt"];
            path = context.Request.MapPath(path);
            //原始图片
            using (Image img = Image.FromFile(path))
            {
                int smallWidth;
                int smallHeight;
                if (string.IsNullOrEmpty(wth))
                {
                    //未传递宽度值，则高度固定
                    smallHeight = Convert.ToInt32(hgt);
                    smallWidth = smallHeight * img.Width / img.Height;  //保证原始图片的高宽比例
                }
                else
                {
                    //宽度固定
                    smallWidth = Convert.ToInt32(wth);
                    smallHeight = smallWidth * img.Height / img.Width;  //保证原始图片的高宽比例
                }


                //缩略图
                using (Bitmap bitmap = new Bitmap(smallWidth, smallHeight))
                {
                    //
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawImage(img, 0, 0, bitmap.Width, bitmap.Height);
                        //输出
                        bitmap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
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