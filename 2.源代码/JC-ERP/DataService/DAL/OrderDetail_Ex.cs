using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;

namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:OrderDetail
    /// </summary>
    public partial class OrderDetail
    {
        public TransModel CreateAddSql(DataService.Model.OrderDetail model)
        {
            TransModel tm = new TransModel();
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

            tm.Sql = strSql.ToString();
            tm.parameters = parameters;
            return tm;
        }
    }
}
