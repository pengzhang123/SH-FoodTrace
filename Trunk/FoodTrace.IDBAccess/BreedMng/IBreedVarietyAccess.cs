using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IDBAccess.BreedMng
{
    public interface IBreedVarietyAccess
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<BreedVarietyDto> GetVarietyGridList(string name, int comid, int pIndex, int pSize);

        /// <summary>
        /// 获取品种列表
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        List<BreedVarietyModel> GetVarietyList(int comId);

        /// <summary>
        /// 单表插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel InsertVarietyModel(BreedVarietyModel model);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel UpdateVarietyModel(BreedVarietyModel model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);

        BreedVarietyDto GetVarietyDtoById(int id);
    }
}
