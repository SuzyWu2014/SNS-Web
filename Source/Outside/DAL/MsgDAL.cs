using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Suzy.Outside.DAL
{
	/// <summary>
	/// 数据访问类:MsgDAL
	/// </summary>
	public partial class MsgDAL
	{
		public MsgDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string Customer_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MsgSet");
			strSql.Append(" where ID=@ID and Customer_ID=@Customer_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Customer_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Customer_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.Msg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MsgSet(");
			strSql.Append("ID,Content,IsRead,RelatedPath,MsgType,Customer_ID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Content,@IsRead,@RelatedPath,@MsgType,@Customer_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsRead", SqlDbType.Bit,1),
					new SqlParameter("@RelatedPath", SqlDbType.NVarChar,128),
					new SqlParameter("@MsgType", SqlDbType.NVarChar,32),
					new SqlParameter("@Customer_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.IsRead;
			parameters[3].Value = model.RelatedPath;
			parameters[4].Value = model.MsgType;
			parameters[5].Value = model.Customer.ID;

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
		public bool Update(Suzy.Outside.Model.Msg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MsgSet set ");
			strSql.Append("Content=@Content,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("RelatedPath=@RelatedPath,");
			strSql.Append("MsgType=@MsgType");
			strSql.Append(" where ID=@ID and Customer_ID=@Customer_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsRead", SqlDbType.Bit,1),
					new SqlParameter("@RelatedPath", SqlDbType.NVarChar,128),
					new SqlParameter("@MsgType", SqlDbType.NVarChar,32),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Customer_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.Content;
			parameters[1].Value = model.IsRead;
			parameters[2].Value = model.RelatedPath;
			parameters[3].Value = model.MsgType;
			parameters[4].Value = model.ID;
			parameters[5].Value = model.Customer.ID;

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
		public bool Delete(string ID,string Customer_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MsgSet ");
			strSql.Append(" where ID=@ID and Customer_ID=@Customer_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Customer_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Customer_ID;

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
		public Suzy.Outside.Model.Msg GetModel(string ID,string Customer_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Content,IsRead,RelatedPath,MsgType,Customer_ID from MsgSet ");
			strSql.Append(" where ID=@ID and Customer_ID=@Customer_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Customer_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Customer_ID;

			Suzy.Outside.Model.Msg model=new Suzy.Outside.Model.Msg();
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
		public Suzy.Outside.Model.Msg DataRowToModel(DataRow row)
		{
			Suzy.Outside.Model.Msg model=new Suzy.Outside.Model.Msg();
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
				if(row["IsRead"]!=null && row["IsRead"].ToString()!="")
				{
					if((row["IsRead"].ToString()=="1")||(row["IsRead"].ToString().ToLower()=="true"))
					{
						model.IsRead=true;
					}
					else
					{
						model.IsRead=false;
					}
				}
				if(row["RelatedPath"]!=null)
				{
					model.RelatedPath=row["RelatedPath"].ToString();
				}
				if(row["MsgType"]!=null)
				{
					model.MsgType=row["MsgType"].ToString();
				}
				if(row["Customer_ID"]!=null)
				{
					model.Customer.ID=row["Customer_ID"].ToString();
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
			strSql.Append("select ID,Content,IsRead,RelatedPath,MsgType,Customer_ID ");
			strSql.Append(" FROM MsgSet ");
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
			strSql.Append(" ID,Content,IsRead,RelatedPath,MsgType,Customer_ID ");
			strSql.Append(" FROM MsgSet ");
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
			strSql.Append("select count(1) FROM MsgSet ");
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
				strSql.Append("order by T.Customer_ID desc");
			}
			strSql.Append(")AS Row, T.*  from MsgSet T ");
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
			parameters[0].Value = "MsgSet";
			parameters[1].Value = "Customer_ID";
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

