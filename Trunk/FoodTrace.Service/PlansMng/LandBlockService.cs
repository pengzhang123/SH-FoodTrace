using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 种植企业基地地块管理
    /// </summary>
    public class LandBlockService : BaseService, ILandBlockService
    {
        private ILandBlockAccess landBlockAccess;
        private ILandBaseAccess landBaseAccess;

        public LandBlockService()
        {
            landBlockAccess = BaseAccess.CreateAccess<ILandBlockAccess>(AccessMappingKey.LandBlockAccess.ToString());
            landBaseAccess = BaseAccess.CreateAccess<ILandBaseAccess>(AccessMappingKey.LandBaseAccess.ToString());
        }

        /// <summary>
        /// 获取LandBlock总条数
        /// </summary>
        /// <returns></returns>
        public int GetLandBlockCount()
        {
            return landBlockAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取LandBlock总条数
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <returns></returns>
        public int GetLandBlockCount(string name)
        {
            int companyID = UserManagement.CurrentCompany.CompanyID;
            return landBlockAccess.GetEntityCount(companyID, name.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的地块信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<LandBlockModel> GetPagerLandBlock(string name, int pageIndex, int pageSize)
        {
            //var test = landBlockAccess.GetAllEntities();
            int companyID = UserManagement.CurrentCompany.CompanyID;
            var result = landBlockAccess.GetPagerLandBlockByConditions(companyID, name.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetLandBase(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取LandBlock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LandBlockModel GetLandBlockById(int id)
        {
            return landBlockAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条LandBlock
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleLandBlock(LandBlockModel model)
        {
            return landBlockAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条LandBlock
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleLandBlock(LandBlockModel model)
        {
            return landBlockAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条LandBlock
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleLandBlock(int id)
        {
            return landBlockAccess.DeleteSingleEntity(id);
        }


        //private void SetLandBase(LandBlockModel model)
        //{
        //    if (model.LandID.HasValue)
        //    {
        //        model.LandBase = landBaseAccess.GetEntityById(model.LandID.Value);
        //    }
        //}
    }
}
