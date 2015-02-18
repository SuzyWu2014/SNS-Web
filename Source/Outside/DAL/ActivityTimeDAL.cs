/**  版本信息模板在安装目录下，可自行修改。
* ActivityTimeDAL.cs
*
* 功 能： N/A
* 类 名： ActivityTimeDAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/17 9:55:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Suzy.Outside.DAL
{
	/// <summary>
	/// 数据访问类:ActivityTimeDAL
	/// </summary>
	public partial class ActivityTimeDAL
	{
		public ActivityTimeDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActivityTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.ActivityTime model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActivityTime(");
			strSql.Append("ID,StartTime,EndTime,Week,Day,Activity_ID,IsEnd)");
			strSql.Append(" values (");
			strSql.Append("@ID,@StartTime,@EndTime,@Week,@Day,@Activity_ID,@IsEnd)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Week", SqlDbType.Char,16),
					new SqlParameter("@Day", SqlDbType.Int,4),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@IsEnd", SqlDbType.Bit,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.StartTime;
			parameters[2].Value = model.EndTime;
			parameters[3].Value = model.Week;
			parameters[4].Value = model.Day;
			parameters[5].Value = model.Activity.ID;
			parameters[6].Value = model.IsEnd;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Suzy.Outside.Model.ActivityTime model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActivityTime set ");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("Week=@Week,");
			strSql.Append("Day=@Day,");
			strSql.Append("Activity_ID=@Activity_ID,");
			strSql.Append("IsEnd=@IsEnd");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Week", SqlDbType.Char,16),
					new SqlParameter("@Day", SqlDbType.Int,4),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@IsEnd", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Char,16)};
			parameters[0].Value = model.StartTime;
			parameters[1].Value = model.EndTime;
			parameters[2].Value = model.Week;
			parameters[3].Value = model.Day;
			parameters[4].Value = model.Activity.ID;
			parameters[5].Value = model.IsEnd;
			parameters[6].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityTime ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityTime ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Suzy.Outside.Model.ActivityTime GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,StartTime,EndTime,Week,Day,Activity_ID,IsEnd from ActivityTime ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;

			Suzy.Outside.Model.ActivityTime model=new Suzy.Outside.Model.ActivityTime();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Suzy.Outside.Model.ActivityTime DataRowToModel(DataRow row)
		{
			Suzy.Outside.Model.ActivityTime model=new Suzy.Outside.Model.ActivityTime();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["StartTime"]!=null && row["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(row["StartTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["Week"]!=null)
				{
					model.Week=row["Week"].ToString();
				}
				if(row["Day"]!=null && row["Day"].ToString()!="")
				{
					model.Day=int.Parse(row["Day"].ToString());
				}
				if(row["Activity_ID"]!=null)
				{
					model.Activity.ID=row["Activity_ID"].ToString();
				}
				if(row["IsEnd"]!=null && row["IsEnd"].ToString()!="")
				{
					if((row["IsEnd"].ToString()=="1")||(row["IsEnd"].ToString().ToLower()=="true"))
					{
						model.IsEnd=true;
					}
					else
					{
						model.IsEnd=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,StartTime,EndTime,Week,Day,Activity_ID,IsEnd ");
			strSql.Append(" FROM ActivityTime ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,StartTime,EndTime,Week,Day,Activity_ID,IsEnd ");
			strSql.Append(" FROM ActivityTime ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ActivityTime ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from ActivityTime T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ActivityTime";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

