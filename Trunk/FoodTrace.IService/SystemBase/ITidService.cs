using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ITidService
    {
        /// <summary>
        /// 获取Area总条数
        /// </summary>
        /// <returns></returns>
        int GetTidCount();

        /// <summary>
        /// 获取Area总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        int GetTidCount(string name);

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：区域名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<TIDModel> GetPagerTid(int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取Area
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TIDModel GetTidById(int id);
        TIDModel GetTidByChipCode(string code);
        /// <summary>
        /// 新增单条Area
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleTid(TIDModel model);

        /// <summary>
        /// 编辑单条Area
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleTid(TIDModel model);

        /// <summary>
        /// 删除单条Area
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleTid(int id);
    }
}
