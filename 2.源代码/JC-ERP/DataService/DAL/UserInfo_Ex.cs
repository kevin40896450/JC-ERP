using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.DAL
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfo
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.UserInfo GetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,RoleID,UserGuid,UserName,Pwd,RealName,Sex,IDCard,Tel,Status,IntoTime,AddTime from UserInfo ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50) };
            parameters[0].Value = UserName;

            DataService.Model.UserInfo model = new DataService.Model.UserInfo();
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
    }
}
