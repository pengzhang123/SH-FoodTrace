using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 养殖用料管理
    /// </summary>
    public interface IBreedMaterialService
    {
        /// <summary>
        /// 获取BreedMaterial总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedMaterialCount();

        /// <summary>
        /// 获取BreedMaterial总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedMaterialCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的养殖用料信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedMaterialModel> GetPagerBreedMaterial(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedMaterial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedMaterialModel GetBreedMaterialById(int id);

        /// <summary>
        /// 新增单条BreedMaterial
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedMaterial(BreedMaterialModel model);

        /// <summary>
        /// 编辑单条BreedMaterial
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedMaterial(BreedMaterialModel model);

        /// <summary>
        /// 删除单条BreedMaterial
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}

