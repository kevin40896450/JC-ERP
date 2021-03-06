﻿using System;
using System.Data;
using System.Collections.Generic;
using DataService.Model;
namespace DataService.BLL
{
    /// <summary>
    /// v_Order
    /// </summary>
    public partial class v_Order
    {
        private readonly DataService.DAL.v_Order dal = new DataService.DAL.v_Order();
        public v_Order()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.v_Order GetModel(int OrderID)
        {

            return dal.GetModel(OrderID);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataService.Model.v_Order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataService.Model.v_Order> DataTableToList(DataTable dt)
        {
            List<DataService.Model.v_Order> modelList = new List<DataService.Model.v_Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DataService.Model.v_Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

