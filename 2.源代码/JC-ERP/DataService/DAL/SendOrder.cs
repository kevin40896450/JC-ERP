using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:SendOrder
    /// </summary>
    public partial class SendOrder
    {
        public SendOrder()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SendOrderID", "SendOrder");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SendOrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SendOrder");
            strSql.Append(" where SendOrderID=@SendOrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SendOrderID", SqlDbType.Int,4)           };
            parameters[0].Value = SendOrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.SendOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SendOrder(");
            strSql.Append("SendOrderID,OrderDetailID,GroupID,BuildAddr,SendType,SendArea,RealArea,Price,RealPrice,Remark,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@SendOrderID,@OrderDetailID,@GroupID,@BuildAddr,@SendType,@SendArea,@RealArea,@Price,@RealPrice,@Remark,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@SendOrderID", SqlDbType.Int,4),
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4),
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
                    new SqlParameter("@BuildAddr", SqlDbType.VarChar,200),
                    new SqlParameter("@SendType", SqlDbType.Int,4),
                    new SqlParameter("@SendArea", SqlDbType.Decimal,9),
                    new SqlParameter("@RealArea", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Real,4),
                    new SqlParameter("@RealPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.SendOrderID;
            parameters[1].Value = model.OrderDetailID;
            parameters[2].Value = model.GroupID;
            parameters[3].Value = model.BuildAddr;
            parameters[4].Value = model.SendType;
            parameters[5].Value = model.SendArea;
            parameters[6].Value = model.RealArea;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.RealPrice;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.AddTime;

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
        public bool Update(DataService.Model.SendOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SendOrder set ");
            strSql.Append("OrderDetailID=@OrderDetailID,");
            strSql.Append("GroupID=@GroupID,");
            strSql.Append("BuildAddr=@BuildAddr,");
            strSql.Append("SendType=@SendType,");
            strSql.Append("SendArea=@SendArea,");
            strSql.Append("RealArea=@RealArea,");
            strSql.Append("Price=@Price,");
            strSql.Append("RealPrice=@RealPrice,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where SendOrderID=@SendOrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderDetailID", SqlDbType.Int,4),
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
                    new SqlParameter("@BuildAddr", SqlDbType.VarChar,200),
                    new SqlParameter("@SendType", SqlDbType.Int,4),
                    new SqlParameter("@SendArea", SqlDbType.Decimal,9),
                    new SqlParameter("@RealArea", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Real,4),
                    new SqlParameter("@RealPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@SendOrderID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderDetailID;
            parameters[1].Value = model.GroupID;
            parameters[2].Value = model.BuildAddr;
            parameters[3].Value = model.SendType;
            parameters[4].Value = model.SendArea;
            parameters[5].Value = model.RealArea;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.RealPrice;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.SendOrderID;

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
        public bool Delete(int SendOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SendOrder ");
            strSql.Append(" where SendOrderID=@SendOrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SendOrderID", SqlDbType.Int,4)           };
            parameters[0].Value = SendOrderID;

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
        public bool DeleteList(string SendOrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SendOrder ");
            strSql.Append(" where SendOrderID in (" + SendOrderIDlist + ")  ");
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
        public DataService.Model.SendOrder GetModel(int SendOrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SendOrderID,OrderDetailID,GroupID,BuildAddr,SendType,SendArea,RealArea,Price,RealPrice,Remark,AddTime from SendOrder ");
            strSql.Append(" where SendOrderID=@SendOrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SendOrderID", SqlDbType.Int,4)           };
            parameters[0].Value = SendOrderID;

            DataService.Model.SendOrder model = new DataService.Model.SendOrder();
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
        public DataService.Model.SendOrder DataRowToModel(DataRow row)
        {
            DataService.Model.SendOrder model = new DataService.Model.SendOrder();
            if (row != null)
            {
                if (row["SendOrderID"] != null && row["SendOrderID"].ToString() != "")
                {
                    model.SendOrderID = int.Parse(row["SendOrderID"].ToString());
                }
                if (row["OrderDetailID"] != null && row["OrderDetailID"].ToString() != "")
                {
                    model.OrderDetailID = int.Parse(row["OrderDetailID"].ToString());
                }
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = int.Parse(row["GroupID"].ToString());
                }
                if (row["BuildAddr"] != null)
                {
                    model.BuildAddr = row["BuildAddr"].ToString();
                }
                if (row["SendType"] != null && row["SendType"].ToString() != "")
                {
                    model.SendType = int.Parse(row["SendType"].ToString());
                }
                if (row["SendArea"] != null && row["SendArea"].ToString() != "")
                {
                    model.SendArea = decimal.Parse(row["SendArea"].ToString());
                }
                if (row["RealArea"] != null && row["RealArea"].ToString() != "")
                {
                    model.RealArea = decimal.Parse(row["RealArea"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["RealPrice"] != null && row["RealPrice"].ToString() != "")
                {
                    model.RealPrice = decimal.Parse(row["RealPrice"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select SendOrderID,OrderDetailID,GroupID,BuildAddr,SendType,SendArea,RealArea,Price,RealPrice,Remark,AddTime ");
            strSql.Append(" FROM SendOrder ");
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
            strSql.Append(" SendOrderID,OrderDetailID,GroupID,BuildAddr,SendType,SendArea,RealArea,Price,RealPrice,Remark,AddTime ");
            strSql.Append(" FROM SendOrder ");
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
            strSql.Append("select count(1) FROM SendOrder ");
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
                strSql.Append("order by T.SendOrderID desc");
            }
            strSql.Append(")AS Row, T.*  from SendOrder T ");
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
			parameters[0].Value = "SendOrder";
			parameters[1].Value = "SendOrderID";
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

