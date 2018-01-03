using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:Role
    /// </summary>
    public partial class Role
    {
        public Role()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RoleID", "Role");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Role");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleID", SqlDbType.Int,4)            };
            parameters[0].Value = RoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Role(");
            strSql.Append("RoleID,RoleName,MenuList,IsAllowCheck,IsAllowDel)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@RoleName,@MenuList,@IsAllowCheck,@IsAllowDel)");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@RoleName", SqlDbType.VarChar,50),
                    new SqlParameter("@MenuList", SqlDbType.VarChar,800),
                    new SqlParameter("@IsAllowCheck", SqlDbType.Bit,1),
                    new SqlParameter("@IsAllowDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.MenuList;
            parameters[3].Value = model.IsAllowCheck;
            parameters[4].Value = model.IsAllowDel;

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
        public bool Update(DataService.Model.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Role set ");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("MenuList=@MenuList,");
            strSql.Append("IsAllowCheck=@IsAllowCheck,");
            strSql.Append("IsAllowDel=@IsAllowDel");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleName", SqlDbType.VarChar,50),
                    new SqlParameter("@MenuList", SqlDbType.VarChar,800),
                    new SqlParameter("@IsAllowCheck", SqlDbType.Bit,1),
                    new SqlParameter("@IsAllowDel", SqlDbType.Bit,1),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.RoleName;
            parameters[1].Value = model.MenuList;
            parameters[2].Value = model.IsAllowCheck;
            parameters[3].Value = model.IsAllowDel;
            parameters[4].Value = model.RoleID;

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
        public bool Delete(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleID", SqlDbType.Int,4)            };
            parameters[0].Value = RoleID;

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
        public bool DeleteList(string RoleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Role ");
            strSql.Append(" where RoleID in (" + RoleIDlist + ")  ");
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
        public DataService.Model.Role GetModel(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RoleID,RoleName,MenuList,IsAllowCheck,IsAllowDel from Role ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleID", SqlDbType.Int,4)            };
            parameters[0].Value = RoleID;

            DataService.Model.Role model = new DataService.Model.Role();
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
        public DataService.Model.Role DataRowToModel(DataRow row)
        {
            DataService.Model.Role model = new DataService.Model.Role();
            if (row != null)
            {
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["MenuList"] != null)
                {
                    model.MenuList = row["MenuList"].ToString();
                }
                if (row["IsAllowCheck"] != null && row["IsAllowCheck"].ToString() != "")
                {
                    if ((row["IsAllowCheck"].ToString() == "1") || (row["IsAllowCheck"].ToString().ToLower() == "true"))
                    {
                        model.IsAllowCheck = true;
                    }
                    else
                    {
                        model.IsAllowCheck = false;
                    }
                }
                if (row["IsAllowDel"] != null && row["IsAllowDel"].ToString() != "")
                {
                    if ((row["IsAllowDel"].ToString() == "1") || (row["IsAllowDel"].ToString().ToLower() == "true"))
                    {
                        model.IsAllowDel = true;
                    }
                    else
                    {
                        model.IsAllowDel = false;
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
            strSql.Append("select RoleID,RoleName,MenuList,IsAllowCheck,IsAllowDel ");
            strSql.Append(" FROM Role ");
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
            strSql.Append(" RoleID,RoleName,MenuList,IsAllowCheck,IsAllowDel ");
            strSql.Append(" FROM Role ");
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
            strSql.Append("select count(1) FROM Role ");
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
                strSql.Append("order by T.RoleID desc");
            }
            strSql.Append(")AS Row, T.*  from Role T ");
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
			parameters[0].Value = "Role";
			parameters[1].Value = "RoleID";
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

