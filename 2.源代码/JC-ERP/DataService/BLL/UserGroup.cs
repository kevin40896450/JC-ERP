﻿using System;
using System.Data;
using System.Collections.Generic;
using DataService.Model;
namespace DataService.BLL
{
    /// <summary>
    /// 用户组
    /// </summary>
    public partial class UserGroup
    {
        private readonly DataService.DAL.UserGroup dal = new DataService.DAL.UserGroup();
        public UserGroup()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GroupID)
        {
            return dal.Exists(GroupID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.UserGroup model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DataService.Model.UserGroup model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int GroupID)
        {

            return dal.Delete(GroupID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string GroupIDlist)
        {
            return dal.DeleteList(GroupIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.UserGroup GetModel(int GroupID)
        {

            return dal.GetModel(GroupID);
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
        public List<DataService.Model.UserGroup> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataService.Model.UserGroup> DataTableToList(DataTable dt)
        {
            List<DataService.Model.UserGroup> modelList = new List<DataService.Model.UserGroup>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DataService.Model.UserGroup model;
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

