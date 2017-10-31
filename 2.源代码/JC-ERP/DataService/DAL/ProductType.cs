﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:ProductType
    /// </summary>
    public partial class ProductType
    {
        public ProductType()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProTypeID", "ProductType");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ProTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductType");
            strSql.Append(" where ProTypeID=@ProTypeID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4)         };
            parameters[0].Value = ProTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.ProductType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductType(");
            strSql.Append("ProTypeID,TypeName,ProName,ProGroupID,OrderNum)");
            strSql.Append(" values (");
            strSql.Append("@ProTypeID,@TypeName,@ProName,@ProGroupID,@OrderNum)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4),
                    new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
                    new SqlParameter("@ProName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProGroupID", SqlDbType.Int,4),
                    new SqlParameter("@OrderNum", SqlDbType.Int,4)};
            parameters[0].Value = model.ProTypeID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.ProName;
            parameters[3].Value = model.ProGroupID;
            parameters[4].Value = model.OrderNum;

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
        public bool Update(DataService.Model.ProductType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductType set ");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("ProName=@ProName,");
            strSql.Append("ProGroupID=@ProGroupID,");
            strSql.Append("OrderNum=@OrderNum");
            strSql.Append(" where ProTypeID=@ProTypeID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TypeName", SqlDbType.NVarChar,20),
                    new SqlParameter("@ProName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProGroupID", SqlDbType.Int,4),
                    new SqlParameter("@OrderNum", SqlDbType.Int,4),
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.ProName;
            parameters[2].Value = model.ProGroupID;
            parameters[3].Value = model.OrderNum;
            parameters[4].Value = model.ProTypeID;

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
        public bool Delete(int ProTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductType ");
            strSql.Append(" where ProTypeID=@ProTypeID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4)         };
            parameters[0].Value = ProTypeID;

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
        public bool DeleteList(string ProTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductType ");
            strSql.Append(" where ProTypeID in (" + ProTypeIDlist + ")  ");
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
        public DataService.Model.ProductType GetModel(int ProTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProTypeID,TypeName,ProName,ProGroupID,OrderNum from ProductType ");
            strSql.Append(" where ProTypeID=@ProTypeID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProTypeID", SqlDbType.Int,4)         };
            parameters[0].Value = ProTypeID;

            DataService.Model.ProductType model = new DataService.Model.ProductType();
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
        public DataService.Model.ProductType DataRowToModel(DataRow row)
        {
            DataService.Model.ProductType model = new DataService.Model.ProductType();
            if (row != null)
            {
                if (row["ProTypeID"] != null && row["ProTypeID"].ToString() != "")
                {
                    model.ProTypeID = int.Parse(row["ProTypeID"].ToString());
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["ProName"] != null)
                {
                    model.ProName = row["ProName"].ToString();
                }
                if (row["ProGroupID"] != null && row["ProGroupID"].ToString() != "")
                {
                    model.ProGroupID = int.Parse(row["ProGroupID"].ToString());
                }
                if (row["OrderNum"] != null && row["OrderNum"].ToString() != "")
                {
                    model.OrderNum = int.Parse(row["OrderNum"].ToString());
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
            strSql.Append("select ProTypeID,TypeName,ProName,ProGroupID,OrderNum ");
            strSql.Append(" FROM ProductType ");
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
            strSql.Append(" ProTypeID,TypeName,ProName,ProGroupID,OrderNum ");
            strSql.Append(" FROM ProductType ");
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
            strSql.Append("select count(1) FROM ProductType ");
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
                strSql.Append("order by T.ProTypeID desc");
            }
            strSql.Append(")AS Row, T.*  from ProductType T ");
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
			parameters[0].Value = "ProductType";
			parameters[1].Value = "ProTypeID";
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

