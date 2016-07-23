using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 圈舍管理
    /// </summary>
    public interface IBreedHomeService
    {
        /// <summary>
        /// 获取BreedHome总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHomeCount();

        /// <summary>
        /// 获取BreedHome总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHomeCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖健康视频信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedHomeModel> GetPagerBreedHome(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedHome
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedHomeModel GetBreedHomeById(int id);

        /// <summary>
        /// 新增单条BreedHome
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedHome(BreedHomeModel model);

        /// <summary>
        /// 编辑单条BreedHome
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedHome(BreedHomeModel model);

        /// <summary>
        /// 删除单条BreedHome
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
