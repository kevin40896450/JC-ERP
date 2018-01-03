using System;
using System.Data;
using System.Collections.Generic;
using DataService.Model;
namespace DataService.BLL
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class Role
    {
        private readonly DataService.DAL.Role dal = new DataService.DAL.Role();
        public Role()
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
        public bool Exists(int RoleID)
        {
            return dal.Exists(RoleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DataService.Model.Role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleID)
        {

            return dal.Delete(RoleID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RoleIDlist)
        {
            return dal.DeleteList(RoleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.Role GetModel(int RoleID)
        {

            return dal.GetModel(RoleID);
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
        public List<DataService.Model.Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataService.Model.Role> DataTableToList(DataTable dt)
        {
            List<DataService.Model.Role> modelList = new List<DataService.Model.Role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DataService.Model.Role model;
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

