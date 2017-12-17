﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:UserGroup
    /// </summary>
    public partial class UserGroup
    {
        public UserGroup()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("GroupID", "UserGroup");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GroupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserGroup");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GroupID", SqlDbType.Int,4)           };
            parameters[0].Value = GroupID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.UserGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserGroup(");
            strSql.Append("GroupID,UserID,GroupName,Users,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@GroupID,@UserID,@GroupName,@Users,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@GroupName", SqlDbType.NVarChar,500),
                    new SqlParameter("@Users", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.GroupName;
            parameters[3].Value = model.Users;
            parameters[4].Value = model.AddTime;

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
        public bool Update(DataService.Model.UserGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserGroup set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("Users=@Users,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@GroupName", SqlDbType.NVarChar,500),
                    new SqlParameter("@Users", SqlDbType.NVarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@GroupID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.Users;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.GroupID;

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
        public bool Delete(int GroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroup ");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GroupID", SqlDbType.Int,4)           };
            parameters[0].Value = GroupID;

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
        public bool DeleteList(string GroupIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserGroup ");
            strSql.Append(" where GroupID in (" + GroupIDlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.UserGroup GetModel(int GroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GroupID,UserID,GroupName,Users,AddTime from UserGroup ");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GroupID", SqlDbType.Int,4)           };
            parameters[0].Value = GroupID;

            DataService.Model.UserGroup model = new DataService.Model.UserGroup();
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
        public DataService.Model.UserGroup DataRowToModel(DataRow row)
        {
            DataService.Model.UserGroup model = new DataService.Model.UserGroup();
            if (row != null)
            {
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = int.Parse(row["GroupID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["GroupName"] != null)
                {
                    model.GroupName = row["GroupName"].ToString();
                }
                if (row["Users"] != null)
                {
                    model.Users = row["Users"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
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
            strSql.Append("select GroupID,UserID,GroupName,Users,AddTime ");
            strSql.Append(" FROM UserGroup ");
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
            strSql.Append(" GroupID,UserID,GroupName,Users,AddTime ");
            strSql.Append(" FROM UserGroup ");
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
            strSql.Append("select count(1) FROM UserGroup ");
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
                strSql.Append("order by T.GroupID desc");
            }
            strSql.Append(")AS Row, T.*  from UserGroup T ");
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
			parameters[0].Value = "UserGroup";
			parameters[1].Value = "GroupID";
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

