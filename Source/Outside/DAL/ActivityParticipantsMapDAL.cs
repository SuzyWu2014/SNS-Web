
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Suzy.Outside.DAL
{
	/// <summary>
	/// 数据访问类:ActivityParticipantsMapDAL
	/// </summary>
	public partial class ActivityParticipantsMapDAL
	{
		public ActivityParticipantsMapDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string Activity_ID,string Participants_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActivityParticipantsMapSet");
			strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Participants_ID=@Participants_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Activity_ID;
			parameters[2].Value = Participants_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool Exists(Model.ActivityParticipantsMap model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ActivityParticipantsMapSet");
            strSql.Append(" where RelateType=@RelateType and Activity_ID=@Activity_ID and Participants_ID=@Participants_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RelateType", SqlDbType.NVarChar,64),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16)			};
            parameters[0].Value = model.RelateType;
            parameters[1].Value = model.Activity.ID;
            parameters[2].Value = model.Participants.ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Suzy.Outside.Model.ActivityParticipantsMap model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActivityParticipantsMapSet(");
			strSql.Append("ID,RelateType,CreateTime,Activity_ID,Participants_ID,Email,Tel)");
			strSql.Append(" values (");
			strSql.Append("@ID,@RelateType,@CreateTime,@Activity_ID,@Participants_ID,@Email,@Tel)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@RelateType", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16),
					new SqlParameter("@Email", SqlDbType.VarChar,64),
					new SqlParameter("@Tel", SqlDbType.Char,11)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.RelateType;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.Activity.ID;
			parameters[4].Value = model.Participants.ID;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.Tel;

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
		public bool Update(Suzy.Outside.Model.ActivityParticipantsMap model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActivityParticipantsMapSet set ");
			strSql.Append("RelateType=@RelateType,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("Email=@Email,");
			strSql.Append("Tel=@Tel");
			strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Participants_ID=@Participants_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RelateType", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Email", SqlDbType.VarChar,64),
					new SqlParameter("@Tel", SqlDbType.Char,11),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16)};
			parameters[0].Value = model.RelateType;
			parameters[1].Value = model.CreateTime;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.Tel;
			parameters[4].Value = model.ID;
			parameters[5].Value = model.Activity.ID;
			parameters[6].Value = model.Participants.ID;

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
		public bool Delete(string ID,string Activity_ID,string Participants_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityParticipantsMapSet ");
			strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Participants_ID=@Participants_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Activity_ID;
			parameters[2].Value = Participants_ID;

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

        public bool Delete(Model.ActivityParticipantsMap  map)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ActivityParticipantsMapSet ");
            strSql.Append(" where  RelateType=@RelateType and Activity_ID=@Activity_ID and Participants_ID=@Participants_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RelateType", SqlDbType.NVarChar,64),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16)			};
            parameters[0].Value = map.RelateType;
            parameters[1].Value = map.Activity.ID;
            parameters[2].Value =map.Participants.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public Suzy.Outside.Model.ActivityParticipantsMap GetModel(string ID,string Activity_ID,string Participants_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,RelateType,CreateTime,Activity_ID,Participants_ID,Email,Tel from ActivityParticipantsMapSet ");
			strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Participants_ID=@Participants_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Participants_ID", SqlDbType.Char,16)			};
			parameters[0].Value = ID;
			parameters[1].Value = Activity_ID;
			parameters[2].Value = Participants_ID;

			Suzy.Outside.Model.ActivityParticipantsMap model=new Suzy.Outside.Model.ActivityParticipantsMap();
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
		public Suzy.Outside.Model.ActivityParticipantsMap DataRowToModel(DataRow row)
		{
			Suzy.Outside.Model.ActivityParticipantsMap model=new Suzy.Outside.Model.ActivityParticipantsMap();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["RelateType"]!=null)
				{
					model.RelateType=row["RelateType"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["Activity_ID"]!=null)
				{
					model.Activity.ID=row["Activity_ID"].ToString();
				}
				if(row["Participants_ID"]!=null)
				{
					model.Participants.ID=row["Participants_ID"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
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
			strSql.Append("select ID,RelateType,CreateTime,Activity_ID,Participants_ID,Email,Tel ");
			strSql.Append(" FROM ActivityParticipantsMapSet ");
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
			strSql.Append(" ID,RelateType,CreateTime,Activity_ID,Participants_ID,Email,Tel ");
			strSql.Append(" FROM ActivityParticipantsMapSet ");
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
			strSql.Append("select count(1) FROM ActivityParticipantsMapSet ");
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
				strSql.Append("order by T.Participants_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ActivityParticipantsMapSet T ");
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
			parameters[0].Value = "ActivityParticipantsMapSet";
			parameters[1].Value = "Participants_ID";
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

