﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Suzy.Outside.Model;
namespace Suzy.Outside.BLL
{
	/// <summary>
	/// MsgBLL
	/// </summary>
	public partial class MsgBLL
	{
		private readonly Suzy.Outside.DAL.MsgDAL dal=new Suzy.Outside.DAL.MsgDAL();
		public MsgBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string Customer_ID)
		{
			return dal.Exists(ID,Customer_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.Msg model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Suzy.Outside.Model.Msg model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID,string Customer_ID)
		{
			
			return dal.Delete(ID,Customer_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Suzy.Outside.Model.Msg GetModel(string ID,string Customer_ID)
		{
			
			return dal.GetModel(ID,Customer_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Suzy.Outside.Model.Msg GetModelByCache(string ID,string Customer_ID)
		{
			
			string CacheKey = "MsgModel-" + ID+Customer_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID,Customer_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Suzy.Outside.Model.Msg)objModel;
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
		public List<Suzy.Outside.Model.Msg> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Suzy.Outside.Model.Msg> DataTableToList(DataTable dt)
		{
			List<Suzy.Outside.Model.Msg> modelList = new List<Suzy.Outside.Model.Msg>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Suzy.Outside.Model.Msg model;
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

