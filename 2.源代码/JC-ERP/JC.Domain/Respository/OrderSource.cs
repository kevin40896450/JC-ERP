using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JC.Domain.DTO;
using DataService.Model;

namespace JC.Domain.Respository
{
    public class OrderSource
    {
        DataService.BLL.OrderInfo Border = new DataService.BLL.OrderInfo();

        DataService.BLL.OrderDetail BDetail = new DataService.BLL.OrderDetail();

        public void AddOrder(OrderInfoDTO info, List<OrderDetailDTO> details)
        {
            DateTime thisTime = DateTime.Now;
            OrderInfo order = ConvertOrder(info);
            List<TransModel> models = new List<TransModel>();
            order.OrderID = Border.GetMaxId();
            order.AddTime = thisTime;
            models.Add(Border.CreateAddSql(order));
            int detailID = BDetail.GetMaxId();
            foreach (OrderDetailDTO d in details)
            {
                OrderDetail detail = ConvertOrderDetail(d);
                detail.OrderDetailID = detailID;
                detail.OrderID = order.OrderID;
                detail.UpTime = thisTime;
                models.Add(BDetail.CreateAddSql(detail));
                detailID++;
            }
            DataService.DbHelperSQL.ExecuteSqlTran(models);
        }

        private OrderInfo ConvertOrder(OrderInfoDTO info)
        {
            OrderInfo order = new OrderInfo();
            order.Address = info.Address;
            order.AddTime = DateTime.Now;
            order.Area = info.Area;
            order.Buyer = info.Buyer;
            order.City = info.City;
            order.IntoDate = info.IntoDate;
            order.IsCheck = false;
            order.IsDel = false;
            order.OrderDate = info.OrderDate;
            order.ProName = info.ProName;
            order.Province = info.Province;
            order.remarks1 = info.remarks1;
            order.remarks2 = info.remarks2;
            order.UserID = info.UserID;
            order.Use_UserID = info.Use_UserID;
            order.OrderID = Border.GetMaxId();
            return order;
        }

        private OrderDetail ConvertOrderDetail(OrderDetailDTO detail)
        {
            OrderDetail order = new OrderDetail();
            order.FinishNum = 0;
            order.OrderStatus = (int)OrderStatus.UnFinish;
            order.PlanNum = detail.PlanNum; ;
            order.FinishNum = 0;
            order.Price = detail.Price;
            order.ProTypeID = detail.ProTypeID;
            order.Remark = detail.Remark;
            order.Spec = detail.Spec;
            order.total = detail.Total;
            order.UpTime = DateTime.Now;
            return order;
        }
    }

    public enum OrderStatus
    {
        /// <summary>
        /// 未完成
        /// </summary>
        UnFinish = 1,
        /// <summary>
        /// 已完成
        /// </summary>
        Finish = 2,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 3
    }
}
