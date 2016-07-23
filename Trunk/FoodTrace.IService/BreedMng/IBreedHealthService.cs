using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖健康管理
    /// </summary>
    public interface IBreedHealthService
    {
        /// <summary>
        /// 获取BreedHealth总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHealthCount();

        /// <summary>
        /// 获取BreedHealth总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHealthCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖健康信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedHealthModel> GetPagerBreedHealth(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedHealth
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedHealthModel GetBreedHealthById(int id);

        /// <summary>
        /// 新增单条BreedHealth
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedHealth(BreedHealthModel model);

        /// <summary>
        /// 编辑单条BreedHealth
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedHealth(BreedHealthModel model);

        /// <summary>
        /// 删除单条BreedHealth
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
