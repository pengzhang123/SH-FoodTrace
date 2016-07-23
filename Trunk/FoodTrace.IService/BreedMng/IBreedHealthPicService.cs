using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖健康图片信息
    /// </summary>
    public interface IBreedHealthPicService
    {
        /// <summary>
        /// 获取BreedHealthPic总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHealthPicCount();

        /// <summary>
        /// 获取BreedHealthPic总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedHealthPicCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖健康图片信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedHealthPicModel> GetPagerBreedHealthPic(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedHealthPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedHealthPicModel GetBreedHealthPicById(int id);

        /// <summary>
        /// 新增单条BreedHealthPic
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedHealthPic(BreedHealthPicModel model);

        /// <summary>
        /// 编辑单条BreedHealthPic
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedHealthPic(BreedHealthPicModel model);

        /// <summary>
        /// 删除单条BreedHealthPic
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}

