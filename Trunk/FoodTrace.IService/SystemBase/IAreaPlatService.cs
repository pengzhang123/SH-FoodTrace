using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IAreaPlatService
    {
        /// <summary>
        /// 获取AreaPlat总条数
        /// </summary>
        /// <returns></returns>
        int GetAreaPlatCount();

        /// <summary>
        /// 获取AreaPlat总条数
        /// </summary>
        /// <param name="name">查询条件：平台代码（模糊查询）</param>
        /// <returns></returns>
        int GetAreaPlatCount(string name);

        /// <summary>
        /// 获取城市信息（分页）
        /// </summary>
        /// <param name="name">查询条件：平台代码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<AreaPlatModel> GetPagerAreaPlat( string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取AreaPlat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AreaPlatModel GetAreaPlatById(int id);

        /// <summary>
        /// 新增单条AreaPlat
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleAreaPlat(AreaPlatModel model);

        /// <summary>
        /// 编辑单条AreaPlat
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleAreaPlat(AreaPlatModel model);

        /// <summary>
        /// 删除单条AreaPlat
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleAreaPlat(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteAreaPlatByIds(string ids);
    }
}
