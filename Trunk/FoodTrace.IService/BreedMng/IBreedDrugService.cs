using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 防疫信息
    /// </summary>
    public interface IBreedDrugService
    {
        /// <summary>
        /// 获取BreedDrug总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedDrugCount();

        /// <summary>
        /// 获取BreedDrug总条数
        /// </summary>
        /// <returns></returns>
        int GetBreedDrugCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的防疫信息（分页）
        /// </summary>
        /// <param name="name">查询条件：地块名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<BreedDrugModel> GetPagerBreedDrug(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取BreedDrug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BreedDrugModel GetBreedDrugById(int id);

        /// <summary>
        /// 新增单条BreedDrug
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleBreedDrug(BreedDrugModel model);

        /// <summary>
        /// 编辑单条BreedDrug
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleBreedDrug(BreedDrugModel model);

        /// <summary>
        /// 删除单条BreedDrug
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleEntity(int id);
    }
}

