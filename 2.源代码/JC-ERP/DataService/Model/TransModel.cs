using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    /// <summary>
    /// 数据库事务Model
    /// </summary>
    public class TransModel
    {
        public string Sql { get; set; }

        public SqlParameter[] parameters { get; set; }
    }
}
