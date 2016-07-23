using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IAreaService
    {
        /// <summary>
        /// 获取Area总条数
        /// </summary>
        /// <returns></returns>
        int GetAreaCount();

        /// <summary>
        /// 获取Area总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        int GetAreaCount(string name);

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：区域名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<AreaModel> GetPagerArea(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Area
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AreaModel GetAreaById(int id);

        /// <summary>
        /// 新增单条Area
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleArea(AreaModel model);

        /// <summary>
        /// 编辑单条Area
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleArea(AreaModel model);

        /// <summary>
        /// 删除单条Area
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleArea(int id);
    }
}
