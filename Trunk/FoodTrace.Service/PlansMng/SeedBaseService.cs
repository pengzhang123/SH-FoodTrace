using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service
{
    /// <summary>
    /// 种子管理
    /// </summary>
    public class SeedBaseService : BaseService, ISeedBaseService
    {
        private ISeedBaseAccess seedBaseAccess;

        public SeedBaseService()
        {
            seedBaseAccess = BaseAccess.CreateAccess<ISeedBaseAccess>(AccessMappingKey.SeedBaseAccess.ToString());
        }

        /// <summary>
        /// 获取SeedBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetSeedBaseCount()
        {
            return seedBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取种子信息（分页）
        /// </summary>
        /// <param name="name">查询条件：种子名称（模糊查询）</param>
        /// <returns></returns>
        public int GetSeedBaseCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return seedBaseAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取种子信息（分页）
        /// </summary>
        /// <param name="name">查询条件：种子名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<SeedBaseModel> GetPagerSeedBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return seedBaseAccess.GetPagerSeedBaseByConditions(name.Trim(), pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取SeedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SeedBaseModel GetSeedBaseById(int id)
        {
            return seedBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条SeedBase
        /// </summary>
        /// <param name="model">种子信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleSeedBase(SeedBaseModel model)
        {
            return seedBaseAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条SeedBase
        /// </summary>
        /// <param name="model">种子信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleSeedBase(SeedBaseModel model)
        {
            return seedBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条SeedBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleSeedBase(int id)
        {
            return seedBaseAccess.DeleteSingleEntity(id);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<SeedDto> GetSeedPagingList(string name, int pIndex, int pSize)
        {
            return seedBaseAccess.GetSeedPagingList(name, pIndex, pSize);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return seedBaseAccess.DeleteByIds(ids);
        }


        /// <summary>
        /// 获取种植信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SeedDto GetSeedDtoById(int id)
        {
            return seedBaseAccess.GetSeedDtoById(id);
        }
    }
}
