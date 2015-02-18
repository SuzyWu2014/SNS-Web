
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Suzy.Outside.Model;
namespace Suzy.Outside.BLL
{
	/// <summary>
	/// ActivityBLL
	/// </summary>
	public partial class ActivityBLL
	{
		private readonly Suzy.Outside.DAL.ActivityDAL dal=new Suzy.Outside.DAL.ActivityDAL();
		public ActivityBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string ActivityIdeasID,string Sponsor_ID)
		{
			return dal.Exists(ID,ActivityIdeasID,Sponsor_ID);
		}

		/// <summary>
		/// 增加一条数据----------------------------------------------------------------------------
		/// </summary>
		public bool Add(Suzy.Outside.Model.Activity model,List<Suzy.Outside.Model.ActivityTime> timeList)
		{
            if (dal.Add(model))
            {
                ActivityTimeBLL bll = new ActivityTimeBLL();
                bool suss = true;
                for (int i = 0; i < timeList.Count; i++)
                {
                    if (bll.Add(timeList[i]))
                    {
                        continue;
                    }
                    else
                    {
                        suss = false;

                        break;
                    }
                }
                return suss;
            }
            else
            {
                return false;
            }
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Suzy.Outside.Model.Activity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID,string ActivityIdeasID,string Sponsor_ID)
		{
			
			return dal.Delete(ID,ActivityIdeasID,Sponsor_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Suzy.Outside.Model.Activity GetModel(string ID )
		{ 
			return dal.GetModel(ID );
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Suzy.Outside.Model.Activity GetModelByCache(string ID,string ActivityIdeasID,string Sponsor_ID)
		{
			
			string CacheKey = "ActivityModel-" + ID+ActivityIdeasID+Sponsor_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Suzy.Outside.Model.Activity)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataSet GetUncheckedActivity()
        {
            return dal.GetList("AdminAttitude='未审核' Order by CreateTime");
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Suzy.Outside.Model.Activity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<Suzy.Outside.Model.Activity> GetSearchResult(string keyword)
        {
            DataSet ds = dal.GetSearchResult( keyword);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Suzy.Outside.Model.Activity> GetInterestedModelList(string uid)
        {
            DataSet ds = dal.GetIntertedList(uid);
            return DataTableToList(ds.Tables[0]);
        }
        public List<Suzy.Outside.Model.Activity> GetJoinedModelList(string uid)
        {
            DataSet ds = dal.GetJoinedList(uid);
            return DataTableToList(ds.Tables[0]);
        }
        public List<Suzy.Outside.Model.Activity> GetLaurchedModelList(string uid)
        {
            DataSet ds = dal.GetLaurchedList(uid);
            return DataTableToList(ds.Tables[0]);
        }
        public List<Suzy.Outside.Model.Activity> GetModelList(string aType, int[] dayRange, string peopleRange,int startIndex,int endIndex)
        {
            DataSet ds = dal.GetList(aType,dayRange,peopleRange,startIndex,endIndex);
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Suzy.Outside.Model.Activity> DataTableToList(DataTable dt)
		{
			List<Suzy.Outside.Model.Activity> modelList = new List<Suzy.Outside.Model.Activity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Suzy.Outside.Model.Activity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}

        public int GetUncheckedCount()
        {
            return dal.GetRecordCount("AdminAttitude='未审核'");
        }

        public int GetAllCount()
        {
            return dal.GetRecordCount("");
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetUnchekedListByPage(int PageSize, int PageIndex)
        {
            return dal.GetUnchekedListByPage(PageSize, PageIndex); 
        }

        public DataSet GetListByPage(int PageSize, int PageIndex)
        {
            return dal.GetListByPage(PageSize, PageIndex); 
        }
		#endregion  BasicMethod
		#region  ExtensionMethod
         /// <summary>
        /// 活动参加人数+/-1    
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="type">0:增  1:减</param>
        /// <returns></returns>
        public bool UpdateCountJoin(string activityId, int type)
        {
            return dal.UpdateCountJoin(activityId, type);
        }
        public bool UpdateCountInterest(string actId, int type)
        {
            return dal.UpdateCountInterest(actId, type);
        }

        //活动通过审核
        public bool SetChecked(string Id)
        { 
            return dal.SetChecked(Id);
        }

        //批量审核
        public bool SetActsChecked(string ids)
        {

            return dal.SetActsChecked(ids);
        }
        //活动推荐
        public bool SetRecommended(string Id)
        {
            return dal.SetRecommended(Id);
        }
        //批量活动推荐
        public bool SetActsRecommended(string ids)
        {
            return dal.SetActsRecommended(ids);
        }

        //审核不通过
        public bool SetRefused(string Id)
        {
            return dal.SetRefused(Id);
        }
        //批量拒绝
        public bool SetActsRefused(string ids)
        {
            return dal.SetActsRefused(ids);
        }
		#endregion  ExtensionMethod
	}
}

