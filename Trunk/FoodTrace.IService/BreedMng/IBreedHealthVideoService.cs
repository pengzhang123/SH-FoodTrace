using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖健康视频信息
    /// </summary>
    public interface IBreedHealthVideoService
    {
        /// <summary>
        /// 获取BreedHealthVideo总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHealthVideoCount();

        /// <summary>
        /// 获取BreedHealthVideo总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHealthVideoCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖健康视频信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedHealthVideoModel> GetPagerBreedHealthVideo(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedHealthVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedHealthVideoModel GetBreedHealthVideoById(int id);

        /// <summary>
        /// 新增单条BreedHealthVideo
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedHealthVideo(BreedHealthVideoModel model);

        /// <summary>
        /// 编辑单条BreedHealthVideo
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedHealthVideo(BreedHealthVideoModel model);

        /// <summary>
        /// 删除单条BreedHealthVideo
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
