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
    ///养殖场管理
    /// </summary>
    public interface IBreedBaseService
    {
        /// <summary>
        /// 获取BreedBase总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedBaseCount();

        /// <summary>
        /// 获取BreedBase总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedBaseCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖场信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedBaseModel> GetPagerBreedBase(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedBaseModel GetBreedBaseById(int id);

        /// <summary>
        /// 新增单条BreedBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedBase(BreedBaseModel model);

        /// <summary>
        /// 编辑单条BreedBase
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedBase(BreedBaseModel model);

        /// <summary>
        /// 删除单条BreedBase
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<BreedBaseDto> GetBreedBaseListPaging(string name, int pIndex, int pSize);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedBaseDto GetBreedBaseDtoById(int id);
    }
}
