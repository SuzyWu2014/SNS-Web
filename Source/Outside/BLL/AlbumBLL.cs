﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Suzy.Outside.Model;
namespace Suzy.Outside.BLL
{
	/// <summary>
	/// AlbumBLL
	/// </summary>
	public partial class AlbumBLL
	{
		private readonly Suzy.Outside.DAL.AlbumDAL dal=new Suzy.Outside.DAL.AlbumDAL();
		public AlbumBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}
        public bool Exists(Model.Album model)
        {
            return dal.Exists(model);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.Album model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Suzy.Outside.Model.Album model)
		{
			return dal.Update(model);
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
		/// 得到一个对象实体
		/// </summary>
		public Suzy.Outside.Model.Album GetModel(string ID)
		{ 
			return dal.GetModel(ID);
		}
        public Suzy.Outside.Model.Album GetModel(string Customer_ID, int type)
        {
            return dal.GetModel(Customer_ID, 0);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Suzy.Outside.Model.Album GetModelByCache(string ID)
		{
			
			string CacheKey = "AlbumModel-" + ID;
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
			return (Suzy.Outside.Model.Album)objModel;
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
		public List<Suzy.Outside.Model.Album> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Suzy.Outside.Model.Album> DataTableToList(DataTable dt)
		{
			List<Suzy.Outside.Model.Album> modelList = new List<Suzy.Outside.Model.Album>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Suzy.Outside.Model.Album model;
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

