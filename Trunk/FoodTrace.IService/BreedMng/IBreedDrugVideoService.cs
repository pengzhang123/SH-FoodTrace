using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 防疫视频信息
    /// </summary>
    public interface IBreedDrugVideoService
    {
        /// <summary>
        /// 获取BreedDrugVideo总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedDrugVideoCount();

        /// <summary>
        /// 获取BreedDrugVideo总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedDrugVideoCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的防疫视频信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedDrugVideoModel> GetPagerBreedDrugVideo(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedDrugVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedDrugVideoModel GetBreedDrugVideoById(int id);

        /// <summary>
        /// 新增单条BreedDrugVideo
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedDrugVideo(BreedDrugVideoModel model);

        /// <summary>
        /// 编辑单条BreedDrugVideo
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedDrugVideo(BreedDrugVideoModel model);

        /// <summary>
        /// 删除单条BreedDrugVideo
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}

