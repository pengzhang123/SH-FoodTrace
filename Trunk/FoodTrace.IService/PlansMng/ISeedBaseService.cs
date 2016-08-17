using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IService
{
    /// <summary>
    /// 种子管理
    /// </summary>
    public interface ISeedBaseService
    {
        /// <summary>
        /// 获取SeedBase总条数
        /// </summary>
        /// <returns></returns>
        int GetSeedBaseCount();

        /// <summary>
        /// 获取种子信息（分页）
        /// </summary>
        /// <param name="name">查询条件：种子名称（模糊查询）</param>
        /// <returns></returns>
        int GetSeedBaseCount(string name);

        /// <summary>
        /// 获取种子信息（分页）
        /// </summary>
        /// <param name="name">查询条件：种子名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<SeedBaseModel> GetPagerSeedBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取SeedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         SeedBaseModel GetSeedBaseById(int id);

        /// <summary>
        /// 新增单条SeedBase
        /// </summary>
        /// <param name="model">种子信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleSeedBase(SeedBaseModel model);

        /// <summary>
        /// 编辑单条SeedBase
        /// </summary>
        /// <param name="model">种子信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleSeedBase(SeedBaseModel model);

        /// <summary>
        /// 删除单条SeedBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
         MessageModel DeleteSingleSeedBase(int id);

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<SeedDto> GetSeedPagingList(string name, int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 获取种植信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SeedDto GetSeedDtoById(int id);
    }
}
