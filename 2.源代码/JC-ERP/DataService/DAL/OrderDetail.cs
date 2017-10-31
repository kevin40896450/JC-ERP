using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:OrderDetail
    /// </summary>
    public partial class OrderDetail
    {
        public OrderDetail()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("OrderDetailID", "OrderDetail");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrderDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrderDetail");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4)         };
            parameters[0].Value = OrderDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderDetail(");
            strSql.Append("OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderDetailID,@OrderID,@ProTypeID,@Spec,@PlanNum,@Price,@total,@Remark,@FinishNum,@OrderStatus,@UpTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4),
                    new SqlParameter("@OrderID", SqlDbType.Int,4),
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4),
                    new SqlParameter("@Spec", SqlDbType.NVarChar,100),
                    new SqlParameter("@PlanNum", SqlDbType.Float,8),
                    new SqlParameter("@Price", SqlDbType.Float,8),
                    new SqlParameter("@total", SqlDbType.Float,8),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@FinishNum", SqlDbType.Float,8),
                    new SqlParameter("@OrderStatus", SqlDbType.Int,4),
                    new SqlParameter("@UpTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderDetailID;
            parameters[1].Value = model.OrderID;
            parameters[2].Value = model.ProTypeID;
            parameters[3].Value = model.Spec;
            parameters[4].Value = model.PlanNum;
            parameters[5].Value = model.Price;
            parameters[6].Value = model.total;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.FinishNum;
            parameters[9].Value = model.OrderStatus;
            parameters[10].Value = model.UpTime;

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
        public bool Update(DataService.Model.OrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderDetail set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("ProTypeID=@ProTypeID,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("PlanNum=@PlanNum,");
            strSql.Append("Price=@Price,");
            strSql.Append("total=@total,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("FinishNum=@FinishNum,");
            strSql.Append("OrderStatus=@OrderStatus,");
            strSql.Append("UpTime=@UpTime");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4),
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4),
                    new SqlParameter("@Spec", SqlDbType.NVarChar,100),
                    new SqlParameter("@PlanNum", SqlDbType.Float,8),
                    new SqlParameter("@Price", SqlDbType.Float,8),
                    new SqlParameter("@total", SqlDbType.Float,8),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@FinishNum", SqlDbType.Float,8),
                    new SqlParameter("@OrderStatus", SqlDbType.Int,4),
                    new SqlParameter("@UpTime", SqlDbType.DateTime),
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ProTypeID;
            parameters[2].Value = model.Spec;
            parameters[3].Value = model.PlanNum;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.total;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.FinishNum;
            parameters[8].Value = model.OrderStatus;
            parameters[9].Value = model.UpTime;
            parameters[10].Value = model.OrderDetailID;

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
        public bool Delete(int OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderDetail ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4)         };
            parameters[0].Value = OrderDetailID;

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
        public bool DeleteList(string OrderDetailIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderDetail ");
            strSql.Append(" where OrderDetailID in (" + OrderDetailIDlist + ")  ");
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
        public DataService.Model.OrderDetail GetModel(int OrderDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime from OrderDetail ");
            strSql.Append(" where OrderDetailID=@OrderDetailID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4)         };
            parameters[0].Value = OrderDetailID;

            DataService.Model.OrderDetail model = new DataService.Model.OrderDetail();
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
        public DataService.Model.OrderDetail DataRowToModel(DataRow row)
        {
            DataService.Model.OrderDetail model = new DataService.Model.OrderDetail();
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
                    model.PlanNum = float.Parse(row["PlanNum"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = float.Parse(row["Price"].ToString());
                }
                if (row["total"] != null && row["total"].ToString() != "")
                {
                    model.total = float.Parse(row["total"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["FinishNum"] != null && row["FinishNum"].ToString() != "")
                {
                    model.FinishNum = float.Parse(row["FinishNum"].ToString());
                }
                if (row["OrderStatus"] != null && row["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = int.Parse(row["OrderStatus"].ToString());
                }
                if (row["UpTime"] != null && row["UpTime"].ToString() != "")
                {
                    model.UpTime = DateTime.Parse(row["UpTime"].ToString());
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
            strSql.Append("select OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime ");
            strSql.Append(" FROM OrderDetail ");
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
            strSql.Append(" OrderDetailID,OrderID,ProTypeID,Spec,PlanNum,Price,total,Remark,FinishNum,OrderStatus,UpTime ");
            strSql.Append(" FROM OrderDetail ");
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
            strSql.Append("select count(1) FROM OrderDetail ");
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
            strSql.Append(")AS Row, T.*  from OrderDetail T ");
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
			parameters[0].Value = "OrderDetail";
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

