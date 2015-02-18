using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Suzy.Outside.DAL
{
	/// <summary>
	/// 数据访问类:InvitationCodeDAL
	/// </summary>
	public partial class InvitationCodeDAL
	{
		public InvitationCodeDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string CustomerCreator_ID,string AdminCreator_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from InvitationCodeSet");
			strSql.Append(" where ID=@ID and CustomerCreator_ID=@CustomerCreator_ID and AdminCreator_ID=@AdminCreator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@CustomerCreator_ID", SqlDbType.Char,16),
					new SqlParameter("@AdminCreator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = CustomerCreator_ID;
			parameters[2].Value = AdminCreator_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.InvitationCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InvitationCodeSet(");
			strSql.Append("ID,Code,IsUsed,CreateUserType,CustomerCreator_ID,AdminCreator_ID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Code,@IsUsed,@CreateUserType,@CustomerCreator_ID,@AdminCreator_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Code", SqlDbType.NVarChar,64),
					new SqlParameter("@IsUsed", SqlDbType.Bit,1),
					new SqlParameter("@CreateUserType", SqlDbType.NVarChar,16),
					new SqlParameter("@CustomerCreator_ID", SqlDbType.Char,16),
					new SqlParameter("@AdminCreator_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.IsUsed;
			parameters[3].Value = model.CreateUserType;
			parameters[4].Value = model.CustomerCreator.ID;
			parameters[5].Value = model.AdminCreator.ID;

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
		public bool Update(Suzy.Outside.Model.InvitationCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InvitationCodeSet set ");
			strSql.Append("Code=@Code,");
			strSql.Append("IsUsed=@IsUsed,");
			strSql.Append("CreateUserType=@CreateUserType");
			strSql.Append(" where ID=@ID and CustomerCreator_ID=@CustomerCreator_ID and AdminCreator_ID=@AdminCreator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,64),
					new SqlParameter("@IsUsed", SqlDbType.Bit,1),
					new SqlParameter("@CreateUserType", SqlDbType.NVarChar,16),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@CustomerCreator_ID", SqlDbType.Char,16),
					new SqlParameter("@AdminCreator_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.IsUsed;
			parameters[2].Value = model.CreateUserType;
			parameters[3].Value = model.ID;
			parameters[4].Value = model.CustomerCreator.ID;
			parameters[5].Value = model.AdminCreator.ID;

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
		public bool Delete(string ID,string CustomerCreator_ID,string AdminCreator_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InvitationCodeSet ");
			strSql.Append(" where ID=@ID and CustomerCreator_ID=@CustomerCreator_ID and AdminCreator_ID=@AdminCreator_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@CustomerCreator_ID", SqlDbType.Char,16),
					new SqlParameter("@AdminCreator_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = CustomerCreator_ID;
			parameters[2].Value = AdminCreator_ID;

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
		/// 得到一个对象实体------------------------------------------------------------------------------
		/// </summary>
		public Suzy.Outside.Model.InvitationCode GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Code,IsUsed,CreateUserType,CustomerCreator_ID,AdminCreator_ID from InvitationCodeSet ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					 };
			parameters[0].Value = ID; 
			Suzy.Outside.Model.InvitationCode model=new Suzy.Outside.Model.InvitationCode();
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
		public Suzy.Outside.Model.InvitationCode DataRowToModel(DataRow row)
		{
			Suzy.Outside.Model.InvitationCode model=new Suzy.Outside.Model.InvitationCode();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["IsUsed"]!=null && row["IsUsed"].ToString()!="")
				{
					if((row["IsUsed"].ToString()=="1")||(row["IsUsed"].ToString().ToLower()=="true"))
					{
						model.IsUsed=true;
					}
					else
					{
						model.IsUsed=false;
					}
				}
				if(row["CreateUserType"]!=null)
				{
					model.CreateUserType=row["CreateUserType"].ToString();
				}
				if(row["CustomerCreator_ID"]!=null)
				{
					model.CustomerCreator.ID=row["CustomerCreator_ID"].ToString();
				}
				if(row["AdminCreator_ID"]!=null)
				{
					model.AdminCreator.ID=row["AdminCreator_ID"].ToString();
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
			strSql.Append("select ID,Code,IsUsed,CreateUserType,CustomerCreator_ID,AdminCreator_ID ");
			strSql.Append(" FROM InvitationCodeSet ");
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
			strSql.Append(" ID,Code,IsUsed,CreateUserType,CustomerCreator_ID,AdminCreator_ID ");
			strSql.Append(" FROM InvitationCodeSet ");
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
			strSql.Append("select count(1) FROM InvitationCodeSet ");
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
				strSql.Append("order by T.AdminCreator_ID desc");
			}
			strSql.Append(")AS Row, T.*  from InvitationCodeSet T ");
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
			parameters[0].Value = "InvitationCodeSet";
			parameters[1].Value = "AdminCreator_ID";
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

