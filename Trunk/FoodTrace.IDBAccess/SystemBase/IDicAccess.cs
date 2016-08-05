using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.IDBAccess.SystemBase
{
    public interface IDicAccess
    {
        #region DicRoot

        /// <summary>
        /// 获取dicroot分页数据
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<DicRootModel> GetDicrootList(int pIndex, int pSize);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DicRootModel GetDicRootModelById(int id);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel InsertDicRootData(DicRootModel model);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel UpdateDicRootData(DicRootModel model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteDicRootByIds(string ids);

        #endregion

        #region dic表

        /// <summary>
        /// 获取dic分页数据
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<DicModel> GetDicList(int pIndex, int pSize);
        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DicModel GetDicModelById(int id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel InsertDicData(DicModel model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel UpdateDicData(DicModel model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteDicByIds(string ids);

        #endregion
    }
}
