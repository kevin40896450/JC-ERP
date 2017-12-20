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
                SendOrder send = CovertSendOrder(dto);
                send.GroupID = groupID;
                send.SendOrderID = id;
                send.AddTime = thisTime;
                models.Add(BSend.CreateAddSql(send));
                id++;
            }
            DataService.DbHelperSQL.ExecuteSqlTran(models);
        }

        private SendOrder CovertSendOrder(SendOrderAddDTO model)
        {
            SendOrder send = new SendOrder();
            send.OrderDetailID = model.OrderDetailID;
            send.SendArea = (decimal)model.SendNum;
            return send;
        }
    }
}
