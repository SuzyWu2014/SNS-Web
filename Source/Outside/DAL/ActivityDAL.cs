
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Suzy.Outside.DAL
{
    /// <summary>
    /// 数据访问类:ActivityDAL
    /// </summary>
    public partial class ActivityDAL
    {
        public ActivityDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID, string ActivityIdeasID, string Sponsor_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ActivitySet");
            strSql.Append(" where ID=@ID and ActivityIdeasID=@ActivityIdeasID and Sponsor_ID=@Sponsor_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeasID", SqlDbType.Char,16),
					new SqlParameter("@Sponsor_ID", SqlDbType.Char,16)			};
            parameters[0].Value = ID;
            parameters[1].Value = ActivityIdeasID;
            parameters[2].Value = Sponsor_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Suzy.Outside.Model.Activity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ActivitySet(");
            strSql.Append("ID,Topic,CreateTime,ActivityType,TimeDes,TimeCycle,PosterPath,PlaceType,University,Place,CountJoin,CountRecommend,CountCollect,ActivityStatus,AdminAttitude,fee,Detail,Tag,ActivityIdeasID,Sponsor_ID,IsNeedContact)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Topic,@CreateTime,@ActivityType,@TimeDes,@TimeCycle,@PosterPath,@PlaceType,@University,@Place,@CountJoin,@CountRecommend,@CountCollect,@ActivityStatus,@AdminAttitude,@fee,@Detail,@Tag,@ActivityIdeasID,@Sponsor_ID,@IsNeedContact)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@Topic", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ActivityType", SqlDbType.NVarChar,32),
					new SqlParameter("@TimeDes", SqlDbType.NChar,64),
					new SqlParameter("@TimeCycle", SqlDbType.NChar,10),
					new SqlParameter("@PosterPath", SqlDbType.NVarChar,128),
					new SqlParameter("@PlaceType", SqlDbType.NVarChar,16),
					new SqlParameter("@University", SqlDbType.NVarChar,64),
					new SqlParameter("@Place", SqlDbType.NVarChar,128),
					new SqlParameter("@CountJoin", SqlDbType.Int,4),
					new SqlParameter("@CountRecommend", SqlDbType.Int,4),
					new SqlParameter("@CountCollect", SqlDbType.Int,4),
					new SqlParameter("@ActivityStatus", SqlDbType.NVarChar,32),
					new SqlParameter("@AdminAttitude", SqlDbType.NChar,32),
					new SqlParameter("@fee", SqlDbType.Float,8),
					new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,64),
					new SqlParameter("@ActivityIdeasID", SqlDbType.Char,16),
					new SqlParameter("@Sponsor_ID", SqlDbType.Char,16),
					new SqlParameter("@IsNeedContact", SqlDbType.Bit,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Topic;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.ActivityType;
            parameters[4].Value = model.TimeDes;
            parameters[5].Value = model.TimeCycle;
            parameters[6].Value = model.PosterPath;
            parameters[7].Value = model.PlaceType;
            parameters[8].Value = model.University;
            parameters[9].Value = model.Place;
            parameters[10].Value = model.CountJoin;
            parameters[11].Value = model.CountRecommend;
            parameters[12].Value = model.CountCollect;
            parameters[13].Value = model.ActivityStatus;
            parameters[14].Value = model.AdminAttitude;
            parameters[15].Value = model.fee;
            parameters[16].Value = model.Detail;
            parameters[17].Value = model.Tag;
            parameters[18].Value = model.ActivityIdeas == null ? null : model.ActivityIdeas.ID;
            parameters[19].Value = model.Sponsor.ID;
            parameters[20].Value = model.IsNeedContact;

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
        public bool Update(Suzy.Outside.Model.Activity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ActivitySet set ");
            strSql.Append("Topic=@Topic,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("ActivityType=@ActivityType,");
            strSql.Append("TimeDes=@TimeDes,");
            strSql.Append("TimeCycle=@TimeCycle,");
            strSql.Append("PosterPath=@PosterPath,");
            strSql.Append("PlaceType=@PlaceType,");
            strSql.Append("University=@University,");
            strSql.Append("Place=@Place,");
            strSql.Append("CountJoin=@CountJoin,");
            strSql.Append("CountRecommend=@CountRecommend,");
            strSql.Append("CountCollect=@CountCollect,");
            strSql.Append("ActivityStatus=@ActivityStatus,");
            strSql.Append("AdminAttitude=@AdminAttitude,");
            strSql.Append("fee=@fee,");
            strSql.Append("Detail=@Detail,");
            strSql.Append("Tag=@Tag");
            strSql.Append("IsNeedContact=@IsNeedContact");
            strSql.Append(" where ID=@ID and ActivityIdeasID=@ActivityIdeasID and Sponsor_ID=@Sponsor_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Topic", SqlDbType.NVarChar,64),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ActivityType", SqlDbType.NVarChar,32),
					new SqlParameter("@TimeDes", SqlDbType.NChar,64),
					new SqlParameter("@TimeCycle", SqlDbType.NChar,10),
					new SqlParameter("@PosterPath", SqlDbType.NVarChar,128),
					new SqlParameter("@PlaceType", SqlDbType.NVarChar,16),
					new SqlParameter("@University", SqlDbType.NVarChar,64),
					new SqlParameter("@Place", SqlDbType.NVarChar,128),
					new SqlParameter("@CountJoin", SqlDbType.Int,4),
					new SqlParameter("@CountRecommend", SqlDbType.Int,4),
					new SqlParameter("@CountCollect", SqlDbType.Int,4),
					new SqlParameter("@ActivityStatus", SqlDbType.NVarChar,32),
					new SqlParameter("@AdminAttitude", SqlDbType.NChar,32),
					new SqlParameter("@fee", SqlDbType.Float,8),
					new SqlParameter("@Detail", SqlDbType.NVarChar,-1),
					new SqlParameter("@Tag", SqlDbType.NVarChar,64),
                    new SqlParameter("@IsNeedContact", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeasID", SqlDbType.Char,16),
					new SqlParameter("@Sponsor_ID", SqlDbType.Char,16)};
            parameters[0].Value = model.Topic;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.ActivityType;
            parameters[3].Value = model.TimeDes;
            parameters[4].Value = model.TimeCycle;
            parameters[5].Value = model.PosterPath;
            parameters[6].Value = model.PlaceType;
            parameters[7].Value = model.University;
            parameters[8].Value = model.Place;
            parameters[9].Value = model.CountJoin;
            parameters[10].Value = model.CountRecommend;
            parameters[11].Value = model.CountCollect;
            parameters[12].Value = model.ActivityStatus;
            parameters[13].Value = model.AdminAttitude;
            parameters[14].Value = model.fee;
            parameters[15].Value = model.Detail;
            parameters[16].Value = model.Tag;
            parameters[17].Value = model.IsNeedContact;
            parameters[18].Value = model.ID;
            parameters[19].Value = model.ActivityIdeas.ID;
            parameters[20].Value = model.Sponsor.ID;

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
        public bool Delete(string ID, string ActivityIdeasID, string Sponsor_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ActivitySet ");
            strSql.Append(" where ID=@ID and ActivityIdeasID=@ActivityIdeasID and Sponsor_ID=@Sponsor_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16),
					new SqlParameter("@ActivityIdeasID", SqlDbType.Char,16),
					new SqlParameter("@Sponsor_ID", SqlDbType.Char,16)			};
            parameters[0].Value = ID;
            parameters[1].Value = ActivityIdeasID;
            parameters[2].Value = Sponsor_ID;

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
        public Suzy.Outside.Model.Activity GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Topic,CreateTime,ActivityType,TimeDes,TimeCycle,PosterPath,PlaceType,University,Place,CountJoin,CountRecommend,CountCollect,ActivityStatus,AdminAttitude,fee,Detail,Tag,ActivityIdeasID,Sponsor_ID,IsNeedContact  from ActivitySet ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Char,16)
				 };
            parameters[0].Value = ID;
            Suzy.Outside.Model.Activity model = new Suzy.Outside.Model.Activity();
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
        public Suzy.Outside.Model.Activity DataRowToModel(DataRow row)
        {
            Suzy.Outside.Model.Activity model = new Suzy.Outside.Model.Activity();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["Topic"] != null)
                {
                    model.Topic = row["Topic"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["ActivityType"] != null)
                {
                    model.ActivityType = row["ActivityType"].ToString();
                }
                if (row["TimeDes"] != null)
                {
                    model.TimeDes = row["TimeDes"].ToString();
                }
                if (row["TimeCycle"] != null)
                {
                    model.TimeCycle = row["TimeCycle"].ToString();
                }
                if (row["PosterPath"] != null)
                {
                    model.PosterPath = row["PosterPath"].ToString();
                }
                if (row["PlaceType"] != null)
                {
                    model.PlaceType = row["PlaceType"].ToString();
                }
                if (row["University"] != null)
                {
                    model.University = row["University"].ToString();
                }
                if (row["Place"] != null)
                {
                    model.Place = row["Place"].ToString();
                }
                if (row["CountJoin"] != null && row["CountJoin"].ToString() != "")
                {
                    model.CountJoin = int.Parse(row["CountJoin"].ToString());
                }
                if (row["CountRecommend"] != null && row["CountRecommend"].ToString() != "")
                {
                    model.CountRecommend = int.Parse(row["CountRecommend"].ToString());
                }
                if (row["CountCollect"] != null && row["CountCollect"].ToString() != "")
                {
                    model.CountCollect = int.Parse(row["CountCollect"].ToString());
                }
                if (row["ActivityStatus"] != null)
                {
                    model.ActivityStatus = row["ActivityStatus"].ToString();
                }
                if (row["AdminAttitude"] != null)
                {
                    model.AdminAttitude = row["AdminAttitude"].ToString();
                }
                if (row["fee"] != null && row["fee"].ToString() != "")
                {
                    model.fee = decimal.Parse(row["fee"].ToString());
                }
                if (row["Detail"] != null)
                {
                    model.Detail = row["Detail"].ToString();
                }
                if (row["Tag"] != null)
                {
                    model.Tag = row["Tag"].ToString();
                }
                if (row["Sponsor_ID"] != null)
                {
                    CustomerDAL dal = new CustomerDAL();
                    model.Sponsor = dal.GetModel(row["Sponsor_ID"].ToString(), 0);

                    if (row["ActivityIdeasID"] != null)
                    {
                        ActivityIdeasDAL idal = new ActivityIdeasDAL();
                        model.ActivityIdeas = idal.GetModel(row["ActivityIdeasID"].ToString() );
                    }
                }
                if (row["IsNeedContact"] != null && row["IsNeedContact"].ToString() != "")
                {
                    if ((row["IsNeedContact"].ToString() == "1") || (row["IsNeedContact"].ToString().ToLower() == "true"))
                    {
                        model.IsNeedContact = true;
                    }
                    else
                    {
                        model.IsNeedContact = false;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Topic,CreateTime,ActivityType,TimeDes,TimeCycle,PosterPath,PlaceType,University,Place,CountJoin,CountRecommend,CountCollect,ActivityStatus,AdminAttitude,fee,Detail,Tag,ActivityIdeasID,Sponsor_ID,IsNeedContact ");
            strSql.Append(" FROM ActivitySet  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSearchResult(string keyword)
        {
            string strSql = "select ID,Topic,CreateTime,ActivityType,TimeDes,TimeCycle,PosterPath,PlaceType,University,Place,CountJoin,CountRecommend,CountCollect,ActivityStatus,AdminAttitude,fee,Detail,Tag,ActivityIdeasID,Sponsor_ID,IsNeedContact FROM ActivitySet where Detail like @kw OR Topic LIKE @kw OR Tag LIKE @kw OR University LIKE @kw ";

            SqlParameter[] paras = { 
                                   
                                   new SqlParameter("@kw",SqlDbType.VarChar)
                                   };
            paras[0].Value = "%"+keyword+"%";

            return DbHelperSQL.Query(strSql, paras);
        }

        public DataSet GetIntertedList(string Uid)
        {
            string strWhere = "ID IN(select Activity_ID  from  ActivityParticipantsMapSet WHERE RelateType='insterested' AND Participants_ID='"+Uid+"')";
            return GetList(strWhere);
        }
        public DataSet GetJoinedList(string Uid)
        {
            string strWhere = "ID IN(select Activity_ID  from  ActivityParticipantsMapSet WHERE RelateType='join' AND Participants_ID='" + Uid + "')";
            return GetList(strWhere);
        }
        public DataSet GetLaurchedList(string Uid)
        {
            string strWhere = "Sponsor_ID ='" + Uid + "'";
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
            strSql.Append(" ID,Topic,CreateTime,ActivityType,TimeDes,TimeCycle,PosterPath,PlaceType,University,Place,CountJoin,CountRecommend,CountCollect,ActivityStatus,AdminAttitude,fee,Detail,Tag,ActivityIdeasID,Sponsor_ID,IsNeedContact ");
            strSql.Append(" FROM ActivitySet ");
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
            strSql.Append("select count(1) FROM ActivitySet ");
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
                strSql.Append("order by T.Sponsor_ID desc");
            }
            strSql.Append(")AS Row, T.*  from ActivitySet T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string aType, int[] dayRange, string peopleRange, int startIndex, int endIndex)
        {
            List<string> sql = new List<string>();
            if (aType != "all")
            {
                sql.Add("ActivityType LIKE '" + aType + "%' ");
            }
            if (dayRange != null)
            {
                if (dayRange[0] != -1)
                {
                    sql.Add("ID IN  (select  ActivityTime.Activity_ID    from ActivityTime where   datediff(day,getdate(), ActivityTime.StartTime)   BETWEEN " + dayRange[0] + "AND " + dayRange[1] + " group by ActivityTime.Activity_ID )");
                }
                else
                {
                    sql.Add("ID IN  (select  ActivityTime.Activity_ID   from ActivityTime where  ActivityTime.Week='Saturday' or ActivityTime.Week='Sunday'  group by ActivityTime.Activity_ID )");
                }
            }
            else
            { 
               //时间为全部
            }
            if (peopleRange != "all")
            {
                sql.Add("Sponsor_ID IN  (SELECT  Idol_ID  FROM FansIdolMapSet WHERE Fans_ID='" + peopleRange + "')");
            }

           
            return GetListByPage(string.Join(" and ", sql.ToArray()), "", startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere)
        //{
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@strGetFields ", SqlDbType.VarChar, 1000),
        //             new SqlParameter("@OrderfldName ", SqlDbType.VarChar,255),
        //            new SqlParameter("@PageSize", SqlDbType.Int),
        //            new SqlParameter("@PageIndex", SqlDbType.Int),
        //            new SqlParameter("@doCount", SqlDbType.Int),
        //            new SqlParameter("@OrderType", SqlDbType.Bit),
        //            new SqlParameter("@strWhere", SqlDbType.VarChar,1000) 
        //            };
        //    parameters[0].Value = "ActivitySet,CustomerSet";
        //    parameters[1].Value = "*";
        //    parameters[2].Value = null;
        //    parameters[3].Value = PageSize;
        //    parameters[4].Value = PageIndex;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = 0;
        //    parameters[7].Value = strWhere;
        //    return DbHelperSQL.RunProcedure("SqlPager", parameters, "ds");
        //}

        public DataSet GetUnchekedListByPage(int PageSize, int PageIndex)
        {
            SqlParameter[] parameters = { 
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int) 
                    }; 
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex; 
            return DbHelperSQL.RunProcedure("Usp_getPagedUncheckedActivity", parameters, "ds");
        }

        public DataSet  GetListByPage(int PageSize, int PageIndex)
        {
            SqlParameter[] parameters = { 
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int) 
                    };
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            return DbHelperSQL.RunProcedure("Usp_getPagedActivity", parameters, "ds");
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 活动参加人数+/-1  
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public bool UpdateCountJoin(string activityId, int type)
        {
            string sql = string.Empty;
            if (type == 0)
            {
                //活动参与人数+1
                sql = @"UPDATE ActivitySet SET CountJoin=CountJoin+1 WHERE ID=@ID";
            }
            else
            {
                //人数-1
                sql = @"UPDATE ActivitySet SET CountJoin=CountJoin-1 WHERE ID=@ID";
            }

            SqlParameter[] para = { 
                              new SqlParameter("@ID", SqlDbType.Char,16)
                                  };
            para[0].Value = activityId;

            return DbHelperSQL.ExecuteSql(sql,para) > 0 ? true : false;
        }


        public bool UpdateCountInterest(string actId, int type)
        {
            string sql = string.Empty;
            if (type == 0)
            {
                //活动参与感兴趣人数+1
                sql = @"UPDATE ActivitySet SET CountCollect=CountCollect+1 WHERE ID=@ID";
            }
            else
            {
                //人数-1
                sql = @"UPDATE ActivitySet SET CountCollect=CountCollect-1 WHERE ID=@ID";
            }

            SqlParameter[] para = { 
                              new SqlParameter("@ID", SqlDbType.Char,16)
                                  };
            para[0].Value = actId;

            return DbHelperSQL.ExecuteSql(sql,para) > 0 ? true : false;
        }

        //活动通过审核
        public bool SetChecked(string Id)
        {
            string sql = @"UPDATE ActivitySet SET AdminAttitude='已审核' WHERE ID=@ID";
            SqlParameter[] para = { 
                              new SqlParameter("@ID", SqlDbType.Char,16)
                                  };
            para[0].Value = Id;
            return DbHelperSQL.ExecuteSql(sql, para) > 0 ? true : false;
        }

        //批量审核
        public bool SetActsChecked(string ids)
        {
            string sql =  "UPDATE ActivitySet SET AdminAttitude='已审核' WHERE ID IN ("+ids+")";
            return DbHelperSQL.ExecuteSql(sql) > 0 ? true : false;
        }
        //活动推荐
        public bool SetRecommended(string Id)
        {
            string sql = @"UPDATE ActivitySet SET AdminAttitude='推荐' WHERE ID=@ID";
            SqlParameter[] para = { 
                              new SqlParameter("@ID", SqlDbType.Char,16)
                                  };
            para[0].Value = Id;
            return DbHelperSQL.ExecuteSql(sql, para) > 0 ? true : false;
        }
        //批量活动推荐
        public bool SetActsRecommended(string ids)
        {
            string sql = "UPDATE ActivitySet SET AdminAttitude='推荐' WHERE ID IN (" + ids + ")";
            return DbHelperSQL.ExecuteSql(sql) > 0 ? true : false;
        }

        //审核不通过
        public bool SetRefused(string Id)
        {
            string sql = @"UPDATE ActivitySet SET AdminAttitude='拒绝' WHERE ID=@ID";
            SqlParameter[] para = { 
                              new SqlParameter("@ID", SqlDbType.Char,16)
                                  };
            para[0].Value = Id;
            return DbHelperSQL.ExecuteSql(sql, para) > 0 ? true : false;
        }
        //批量拒绝
        public bool SetActsRefused(string ids)
        {
            string sql = "UPDATE ActivitySet SET AdminAttitude='拒绝' WHERE ID IN (" + ids + ")";
            return DbHelperSQL.ExecuteSql(sql) > 0 ? true : false;
        }
        #endregion  ExtensionMethod
    }
}

