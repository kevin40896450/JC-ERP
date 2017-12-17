using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:OrderInfo
    /// </summary>
    public partial class OrderInfo
    {
        public OrderInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("OrderID", "OrderInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrderInfo");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4)           };
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderInfo(");
            strSql.Append("OrderID,OrderCode,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@OrderCode,@UserID,@Use_UserID,@Buyer,@ProName,@Province,@City,@Area,@Address,@remarks1,@remarks2,@IntoDate,@OrderDate,@IsCheck,@IsDel,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4),
                    new SqlParameter("@OrderCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@Use_UserID", SqlDbType.Int,4),
                    new SqlParameter("@Buyer", SqlDbType.VarChar,200),
                    new SqlParameter("@ProName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Province", SqlDbType.NVarChar,50),
                    new SqlParameter("@City", SqlDbType.NVarChar,50),
                    new SqlParameter("@Area", SqlDbType.NVarChar,50),
                    new SqlParameter("@Address", SqlDbType.VarChar,200),
                    new SqlParameter("@remarks1", SqlDbType.VarChar,100),
                    new SqlParameter("@remarks2", SqlDbType.VarChar,2000),
                    new SqlParameter("@IntoDate", SqlDbType.DateTime),
                    new SqlParameter("@OrderDate", SqlDbType.DateTime),
                    new SqlParameter("@IsCheck", SqlDbType.Bit,1),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1),
                    new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Use_UserID;
            parameters[4].Value = model.Buyer;
            parameters[5].Value = model.ProName;
            parameters[6].Value = model.Province;
            parameters[7].Value = model.City;
            parameters[8].Value = model.Area;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.remarks1;
            parameters[11].Value = model.remarks2;
            parameters[12].Value = model.IntoDate;
            parameters[13].Value = model.OrderDate;
            parameters[14].Value = model.IsCheck;
            parameters[15].Value = model.IsDel;
            parameters[16].Value = model.AddTime;

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
        public bool Update(DataService.Model.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderInfo set ");
            strSql.Append("OrderCode=@OrderCode,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Use_UserID=@Use_UserID,");
            strSql.Append("Buyer=@Buyer,");
            strSql.Append("ProName=@ProName,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Area=@Area,");
            strSql.Append("Address=@Address,");
            strSql.Append("remarks1=@remarks1,");
            strSql.Append("remarks2=@remarks2,");
            strSql.Append("IntoDate=@IntoDate,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("IsCheck=@IsCheck,");
            strSql.Append("IsDel=@IsDel,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@Use_UserID", SqlDbType.Int,4),
                    new SqlParameter("@Buyer", SqlDbType.VarChar,200),
                    new SqlParameter("@ProName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Province", SqlDbType.NVarChar,50),
                    new SqlParameter("@City", SqlDbType.NVarChar,50),
                    new SqlParameter("@Area", SqlDbType.NVarChar,50),
                    new SqlParameter("@Address", SqlDbType.VarChar,200),
                    new SqlParameter("@remarks1", SqlDbType.VarChar,100),
                    new SqlParameter("@remarks2", SqlDbType.VarChar,2000),
                    new SqlParameter("@IntoDate", SqlDbType.DateTime),
                    new SqlParameter("@OrderDate", SqlDbType.DateTime),
                    new SqlParameter("@IsCheck", SqlDbType.Bit,1),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@OrderID", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Use_UserID;
            parameters[3].Value = model.Buyer;
            parameters[4].Value = model.ProName;
            parameters[5].Value = model.Province;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Area;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.remarks1;
            parameters[10].Value = model.remarks2;
            parameters[11].Value = model.IntoDate;
            parameters[12].Value = model.OrderDate;
            parameters[13].Value = model.IsCheck;
            parameters[14].Value = model.IsDel;
            parameters[15].Value = model.AddTime;
            parameters[16].Value = model.OrderID;

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
        public bool Delete(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderInfo ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4)           };
            parameters[0].Value = OrderID;

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
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderInfo ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ")  ");
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
        public DataService.Model.OrderInfo GetModel(int OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,OrderCode,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime from OrderInfo ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4)           };
            parameters[0].Value = OrderID;

            DataService.Model.OrderInfo model = new DataService.Model.OrderInfo();
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
        public DataService.Model.OrderInfo DataRowToModel(DataRow row)
        {
            DataService.Model.OrderInfo model = new DataService.Model.OrderInfo();
            if (row != null)
            {
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderID,OrderCode,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime ");
            strSql.Append(" FROM OrderInfo ");
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
            strSql.Append(" OrderID,OrderCode,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime ");
            strSql.Append(" FROM OrderInfo ");
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
            strSql.Append("select count(1) FROM OrderInfo ");
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
            strSql.Append(")AS Row, T.*  from OrderInfo T ");
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
			parameters[0].Value = "OrderInfo";
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

