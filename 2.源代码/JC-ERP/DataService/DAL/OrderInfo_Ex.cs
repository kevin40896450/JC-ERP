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
    /// 数据访问类:OrderInfo
    /// </summary>
    public partial class OrderInfo
    {
        public TransModel CreateAddSql(DataService.Model.OrderInfo model)
        {
            TransModel tm = new TransModel();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderInfo(");
            strSql.Append("OrderID,OrderCode,UserID,Use_UserID,Buyer,ProName,Province,City,Area,Address,remarks1,remarks2,IntoDate,OrderDate,IsCheck,IsDel,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@OrderCode,@UserID,@Use_UserID,@Buyer,@ProName,@Province,@City,@Area,@Address,@remarks1,@remarks2,@IntoDate,@OrderDate,@IsCheck,@IsDel,@AddTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int,4),
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
            tm.Sql = strSql.ToString();
            tm.parameters = parameters;
            return tm;
        }
    }
}
