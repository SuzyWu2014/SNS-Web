using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Suzy.Outside.Model;//Please add references
namespace Suzy.Outside.DAL
{
    /// <summary>
    /// 数据访问类:CustomerDAL
    /// </summary>
    public partial class CustomerDAL
    {
        public CustomerDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录-----------------------------------------------------------------------------
        /// </summary>
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CustomerSet");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,64)			};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Suzy.Outside.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CustomerSet(");
            strSql.Append("ID,UserName,Password,Email,IntroSelf,University,College,IsCollegePrivate,Major,IsMajorPrivate,HeadPortraitPath,CreateTime,EntranceYear,IsEntraceYearPrivate,IsOrganization,Nickname,CountFans,CountActivities,RealName,IsRealNamePrivate,Tag,Score,InvitationCode_ID,Sex)");
            strSql.Append(" values (");
            strSql.Append("@ID,@UserName,@Password,@Email,@IntroSelf,@University,@College,@IsCollegePrivate,@Major,@IsMajorPrivate,@HeadPortraitPath,@CreateTime,@EntranceYear,@IsEntraceYearPrivate,@IsOrganization,@Nickname,@CountFans,@CountActivities,@RealName,@IsRealNamePrivate,@Tag,@Score,@InvitationCode_ID,@Sex)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@UserName", SqlDbType.NVarChar,64),
					new SqlParameter("@Password", SqlDbType.NVarChar,64),
					new SqlParameter("@Email", SqlDbType.NVarChar,128),
					new SqlParameter("@IntroSelf", SqlDbType.NVarChar,-1),
					new SqlParameter("@University", SqlDbType.NVarChar,64),
					new SqlParameter("@College", SqlDbType.NVarChar,32),
					new SqlParameter("@IsCollegePrivate", SqlDbType.Bit,1),
					new SqlParameter("@Major", SqlDbType.NVarChar,32),
					new SqlParameter("@IsMajorPrivate", SqlDbType.Bit,1),
					new SqlParameter("@HeadPortraitPath", SqlDbType.NVarChar,128),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@EntranceYear", SqlDbType.NVarChar,4),
					new SqlParameter("@IsEntraceYearPrivate", SqlDbType.Bit,1),
					new SqlParameter("@IsOrganization", SqlDbType.Bit,1),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,64),
					new SqlParameter("@CountFans", SqlDbType.Int,4),
					new SqlParameter("@CountActivities", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,64),
					new SqlParameter("@IsRealNamePrivate", SqlDbType.Bit,1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,64),
					new SqlParameter("@Score", SqlDbType.BigInt,8),
					new SqlParameter("@InvitationCode_ID", SqlDbType.Char,16),
                    new SqlParameter("@Sex", SqlDbType.NVarChar,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.IntroSelf;
            parameters[5].Value = model.University;
            parameters[6].Value = model.College;
            parameters[7].Value = model.IsCollegePrivate;
            parameters[8].Value = model.Major;
            parameters[9].Value = model.IsMajorPrivate;
            parameters[10].Value = model.HeadPortraitPath;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.EntranceYear;
            parameters[13].Value = model.IsEntraceYearPrivate;
            parameters[14].Value = model.IsOrganization;
            parameters[15].Value = model.Nickname;
            parameters[16].Value = model.CountFans;
            parameters[17].Value = model.CountActivities;
            parameters[18].Value = model.RealName;
            parameters[19].Value = model.IsRealNamePrivate;
            parameters[20].Value = model.Tag;
            parameters[21].Value = model.Score;
            parameters[22].Value = model.InvitationCode == null ? null : model.InvitationCode.ID;
            parameters[23].Value = model.Sex;

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
        public bool Update(Suzy.Outside.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CustomerSet set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("Email=@Email,");
            strSql.Append("IntroSelf=@IntroSelf,");
            strSql.Append("University=@University,");
            strSql.Append("College=@College,");
            strSql.Append("IsCollegePrivate=@IsCollegePrivate,");
            strSql.Append("Major=@Major,");
            strSql.Append("IsMajorPrivate=@IsMajorPrivate,");
            strSql.Append("HeadPortraitPath=@HeadPortraitPath,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("EntranceYear=@EntranceYear,");
            strSql.Append("IsEntraceYearPrivate=@IsEntraceYearPrivate,");
            strSql.Append("IsOrganization=@IsOrganization,");
            strSql.Append("Nickname=@Nickname,");
            strSql.Append("CountFans=@CountFans,");
            strSql.Append("CountActivities=@CountActivities,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("IsRealNamePrivate=@IsRealNamePrivate,");
            strSql.Append("Tag=@Tag,");
            strSql.Append("Score=@Score,");
            strSql.Append("InvitationCode_ID=@InvitationCode_ID,");
            strSql.Append("Sex=@Sex ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,64),
					new SqlParameter("@Password", SqlDbType.NVarChar,64),
					new SqlParameter("@Email", SqlDbType.NVarChar,128),
					new SqlParameter("@IntroSelf", SqlDbType.NVarChar,-1),
					new SqlParameter("@University", SqlDbType.NVarChar,64),
					new SqlParameter("@College", SqlDbType.NVarChar,32),
					new SqlParameter("@IsCollegePrivate", SqlDbType.Bit,1),
					new SqlParameter("@Major", SqlDbType.NVarChar,32),
					new SqlParameter("@IsMajorPrivate", SqlDbType.Bit,1),
					new SqlParameter("@HeadPortraitPath", SqlDbType.NVarChar,128),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@EntranceYear", SqlDbType.NVarChar,4),
					new SqlParameter("@IsEntraceYearPrivate", SqlDbType.Bit,1),
					new SqlParameter("@IsOrganization", SqlDbType.Bit,1),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,64),
					new SqlParameter("@CountFans", SqlDbType.Int,4),
					new SqlParameter("@CountActivities", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,64),
					new SqlParameter("@IsRealNamePrivate", SqlDbType.Bit,1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,64),
					new SqlParameter("@Score", SqlDbType.BigInt,8),
					new SqlParameter("@InvitationCode_ID", SqlDbType.Char,16),
					new SqlParameter("@ID", SqlDbType.Char,16),
                     new SqlParameter("@Sex", SqlDbType.NVarChar,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.IntroSelf;
            parameters[4].Value = model.University;
            parameters[5].Value = model.College;
            parameters[6].Value = model.IsCollegePrivate;
            parameters[7].Value = model.Major;
            parameters[8].Value = model.IsMajorPrivate;
            parameters[9].Value = model.HeadPortraitPath;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.EntranceYear;
            parameters[12].Value = model.IsEntraceYearPrivate;
            parameters[13].Value = model.IsOrganization;
            parameters[14].Value = model.Nickname;
            parameters[15].Value = model.CountFans;
            parameters[16].Value = model.CountActivities;
            parameters[17].Value = model.RealName;
            parameters[18].Value = model.IsRealNamePrivate;
            parameters[19].Value = model.Tag;
            parameters[20].Value = model.Score;
            parameters[21].Value = model.InvitationCode == null ? "" : model.InvitationCode.ID;
            parameters[22].Value = model.ID;
            parameters[23].Value = model.Sex;

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

        public bool UpdatePortrait(string ID,string url)
        {
            string sqlStr = @"UPDATE CustomerSet SET  HeadPortraitPath=@HeadPortraitPath WHERE ID=@ID ";
            SqlParameter[] parameters = { 
					new SqlParameter("@HeadPortraitPath", SqlDbType.NVarChar,128), 
					new SqlParameter("@ID", SqlDbType.Char,16) 
                                        };
            parameters[0].Value = url;
            parameters[1].Value = ID;
            int rows = DbHelperSQL.ExecuteSql(sqlStr.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CustomerSet ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16)			};
            parameters[0].Value = ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CustomerSet ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体--------------------------------------------------------------------
        /// </summary>
        public Suzy.Outside.Model.Customer GetModel(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,Password,Email,IntroSelf,University,College,IsCollegePrivate,Major,IsMajorPrivate,HeadPortraitPath,CreateTime,EntranceYear,IsEntraceYearPrivate,IsOrganization,Nickname,CountFans,CountActivities,RealName,IsRealNamePrivate,Tag,Score,InvitationCode_ID,Sex from CustomerSet ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,64)			};
            parameters[0].Value = userName;

            Suzy.Outside.Model.Customer model = new Suzy.Outside.Model.Customer();
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

        public Suzy.Outside.Model.Customer GetModel(string ID, int type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,Password,Email,IntroSelf,University,College,IsCollegePrivate,Major,IsMajorPrivate,HeadPortraitPath,CreateTime,EntranceYear,IsEntraceYearPrivate,IsOrganization,Nickname,CountFans,CountActivities,RealName,IsRealNamePrivate,Tag,Score,InvitationCode_ID,Sex from CustomerSet ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,16)			};
            parameters[0].Value = ID;

            Suzy.Outside.Model.Customer model = new Suzy.Outside.Model.Customer();
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
        public Suzy.Outside.Model.Customer DataRowToModel(DataRow row)
        {
            Suzy.Outside.Model.Customer model = new Suzy.Outside.Model.Customer();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["IntroSelf"] != null)
                {
                    model.IntroSelf = row["IntroSelf"].ToString();
                }
                if (row["University"] != null)
                {
                    model.University = row["University"].ToString();
                }
                if (row["College"] != null)
                {
                    model.College = row["College"].ToString();
                }
                if (row["IsCollegePrivate"] != null && row["IsCollegePrivate"].ToString() != "")
                {
                    if ((row["IsCollegePrivate"].ToString() == "1") || (row["IsCollegePrivate"].ToString().ToLower() == "true"))
                    {
                        model.IsCollegePrivate = true;
                    }
                    else
                    {
                        model.IsCollegePrivate = false;
                    }
                }
                if (row["Major"] != null)
                {
                    model.Major = row["Major"].ToString();
                }
                if (row["IsMajorPrivate"] != null && row["IsMajorPrivate"].ToString() != "")
                {
                    if ((row["IsMajorPrivate"].ToString() == "1") || (row["IsMajorPrivate"].ToString().ToLower() == "true"))
                    {
                        model.IsMajorPrivate = true;
                    }
                    else
                    {
                        model.IsMajorPrivate = false;
                    }
                }
                if (row["HeadPortraitPath"] != null)
                {
                    model.HeadPortraitPath = row["HeadPortraitPath"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["EntranceYear"] != null)
                {
                    model.EntranceYear = row["EntranceYear"].ToString();
                }
                if (row["IsEntraceYearPrivate"] != null && row["IsEntraceYearPrivate"].ToString() != "")
                {
                    if ((row["IsEntraceYearPrivate"].ToString() == "1") || (row["IsEntraceYearPrivate"].ToString().ToLower() == "true"))
                    {
                        model.IsEntraceYearPrivate = true;
                    }
                    else
                    {
                        model.IsEntraceYearPrivate = false;
                    }
                }
                if (row["IsOrganization"] != null && row["IsOrganization"].ToString() != "")
                {
                    if ((row["IsOrganization"].ToString() == "1") || (row["IsOrganization"].ToString().ToLower() == "true"))
                    {
                        model.IsOrganization = true;
                    }
                    else
                    {
                        model.IsOrganization = false;
                    }
                }
                if (row["Nickname"] != null)
                {
                    model.Nickname = row["Nickname"].ToString();
                }
                if (row["CountFans"] != null && row["CountFans"].ToString() != "")
                {
                    model.CountFans = int.Parse(row["CountFans"].ToString());
                }
                if (row["CountActivities"] != null && row["CountActivities"].ToString() != "")
                {
                    model.CountActivities = int.Parse(row["CountActivities"].ToString());
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["IsRealNamePrivate"] != null && row["IsRealNamePrivate"].ToString() != "")
                {
                    if ((row["IsRealNamePrivate"].ToString() == "1") || (row["IsRealNamePrivate"].ToString().ToLower() == "true"))
                    {
                        model.IsRealNamePrivate = true;
                    }
                    else
                    {
                        model.IsRealNamePrivate = false;
                    }
                }
                if (row["Tag"] != null)
                {
                    model.Tag = row["Tag"].ToString();
                }
                if (row["Score"] != null && row["Score"].ToString() != "")
                {
                    model.Score = long.Parse(row["Score"].ToString());
                }
                if (row["InvitationCode_ID"] != null)
                {
                    if (!string.IsNullOrEmpty(row["InvitationCode_ID"].ToString()))
                    {
                        InvitationCodeDAL dal = new InvitationCodeDAL();
                        model.InvitationCode = dal.GetModel(row["InvitationCode_ID"].ToString());
                    }


                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = row["Sex"].ToString();
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
            strSql.Append("select ID,UserName,Password,Email,IntroSelf,University,College,IsCollegePrivate,Major,IsMajorPrivate,HeadPortraitPath,CreateTime,EntranceYear,IsEntraceYearPrivate,IsOrganization,Nickname,CountFans,CountActivities,RealName,IsRealNamePrivate,Tag,Score,InvitationCode_ID,Sex ");
            strSql.Append(" FROM CustomerSet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSearchResult(string keyword)
        {

            string strSql = @"select ID,UserName,Password,Email,IntroSelf,University,College,IsCollegePrivate,Major,IsMajorPrivate,HeadPortraitPath,CreateTime,EntranceYear,IsEntraceYearPrivate,IsOrganization,Nickname,CountFans,CountActivities,RealName,IsRealNamePrivate,Tag,Score,InvitationCode_ID,Sex  FROM CustomerSet WHERE   Nickname LIKE @KW  OR  UserName LIKE @KW OR  IntroSelf LIKE @KW OR  University LIKE @KW ";
            SqlParameter[] paras = { 
                                   
                                   new SqlParameter("@KW",SqlDbType.VarChar)
                                   };
            paras[0].Value = "%" + keyword + "%";

            return DbHelperSQL.Query(strSql, paras);
        }
        public DataSet GetFansList(string idolID)
        {
            string strWhere = "ID IN (SELECT Fans_ID from FansIdolMapSet WHERE Idol_ID='" + idolID + "' )";
            return GetList(strWhere);
        }

        public DataSet GetIdolsList(string fansId)
        {
            string strWhere = "ID IN (SELECT Idol_ID from FansIdolMapSet WHERE Fans_ID='" + fansId + "' )";
            return GetList(strWhere);
        }
        public DataSet GetJoinedList(string actId)
        {
            string strWhere = "ID IN (SELECT Participants_ID FROM ActivityParticipantsMapSet WHERE RelateType='join' AND Activity_ID='"+actId+"' )";
            return GetList(strWhere);
        }

        public DataSet GetInterestedList(string actId)
        {
            string strWhere = "ID IN (SELECT Participants_ID FROM ActivityParticipantsMapSet WHERE RelateType='insterested' AND Activity_ID='" + actId + "' )";
            return GetList(strWhere);
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
            strSql.Append(" ID,UserName,Password,Email,IntroSelf,University,College,IsCollegePrivate,Major,IsMajorPrivate,HeadPortraitPath,CreateTime,EntranceYear,IsEntraceYearPrivate,IsOrganization,Nickname,CountFans,CountActivities,RealName,IsRealNamePrivate,Tag,Score,InvitationCode_ID,Sex ");
            strSql.Append(" FROM CustomerSet ");
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
            strSql.Append("select count(1) FROM CustomerSet ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CustomerSet T ");
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
            parameters[0].Value = "CustomerSet";
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

