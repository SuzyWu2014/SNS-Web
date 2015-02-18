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
    /// GetUniversity 的摘要说明
    /// </summary>
    public class GetUniversity : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            UniversityLocationBLL bll = new UniversityLocationBLL();
            List<UniversityLocation> modelList = new List<UniversityLocation>();
            modelList = bll.GetModelList("");//获得所有的类别实体

         
            Dictionary<string, Dictionary<string, List<string>>> dic = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < modelList.Count; i++)
            {
                if (dic.Keys.Contains(modelList[i].Province))
                {
                    string pro=modelList[i].Province;
                    if (dic[pro].Keys.Contains(modelList[i].City))
                    {
                        string ct = modelList[i].City;
                        dic[pro][ct].Add(modelList[i].University); 
                    }
                    else
                    {
                        List<string> l = new List<string>();
                        l.Add(modelList[i].University);
                        dic[pro].Add(modelList[i].City,l);
                    }
                }
                else
                {
                    Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
                    List<string> l = new List<string>();
                    l.Add(modelList[i].University);
                    d.Add(modelList[i].City,l);
                    dic.Add(modelList[i].Province, d); 
                }
            }
            List<PCmap> list = new List<PCmap>();
            foreach (KeyValuePair<string,Dictionary<string,List<string>>> kv in dic)
            {
                PCmap pMap = new PCmap();
                pMap.Province = kv.Key;
                pMap.Cu = new List<CUmap>();
                foreach (KeyValuePair<string,List<string>> dcu in kv.Value)
                {
                    CUmap cMap = new CUmap();
                    cMap.City = dcu.Key;
                    cMap.Unt = dcu.Value;
                    pMap.Cu.Add(cMap);
                }
                list.Add(pMap);
            }

            string jsonStr = JsonConvert.SerializeObject(list);
            context.Response.Write(jsonStr);
        }
        [Serializable]
        public class PCmap
        {
           public   string Province { get; set; }
           public   List<CUmap> Cu { get; set; }
        }
        [Serializable]
        public class CUmap
        {
            public string City { get; set; }
            public List<string> Unt { get; set; }
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