using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Suzy.Outside.Model;
namespace Suzy.Outside.BLL
{
	/// <summary>
	/// CustomerBLL
	/// </summary>
	public partial class CustomerBLL
	{
		private readonly Suzy.Outside.DAL.CustomerDAL dal=new Suzy.Outside.DAL.CustomerDAL();
		public CustomerBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录--------------------------------------------------------------------------
		/// </summary>
        public bool Exists(string userName)
		{
            return dal.Exists(userName);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.Customer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Suzy.Outside.Model.Customer model)
		{
			return dal.Update(model);
		}
        public bool UpdatePortrait(string ID, string url)
        {
            return dal.UpdatePortrait(ID, url);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体----------------------------------------------------------------------
		/// </summary>
        public Suzy.Outside.Model.Customer GetModel(string userName)
		{

            return dal.GetModel(userName);
		}
        public Suzy.Outside.Model.Customer GetModel(string ID, int type)
        {
            return dal.GetModel(ID, type);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Suzy.Outside.Model.Customer GetModelByCache(string userName)
		{

            string CacheKey = "CustomerModel-" + userName;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(userName);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Suzy.Outside.Model.Customer)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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
		public List<Suzy.Outside.Model.Customer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public List<Suzy.Outside.Model.Customer> GetSearchResult(string keyword)
        {
            DataSet ds = dal.GetSearchResult(keyword);
            return DataTableToList(ds.Tables[0]);
        }
        public List<Suzy.Outside.Model.Customer> GetFansModelList(string IdolId)
        {
            DataSet ds = dal.GetFansList(IdolId);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Suzy.Outside.Model.Customer> GetIdolsModelList(string FansId)
        {
            DataSet ds = dal.GetIdolsList(FansId);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Suzy.Outside.Model.Customer>  GetJoinedList(string actId)
        {
            DataSet ds = dal.GetJoinedList(actId);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Suzy.Outside.Model.Customer> GetInterestedList(string actId)
        {
            DataSet ds = dal.GetInterestedList(actId);
            return DataTableToList(ds.Tables[0]);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Suzy.Outside.Model.Customer> DataTableToList(DataTable dt)
		{
			List<Suzy.Outside.Model.Customer> modelList = new List<Suzy.Outside.Model.Customer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Suzy.Outside.Model.Customer model;
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

