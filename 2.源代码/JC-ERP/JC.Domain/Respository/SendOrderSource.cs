using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Model;
using JC.Domain.DTO;

namespace JC.Domain.Respository
{
    public class SendOrderSource
    {
        DataService.BLL.SendOrder BSend = new DataService.BLL.SendOrder();

        public void AddSendOrder(int groupID,List<SendOrderAddDTO> list)
        {
            List<TransModel> models = new List<TransModel>();
            DateTime thisTime = DateTime.Now;
            int id = BSend.GetMaxId();
            foreach(SendOrderAddDTO dto in list)
            {
                SendOrder send = new SendOrder();
                send.GroupID = groupID;
                send.SendOrderID = id;
                send.OrderDetailID = dto.OrderDetailID;
                send.BuildAddr = "";
                send.Price = 0;
                send.RealArea = 0;
                send.RealPrice = 0;
                send.Remark = "";
                send.SendType = 0;
                send.SendArea = dto.SendNum;
                send.AddTime = thisTime;
                models.Add(BSend.CreateAddSql(send));
                id++;
            }
            DataService.DbHelperSQL.ExecuteSqlTran(models);
        }
    }
}
