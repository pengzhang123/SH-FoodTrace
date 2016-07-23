using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;

namespace FoodTrace.IService
{
    /// <summary>
    ///养殖区域管理
    /// </summary>
    public interface IBreedAreaService
    {
        /// <summary>
        /// 获取BreedArea总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedAreaCount();

        /// <summary>
        /// 获取BreedArea总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedAreaCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedAreaModel> GetPagerBreedArea(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedArea
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedAreaModel GetBreedAreaById(int id);

        /// <summary>
        /// 新增单条BreedArea
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedArea(BreedAreaModel model);

        /// <summary>
        /// 编辑单条BreedArea
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedArea(BreedAreaModel model);

        /// <summary>
        /// 删除单条BreedArea
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
