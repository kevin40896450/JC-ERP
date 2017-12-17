using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    public class GroupInfoDto : IAggregateRoot
    {
        /// <summary>
        /// 组编号
        /// </summary>
        public int GroupID;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? UserID;
        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName;
        /// <summary>
        /// 组员id列表
        /// </summary>
        public string UserIds;
        /// <summary>
        /// 组员列表
        /// </summary>
        public string Users;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime;
    }
}
