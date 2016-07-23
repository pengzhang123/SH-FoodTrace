using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖用料图片管理
    /// </summary>
    public interface IBreedMaterialPicService
    {
        /// <summary>
        /// 获取BreedMaterialPic总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedMaterialPicCount();

        /// <summary>
        /// 获取BreedMaterialPic总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedMaterialPicCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖用料图片信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedMaterialPicModel> GetPagerBreedMaterialPic(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedMaterialPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedMaterialPicModel GetBreedMaterialPicById(int id);

        /// <summary>
        /// 新增单条BreedMaterialPic
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedMaterialPic(BreedMaterialPicModel model);

        /// <summary>
        /// 编辑单条BreedMaterialPic
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedMaterialPic(BreedMaterialPicModel model);

        /// <summary>
        /// 删除单条BreedMaterialPic
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}
