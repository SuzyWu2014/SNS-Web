using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.Outside.Model;
using Maticsoft.Common;
using Suzy.Outside.BLL;

namespace Suzy.Outside.Web.Activity
{
    public partial class AddActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //获得活动信息
                string aType = Request.Form[activityType.UniqueID] + ( Request.Form[subType.UniqueID] == "none" ? "" :"-"+ Request.Form[subType.UniqueID]);
                string aTitle = txtTitle.Value;
                string aCycle = Request.Form[Cycle.UniqueID];
                string university = Request.Form[utc.UniqueID];
                string tDes = string.Empty;
                string placeType = Request.Form[pType.UniqueID];
                string aPlace = place.Value;
                string aDetail = txtDetail.Value;
                float cost = rdFee.Checked ? float.Parse(txtFee.Value) : 0;
                bool isNeedContact = rd.Checked;

                List<ActivityTime> timeList = new List<ActivityTime>();
                Model.Activity model = new Model.Activity()
                {
                    ActivityType = aType,
                    Detail = aDetail,
                    fee = (decimal)cost,
                    ID = actID.Value,
                    Place = aPlace,
                    PlaceType = placeType,
                    Sponsor = new Customer()
                    {
                        ID = Page.User.Identity.Name
                    },
                    Topic = aTitle,
                    PosterPath = Request.Form["img"],
                    Tag = txtTag.Value,
                    TimeCycle = aCycle,
                    University = university,
                    IsNeedContact=isNeedContact

                };

                DateTime Bt, Et;
                switch (aCycle)
                {
                    case "当天结束":

                        Bt = DateTime.Parse(date.Value + " " + timeBegin.Value);
                        Et = DateTime.Parse(date.Value + " " + timeEnd.Value);
                        if (DateTime.Compare(Bt, Et) < 0)
                        {
                            tDes = date.Value + "  " + timeBegin.Value + "  至  " + timeEnd.Value;
                            model.TimeDes = tDes;
                            timeList.Add(new ActivityTime()
                            {
                                ID = Assistant.GetID(),
                                Activity = model,
                                StartTime = Bt,
                                EndTime = Et,
                                Day = Et.Day,
                                Week = Et.DayOfWeek.ToString()
                            });
                        }
                        else
                        {
                            
                        }
                        break;
                    case "连续多天":
                        int days= DateTime.Parse(date02.Value).DayOfYear - DateTime.Parse(date01.Value).DayOfYear;
                        tDes = date01.Value + " 至 " + date02.Value + " 每天 " + time01.Value + " 至 " + time02.Value;
                        model.TimeDes = tDes;
                        for (int i = 0; i <= days; i++)
                        {
                            Bt = DateTime.Parse(date01.Value + " " + time01.Value).AddDays(i);
                            Et = DateTime.Parse(date01.Value + " " + time02.Value).AddDays(i);
                            timeList.Add(new ActivityTime()
                            {
                                ID = Assistant.GetID(),
                                Activity = model,
                                StartTime = Bt,
                                EndTime = Et,
                                Day = Et.Day,
                                Week = Et.DayOfWeek.ToString()
                            });
                        } 
                        break;
                    case "每周举行":
                        string[] ws = Request.Form["wk"].Split(',');
                        List<DayOfWeek> wl = new List<DayOfWeek>();
                        for (int i = 0; i < ws.Length ; i++)
                        {
                            switch (ws[i])
                            {
                                case "一": wl.Add(DayOfWeek .Monday); break;
                                case "二": wl.Add(DayOfWeek.Tuesday); break;
                                case "三": wl.Add(DayOfWeek.Wednesday); break;
                                case "四": wl.Add(DayOfWeek.Thursday); break;
                                case "五": wl.Add(DayOfWeek.Friday); break;
                                case "六": wl.Add(DayOfWeek.Saturday); break;
                                case "日": wl.Add(DayOfWeek.Sunday); break;
                                default:
                                    break;
                            }
                        }
                          int count= DateTime.Parse(date12.Value).DayOfYear - DateTime.Parse(date11.Value).DayOfYear;
                          tDes = date11.Value + " 至 " + date12.Value + " 每周 " + Request.Form["wk"] + " " + time11.Value + " 至 " + time12.Value;
                        model.TimeDes = tDes;
                        for (int i = 0; i <= count; i++)
                        {
                            Bt = DateTime.Parse(date11.Value + " " + time11.Value).AddDays(i);
                            Et = DateTime.Parse(date11.Value + " " + time12.Value).AddDays(i);
                            if (wl.Contains(Bt.DayOfWeek))
                            {
                                timeList.Add(new ActivityTime()
                                {
                                    ID=Assistant.GetID(),
                                    Activity = model,
                                    StartTime = Bt,
                                    EndTime = Et,
                                    Day = Et.Day,
                                    Week = Et.DayOfWeek.ToString()
                                });
                            }
                        } 
                        break;
                    default:
                        break;
                }
                ActivityBLL bll = new ActivityBLL();
                if (bll.Add(model, timeList))
                {
                    //添加成功，跳转至个人主页
                    Response.Redirect("/Home.aspx");
                } 

            }
            else
            {
                //验证是否登录
                if (Page.User.Identity.IsAuthenticated)
                {
                   // actID.Value = Assistant.GetID();
                }


            }
        }
    }
}