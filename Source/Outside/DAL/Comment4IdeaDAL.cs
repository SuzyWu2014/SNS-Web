﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Suzy.Outside.DAL
{
	/// <summary>
	/// 数据访问类:Comment4IdeaDAL
	/// </summary>
	public partial class Comment4IdeaDAL
	{
		public Comment4IdeaDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string ActivityIdeas_ID,string Comentator_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Comment4IdeaSet");
			strSql.Append(" where ID=@ID and ActivityIdeas_ID=@ActivityIdeas_ID and Comentator_ID=@Comentator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeas_ID", SqlDbType.Char,16),
					new SqlParameter("@Comentator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = ActivityIdeas_ID;
			parameters[2].Value = Comentator_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.Comment4Idea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Comment4IdeaSet(");
			strSql.Append("ID,Content,CreateTime,ActivityIdeas_ID,Comentator_ID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Content,@CreateTime,@ActivityIdeas_ID,@Comentator_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Content", SqlDbType.NVarChar,512),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ActivityIdeas_ID", SqlDbType.Char,16),
					new SqlParameter("@Comentator_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.ActivityIdeas.ID;
			parameters[4].Value = model.Commentator.ID;

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
		public bool Update(Suzy.Outside.Model.Comment4Idea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Comment4IdeaSet set ");
			strSql.Append("Content=@Content,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where ID=@ID and ActivityIdeas_ID=@ActivityIdeas_ID and Comentator_ID=@Comentator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Content", SqlDbType.NVarChar,512),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeas_ID", SqlDbType.Char,16),
					new SqlParameter("@Comentator_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.Content;
			parameters[1].Value = model.CreateTime;
			parameters[2].Value = model.ID;
			parameters[3].Value = model.ActivityIdeas.ID;
			parameters[4].Value = model.Commentator.ID;

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
		public bool Delete(string ID,string ActivityIdeas_ID,string Comentator_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Comment4IdeaSet ");
			strSql.Append(" where ID=@ID and ActivityIdeas_ID=@ActivityIdeas_ID and Comentator_ID=@Comentator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeas_ID", SqlDbType.Char,16),
					new SqlParameter("@Comentator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = ActivityIdeas_ID;
			parameters[2].Value = Comentator_ID;

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
		public Suzy.Outside.Model.Comment4Idea GetModel(string ID,string ActivityIdeas_ID,string Comentator_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Content,CreateTime,ActivityIdeas_ID,Comentator_ID from Comment4IdeaSet ");
			strSql.Append(" where ID=@ID and ActivityIdeas_ID=@ActivityIdeas_ID and Comentator_ID=@Comentator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeas_ID", SqlDbType.Char,16),
					new SqlParameter("@Comentator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = ActivityIdeas_ID;
			parameters[2].Value = Comentator_ID;

			Suzy.Outside.Model.Comment4Idea model=new Suzy.Outside.Model.Comment4Idea();
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
		public Suzy.Outside.Model.Comment4Idea DataRowToModel(DataRow row)
		{
			Suzy.Outside.Model.Comment4Idea model=new Suzy.Outside.Model.Comment4Idea();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["ActivityIdeas_ID"]!=null)
				{
                    model.ActivityIdeas = new Model.ActivityIdeas() { 
                        ID=row["ActivityIdeas_ID"].ToString()
                     }; 
				}
				if(row["Comentator_ID"]!=null)
				{
                    CustomerDAL dal = new CustomerDAL();
					model.Commentator =dal.GetModel(row["Comentator_ID"].ToString(),0);
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
			strSql.Append("select ID,Content,CreateTime,ActivityIdeas_ID,Comentator_ID ");
			strSql.Append(" FROM Comment4IdeaSet ");
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
			strSql.Append(" ID,Content,CreateTime,ActivityIdeas_ID,Comentator_ID ");
			strSql.Append(" FROM Comment4IdeaSet ");
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
			strSql.Append("select count(1) FROM Comment4IdeaSet ");
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
				strSql.Append("order by T.Comentator_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Comment4IdeaSet T ");
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
			parameters[0].Value = "Comment4IdeaSet";
			parameters[1].Value = "Comentator_ID";
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

