using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:Menu
    /// </summary>
    public partial class Menu
    {
        public Menu()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("MenuID", "Menu");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MenuID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Menu");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.Int,4)            };
            parameters[0].Value = MenuID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Menu(");
            strSql.Append("MenuID,MenuName,ParentID,Icon,Url)");
            strSql.Append(" values (");
            strSql.Append("@MenuID,@MenuName,@ParentID,@Icon,@Url)");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.Int,4),
                    new SqlParameter("@MenuName", SqlDbType.VarChar,50),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@Icon", SqlDbType.VarChar,10),
                    new SqlParameter("@Url", SqlDbType.VarChar,100)};
            parameters[0].Value = model.MenuID;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Icon;
            parameters[4].Value = model.Url;

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
        public bool Update(DataService.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Menu set ");
            strSql.Append("MenuName=@MenuName,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Url=@Url");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuName", SqlDbType.VarChar,50),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@Icon", SqlDbType.VarChar,10),
                    new SqlParameter("@Url", SqlDbType.VarChar,100),
                    new SqlParameter("@MenuID", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Icon;
            parameters[3].Value = model.Url;
            parameters[4].Value = model.MenuID;

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
        public bool Delete(int MenuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Menu ");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.Int,4)            };
            parameters[0].Value = MenuID;

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
        public bool DeleteList(string MenuIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Menu ");
            strSql.Append(" where MenuID in (" + MenuIDlist + ")  ");
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
        public DataService.Model.Menu GetModel(int MenuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MenuID,MenuName,ParentID,Icon,Url from Menu ");
            strSql.Append(" where MenuID=@MenuID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuID", SqlDbType.Int,4)            };
            parameters[0].Value = MenuID;

            DataService.Model.Menu model = new DataService.Model.Menu();
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
        public DataService.Model.Menu DataRowToModel(DataRow row)
        {
            DataService.Model.Menu model = new DataService.Model.Menu();
            if (row != null)
            {
                if (row["MenuID"] != null && row["MenuID"].ToString() != "")
                {
                    model.MenuID = int.Parse(row["MenuID"].ToString());
                }
                if (row["MenuName"] != null)
                {
                    model.MenuName = row["MenuName"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["Icon"] != null)
                {
                    model.Icon = row["Icon"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
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
            strSql.Append("select MenuID,MenuName,ParentID,Icon,Url ");
            strSql.Append(" FROM Menu ");
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
            strSql.Append(" MenuID,MenuName,ParentID,Icon,Url ");
            strSql.Append(" FROM Menu ");
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
            strSql.Append("select count(1) FROM Menu ");
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
                strSql.Append("order by T.MenuID desc");
            }
            strSql.Append(")AS Row, T.*  from Menu T ");
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
			parameters[0].Value = "Menu";
			parameters[1].Value = "MenuID";
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

