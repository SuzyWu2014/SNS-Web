using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.Outside.BLL;
using Suzy.Outside.Model;
using Newtonsoft.Json;

namespace Suzy.Outside.Web.Handlers
{
    /// <summary>
    /// GetActivityType 的摘要说明
    /// </summary>
    public class GetActivityType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
          
            ActivityTypeBLL bll = new ActivityTypeBLL();
            List<ActivityType> modelList = new List<ActivityType>();
            modelList = bll.GetModelList("");//获得所有的类别实体

            List<ActTypes> list = new List<ActTypes>();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for (int i = 0; i < modelList.Count; i++)
            {
                if (dic.Keys.Contains(modelList[i].ParentType))
                {
                    dic[modelList[i].ParentType].Add(modelList[i].SubType);
                }
                else
                {
                    dic.Add(modelList[i].ParentType, new List<string>() { modelList[i].SubType });
                }
            }

            for (int i = 0; i < dic.Count; i++)
            {
                ActTypes t = new ActTypes()
                {
                    MainType = dic.Keys.ToArray()[i],
                    SubType = dic[dic.Keys.ToArray()[i]].ToList()
                };
                 
                list.Add(t); 
            }
              string jsonStr= JsonConvert.SerializeObject(list);
            //  string jsonStr = JsonConvert.SerializeObject(dic);
              context.Response.Write(jsonStr);
        }

        [Serializable]
        public class ActTypes
        {
            public string MainType { get; set; }
            public List<string> SubType { get; set; }
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