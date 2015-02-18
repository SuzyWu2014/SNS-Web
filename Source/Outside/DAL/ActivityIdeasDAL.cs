﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Suzy.Outside.DAL
{
	/// <summary>
	/// 数据访问类:ActivityIdeasDAL
	/// </summary>
	public partial class ActivityIdeasDAL
	{
		public ActivityIdeasDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string Creator_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActivityIdeasSet");
			strSql.Append(" where ID=@ID and Creator_ID=@Creator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Creator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Creator_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.ActivityIdeas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActivityIdeasSet(");
			strSql.Append("ID,Title,Des,ActivityType,IsRealized,Tag,University,Scope,Remark,CountInterested,Creator_ID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Title,@Des,@ActivityType,@IsRealized,@Tag,@University,@Scope,@Remark,@CountInterested,@Creator_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Title", SqlDbType.NVarChar,64),
					new SqlParameter("@Des", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivityType", SqlDbType.NVarChar,32),
					new SqlParameter("@IsRealized", SqlDbType.Bit,1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,64),
					new SqlParameter("@University", SqlDbType.NVarChar,64),
					new SqlParameter("@Scope", SqlDbType.NVarChar,64),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CountInterested", SqlDbType.Int,4),
					new SqlParameter("@Creator_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Des;
			parameters[3].Value = model.ActivityType;
			parameters[4].Value = model.IsRealized;
			parameters[5].Value = model.Tag;
			parameters[6].Value = model.University;
			parameters[7].Value = model.Scope;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.CountInterested;
			parameters[10].Value = model.Creator.ID;

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
		public bool Update(Suzy.Outside.Model.ActivityIdeas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActivityIdeasSet set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Des=@Des,");
			strSql.Append("ActivityType=@ActivityType,");
			strSql.Append("IsRealized=@IsRealized,");
			strSql.Append("Tag=@Tag,");
			strSql.Append("University=@University,");
			strSql.Append("Scope=@Scope,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CountInterested=@CountInterested");
			strSql.Append(" where ID=@ID and Creator_ID=@Creator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,64),
					new SqlParameter("@Des", SqlDbType.NVarChar,-1),
					new SqlParameter("@ActivityType", SqlDbType.NVarChar,32),
					new SqlParameter("@IsRealized", SqlDbType.Bit,1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,64),
					new SqlParameter("@University", SqlDbType.NVarChar,64),
					new SqlParameter("@Scope", SqlDbType.NVarChar,64),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CountInterested", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Creator_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Des;
			parameters[2].Value = model.ActivityType;
			parameters[3].Value = model.IsRealized;
			parameters[4].Value = model.Tag;
			parameters[5].Value = model.University;
			parameters[6].Value = model.Scope;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.CountInterested;
			parameters[9].Value = model.ID;
			parameters[10].Value = model.Creator.ID;

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
		public bool Delete(string ID,string Creator_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityIdeasSet ");
			strSql.Append(" where ID=@ID and Creator_ID=@Creator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Creator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Creator_ID;

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
		/// 得到一个对象实体
		/// </summary>
		public Suzy.Outside.Model.ActivityIdeas GetModel(string ID )
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Title,Des,ActivityType,IsRealized,Tag,University,Scope,Remark,CountInterested,Creator_ID from ActivityIdeasSet ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16) 
					 	};
			parameters[0].Value = ID;
			 
			Suzy.Outside.Model.ActivityIdeas model=new Suzy.Outside.Model.ActivityIdeas();
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
		public Suzy.Outside.Model.ActivityIdeas DataRowToModel(DataRow row)
		{
			Suzy.Outside.Model.ActivityIdeas model=new Suzy.Outside.Model.ActivityIdeas();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Des"]!=null)
				{
					model.Des=row["Des"].ToString();
				}
				if(row["ActivityType"]!=null)
				{
					model.ActivityType=row["ActivityType"].ToString();
				}
				if(row["IsRealized"]!=null && row["IsRealized"].ToString()!="")
				{
					if((row["IsRealized"].ToString()=="1")||(row["IsRealized"].ToString().ToLower()=="true"))
					{
						model.IsRealized=true;
					}
					else
					{
						model.IsRealized=false;
					}
				}
				if(row["Tag"]!=null)
				{
					model.Tag=row["Tag"].ToString();
				}
				if(row["University"]!=null)
				{
					model.University=row["University"].ToString();
				}
				if(row["Scope"]!=null)
				{
					model.Scope=row["Scope"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CountInterested"]!=null && row["CountInterested"].ToString()!="")
				{
					model.CountInterested=int.Parse(row["CountInterested"].ToString());
				}
				if(row["Creator_ID"]!=null)
				{
                    CustomerDAL dal = new CustomerDAL();
					model.Creator =dal.GetModel(row["Creator_ID"].ToString(),0);
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
			strSql.Append("select ID,Title,Des,ActivityType,IsRealized,Tag,University,Scope,Remark,CountInterested,Creator_ID ");
			strSql.Append(" FROM ActivityIdeasSet ");
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
			strSql.Append(" ID,Title,Des,ActivityType,IsRealized,Tag,University,Scope,Remark,CountInterested,Creator_ID ");
			strSql.Append(" FROM ActivityIdeasSet ");
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
			strSql.Append("select count(1) FROM ActivityIdeasSet ");
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
				strSql.Append("order by T.Creator_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ActivityIdeasSet T ");
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
			parameters[0].Value = "ActivityIdeasSet";
			parameters[1].Value = "Creator_ID";
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

