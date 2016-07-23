using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖用料视频管理
    /// </summary>
    public interface IBreedMaterialVideoService
    {
        /// <summary>
        /// 获取BreedMaterialVideo总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedMaterialVideoCount();

        /// <summary>
        /// 获取BreedMaterialVideo总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedMaterialVideoCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖用料视频信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedMaterialVideoModel> GetPagerBreedMaterialVideo(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedMaterialVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedMaterialVideoModel GetBreedMaterialVideoById(int id);

        /// <summary>
        /// 新增单条BreedMaterialVideo
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedMaterialVideo(BreedMaterialVideoModel model);

        /// <summary>
        /// 编辑单条BreedMaterialVideo
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedMaterialVideo(BreedMaterialVideoModel model);

        /// <summary>
        /// 删除单条BreedMaterialVideo
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
