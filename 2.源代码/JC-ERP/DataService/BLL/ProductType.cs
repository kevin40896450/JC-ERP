using System;
using System.Data;
using System.Collections.Generic;
using DataService.Model;
namespace DataService.BLL
{
    /// <summary>
    /// 产品类型
    /// </summary>
    public partial class ProductType
    {
        private readonly DataService.DAL.ProductType dal = new DataService.DAL.ProductType();
        public ProductType()
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
        public bool Exists(int ProTypeID)
        {
            return dal.Exists(ProTypeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DataService.Model.ProductType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DataService.Model.ProductType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProTypeID)
        {

            return dal.Delete(ProTypeID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ProTypeIDlist)
        {
            return dal.DeleteList(ProTypeIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataService.Model.ProductType GetModel(int ProTypeID)
        {

            return dal.GetModel(ProTypeID);
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
        public List<DataService.Model.ProductType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DataService.Model.ProductType> DataTableToList(DataTable dt)
        {
            List<DataService.Model.ProductType> modelList = new List<DataService.Model.ProductType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DataService.Model.ProductType model;
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

