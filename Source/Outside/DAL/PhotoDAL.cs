using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Suzy.Outside.DAL
{
    /// <summary>
    /// 数据访问类:PhotoDAL
    /// </summary>
    public partial class PhotoDAL
    {
        public PhotoDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID, string Activity_ID, string Album_ID, string Uploader_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PhotoSet");
            strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Album_ID=@Album_ID and Uploader_ID=@Uploader_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Album_ID", SqlDbType.Char,16),
					new SqlParameter("@Uploader_ID", SqlDbType.Char,16)			};
            parameters[0].Value = ID;
            parameters[1].Value = Activity_ID;
            parameters[2].Value = Album_ID;
            parameters[3].Value = Uploader_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Suzy.Outside.Model.Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PhotoSet(");
            strSql.Append("ID,ImageSmallPath,ImageBigPath,Title,Des,UploadTime,Activity_ID,Album_ID,Uploader_ID)");
            strSql.Append(" values (");
            strSql.Append("@ID,@ImageSmallPath,@ImageBigPath,@Title,@Des,@UploadTime,@Activity_ID,@Album_ID,@Uploader_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ImageSmallPath", SqlDbType.NVarChar,128),
					new SqlParameter("@ImageBigPath", SqlDbType.NVarChar,128),
					new SqlParameter("@Title", SqlDbType.NVarChar,32),
					new SqlParameter("@Des", SqlDbType.NVarChar,64),
					new SqlParameter("@UploadTime", SqlDbType.DateTime),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Album_ID", SqlDbType.Char,16),
					new SqlParameter("@Uploader_ID", SqlDbType.Char,16)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ImageSmallPath;
            parameters[2].Value = model.ImageBigPath;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Des;
            parameters[5].Value = model.UploadTime;
            parameters[6].Value = model.Activity.ID;
            parameters[7].Value = model.Album.ID;
            parameters[8].Value = model.Uploader.ID;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Suzy.Outside.Model.Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PhotoSet set ");
            strSql.Append("ImageSmallPath=@ImageSmallPath,");
            strSql.Append("ImageBigPath=@ImageBigPath,");
            strSql.Append("Title=@Title,");
            strSql.Append("Des=@Des,");
            strSql.Append("UploadTime=@UploadTime");
            strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Album_ID=@Album_ID and Uploader_ID=@Uploader_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ImageSmallPath", SqlDbType.NVarChar,128),
					new SqlParameter("@ImageBigPath", SqlDbType.NVarChar,128),
					new SqlParameter("@Title", SqlDbType.NVarChar,32),
					new SqlParameter("@Des", SqlDbType.NVarChar,64),
					new SqlParameter("@UploadTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Album_ID", SqlDbType.Char,16),
					new SqlParameter("@Uploader_ID", SqlDbType.Char,16)};
            parameters[0].Value = model.ImageSmallPath;
            parameters[1].Value = model.ImageBigPath;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Des;
            parameters[4].Value = model.UploadTime;
            parameters[5].Value = model.ID;
            parameters[6].Value = model.Activity.ID;
            parameters[7].Value = model.Album.ID;
            parameters[8].Value = model.Uploader.ID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID, string Activity_ID, string Album_ID, string Uploader_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PhotoSet ");
            strSql.Append(" where ID=@ID and Activity_ID=@Activity_ID and Album_ID=@Album_ID and Uploader_ID=@Uploader_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Activity_ID", SqlDbType.Char,16),
					new SqlParameter("@Album_ID", SqlDbType.Char,16),
					new SqlParameter("@Uploader_ID", SqlDbType.Char,16)			};
            parameters[0].Value = ID;
            parameters[1].Value = Activity_ID;
            parameters[2].Value = Album_ID;
            parameters[3].Value = Uploader_ID;

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
        public Suzy.Outside.Model.Photo GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ImageSmallPath,ImageBigPath,Title,Des,UploadTime,Activity_ID,Album_ID,Uploader_ID from PhotoSet ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16)
					};
            parameters[0].Value = ID;

            Suzy.Outside.Model.Photo model = new Suzy.Outside.Model.Photo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Suzy.Outside.Model.Photo DataRowToModel(DataRow row)
        {
            Suzy.Outside.Model.Photo model = new Suzy.Outside.Model.Photo();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["ImageSmallPath"] != null)
                {
                    model.ImageSmallPath = row["ImageSmallPath"].ToString();
                }
                if (row["ImageBigPath"] != null)
                {
                    model.ImageBigPath = row["ImageBigPath"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Des"] != null)
                {
                    model.Des = row["Des"].ToString();
                }
                if (row["UploadTime"] != null && row["UploadTime"].ToString() != "")
                {
                    model.UploadTime = DateTime.Parse(row["UploadTime"].ToString());
                }
                if (row["Activity_ID"] != null)
                {
                    ActivityDAL dal = new ActivityDAL();
                    model.Activity = dal.GetModel(row["Activity_ID"].ToString());
                }
                if (row["Album_ID"] != null)
                {
                    AlbumDAL dal = new AlbumDAL();
                    model.Album = dal.GetModel(row["Album_ID"].ToString());
                }
                if (row["Uploader_ID"] != null)
                {
                    CustomerDAL dal = new CustomerDAL();
                    model.Uploader = dal.GetModel(row["Uploader_ID"].ToString(),0);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ImageSmallPath,ImageBigPath,Title,Des,UploadTime,Activity_ID,Album_ID,Uploader_ID ");
            strSql.Append(" FROM PhotoSet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ImageSmallPath,ImageBigPath,Title,Des,UploadTime,Activity_ID,Album_ID,Uploader_ID ");
            strSql.Append(" FROM PhotoSet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PhotoSet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Uploader_ID desc");
            }
            strSql.Append(")AS Row, T.*  from PhotoSet T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListByPage(string aType, int[] dayRange, string peopleRange,  int startIndex, int endIndex)
        {
            List<string> actsql = new List<string>(); 
            if (aType != "all")
            {
                actsql.Add("ActivityType LIKE '" + aType + "%' ");
            }
            if (dayRange != null)
            {
                if (dayRange[0] != -1)
                {
                    actsql.Add("ID IN  (select  ActivityTime.Activity_ID    from ActivityTime where   datediff(day,getdate(), ActivityTime.StartTime)   BETWEEN " + dayRange[0] + "AND " + dayRange[1] + " group by ActivityTime.Activity_ID )");

                }
                else
                {
                    //周末
                    actsql.Add("ID IN  (select  ActivityTime.Activity_ID   from ActivityTime where  ActivityTime.Week='Saturday' or ActivityTime.Week='Sunday'  group by ActivityTime.Activity_ID )");
                }
            }
            else
            {
                //时间为全部
            }
            if (peopleRange != "all")
            {
                actsql.Add("Sponsor_ID IN  (SELECT  Idol_ID  FROM FansIdolMapSet WHERE Fans_ID='" + peopleRange + "')");
            }
            string str=string.Join(" and ", actsql.ToArray());
            string strWhere=string.Empty;
            if( !string.IsNullOrEmpty(str))
            {
                 strWhere = "Activity_ID IN (SELECT ID from ActivitySet where  "+str+")";
            }
            return GetListByPage(strWhere, "UploadTime DESC", startIndex, endIndex);
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
            parameters[0].Value = "PhotoSet";
            parameters[1].Value = "Uploader_ID";
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

