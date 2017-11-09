using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:v_Order
    /// </summary>
    public partial class v_Order
    {
        public v_Order()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_Order");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4)           };
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.v_Order GetModel(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime,TotalNum,total from v_Order ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4)           };
            parameters[0].Value = OrderID;

            DataService.Model.v_Order model = new DataService.Model.v_Order();
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
        public DataService.Model.v_Order DataRowToModel(DataRow row)
        {
            DataService.Model.v_Order model = new DataService.Model.v_Order();
            if (row != null)
            {
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["Use_UserID"] != null && row["Use_UserID"].ToString() != "")
                {
                    model.Use_UserID = int.Parse(row["Use_UserID"].ToString());
                }
                if (row["Buyer"] != null)
                {
                    model.Buyer = row["Buyer"].ToString();
                }
                if (row["ProName"] != null)
                {
                    model.ProName = row["ProName"].ToString();
                }
                if (row["Province"] != null)
                {
                    model.Province = row["Province"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["remarks1"] != null)
                {
                    model.remarks1 = row["remarks1"].ToString();
                }
                if (row["remarks2"] != null)
                {
                    model.remarks2 = row["remarks2"].ToString();
                }
                if (row["IntoDate"] != null && row["IntoDate"].ToString() != "")
                {
                    model.IntoDate = DateTime.Parse(row["IntoDate"].ToString());
                }
                if (row["OrderDate"] != null && row["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                }
                if (row["IsCheck"] != null && row["IsCheck"].ToString() != "")
                {
                    if ((row["IsCheck"].ToString() == "1") || (row["IsCheck"].ToString().ToLower() == "true"))
                    {
                        model.IsCheck = true;
                    }
                    else
                    {
                        model.IsCheck = false;
                    }
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    if ((row["IsDel"].ToString() == "1") || (row["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["TotalNum"] != null && row["TotalNum"].ToString() != "")
                {
                    model.TotalNum = decimal.Parse(row["TotalNum"].ToString());
                }
                if (row["total"] != null && row["total"].ToString() != "")
                {
                    model.total = decimal.Parse(row["total"].ToString());
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
            strSql.Append("select OrderID,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime,TotalNum,total ");
            strSql.Append(" FROM v_Order ");
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
            strSql.Append(" OrderID,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime,TotalNum,total ");
            strSql.Append(" FROM v_Order ");
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
            strSql.Append("select count(1) FROM v_Order ");
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
                strSql.Append("order by T.OrderID desc");
            }
            strSql.Append(")AS Row, T.*  from v_Order T ");
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
			parameters[0].Value = "v_Order";
			parameters[1].Value = "OrderID";
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

