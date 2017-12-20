using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;
using JC.Domain.DTO;

namespace JC.Domain.Respository
{
    public class GroupSource
    {
        DataService.BLL.UserGroup BGroup = new DataService.BLL.UserGroup();

        DataService.BLL.UserInfo BUser = new DataService.BLL.UserInfo();

        public Summary<GroupInfoDto> GetPageGroups(string strWhere, string orderby, int startIndex, int endIndex)
        {
            var summary = new Summary<GroupInfoDto>();
            List<GroupInfoDto> grouplist = new List<GroupInfoDto>();
            List<UserGroup> list = BGroup.GetModelsByPage(strWhere, orderby, startIndex, endIndex);
            List<UserInfo> userList = BUser.GetModelList("");
            GroupInfoDto dto = null;
            foreach (UserGroup group in list)
            {
                dto = new GroupInfoDto();
                dto.AddTime = group.AddTime;
                dto.GroupID = group.GroupID;
                dto.GroupName = group.GroupName;
                dto.UserID = group.UserID;
                dto.UserIds = group.Users;
                List<UserInfo> users = userList.Where(m => group.Users.Contains(m.UserID.ToString())).ToList();
                foreach(UserInfo info in users)
                {
                    dto.Users += info.RealName + ",";
                }
                dto.Users = dto.Users.TrimEnd(',');
                grouplist.Add(dto);
            }
            summary.rows = grouplist;
            summary.total = BGroup.GetRecordCount(strWhere);
            return summary;
        }

        public Summary<GroupInfoDto> GetPageGroups(string strWhere, string orderby)
        {
            var summary = new Summary<GroupInfoDto>();
            List<GroupInfoDto> grouplist = new List<GroupInfoDto>();
            List<UserGroup> list = BGroup.GetModelList(strWhere + " order by " + orderby);
            List<UserInfo> userList = BUser.GetModelList("");
            GroupInfoDto dto = null;
            foreach (UserGroup group in list)
            {
                dto = new GroupInfoDto();
                dto.AddTime = group.AddTime;
                dto.GroupID = group.GroupID;
                dto.GroupName = group.GroupName;
                dto.UserID = group.UserID;
                dto.UserIds = group.Users;
                List<UserInfo> users = userList.Where(m => group.Users.Contains(m.UserID.ToString())).ToList();
                foreach (UserInfo info in users)
                {
                    dto.Users += info.RealName + ",";
                }
                dto.Users = dto.Users.TrimEnd(',');
                grouplist.Add(dto);
            }
            summary.rows = grouplist;
            return summary;
        }

        public bool AddGroup(UserGroup model)
        {
            model.GroupID = BGroup.GetMaxId();
            model.AddTime = DateTime.Now;
            bool IsResult = BGroup.Add(model);
            return IsResult;
        }
    }
}
