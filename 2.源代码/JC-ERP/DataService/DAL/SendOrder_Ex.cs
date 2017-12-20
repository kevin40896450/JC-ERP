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
    public partial class SendOrder
    {
        public TransModel CreateAddSql(DataService.Model.SendOrder model)
        {
            TransModel tm = new TransModel();
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
            tm.Sql = strSql.ToString();
            tm.parameters = parameters;
            return tm;
        }
    }
}
