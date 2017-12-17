using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:v_OrderDetail
    /// </summary>
    public partial class v_OrderDetail
    {
        public v_OrderDetail()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrderDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_OrderDetail");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4)         };
            parameters[0].Value = OrderDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.v_OrderDetail GetModel(int OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime,TypeName,ProName,SendArea,RealArea from v_OrderDetail ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4)         };
            parameters[0].Value = OrderDetailID;

            DataService.Model.v_OrderDetail model = new DataService.Model.v_OrderDetail();
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
        public DataService.Model.v_OrderDetail DataRowToModel(DataRow row)
        {
            DataService.Model.v_OrderDetail model = new DataService.Model.v_OrderDetail();
            if (row != null)
            {
                if (row["OrderDetailID"] != null && row["OrderDetailID"].ToString() != "")
                {
                    model.OrderDetailID = int.Parse(row["OrderDetailID"].ToString());
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["ProTypeID"] != null && row["ProTypeID"].ToString() != "")
                {
                    model.ProTypeID = int.Parse(row["ProTypeID"].ToString());
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["PlanNum"] != null && row["PlanNum"].ToString() != "")
                {
                    model.PlanNum = decimal.Parse(row["PlanNum"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["total"] != null && row["total"].ToString() != "")
                {
                    model.total = decimal.Parse(row["total"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["FinishNum"] != null && row["FinishNum"].ToString() != "")
                {
                    model.FinishNum = decimal.Parse(row["FinishNum"].ToString());
                }
                if (row["OrderStatus"] != null && row["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = int.Parse(row["OrderStatus"].ToString());
                }
                if (row["UpTime"] != null && row["UpTime"].ToString() != "")
                {
                    model.UpTime = DateTime.Parse(row["UpTime"].ToString());
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["ProName"] != null)
                {
                    model.ProName = row["ProName"].ToString();
                }
                if (row["SendArea"] != null && row["SendArea"].ToString() != "")
                {
                    model.SendArea = decimal.Parse(row["SendArea"].ToString());
                }
                if (row["RealArea"] != null && row["RealArea"].ToString() != "")
                {
                    model.RealArea = decimal.Parse(row["RealArea"].ToString());
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
            strSql.Append("select OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime,TypeName,ProName,SendArea,RealArea ");
            strSql.Append(" FROM v_OrderDetail ");
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
            strSql.Append(" OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime,TypeName,ProName,SendArea,RealArea ");
            strSql.Append(" FROM v_OrderDetail ");
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
            strSql.Append("select count(1) FROM v_OrderDetail ");
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
                strSql.Append("order by T.OrderDetailID desc");
            }
            strSql.Append(")AS Row, T.*  from v_OrderDetail T ");
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
			parameters[0].Value = "v_OrderDetail";
			parameters[1].Value = "OrderDetailID";
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

