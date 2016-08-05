using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess.SystemBase;
using FoodTrace.IService.SystemBase;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.Service.SystemBase
{
    public class DicService : BaseService,IDicService
    {
        private readonly IDicAccess _dicAccess;

        public DicService()
        {
            _dicAccess = BaseAccess.CreateAccess<IDicAccess>(AccessMappingKey.DicAccess.ToString());
        }
        #region dicroot
        /// <summary>
        /// 获取dicroot分页数据
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<DicRootModel> GetDicrootList(int pIndex, int pSize)
        {
            return _dicAccess.GetDicrootList(pIndex, pSize);
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DicRootModel GetDicRootModelById(int id)
        {
            return _dicAccess.GetDicRootModelById(id);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertDicRootData(DicRootModel model)
        {
            return _dicAccess.InsertDicRootData(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateDicRootData(DicRootModel model)
        {
            return _dicAccess.UpdateDicRootData(model);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
       public  MessageModel DeleteDicRootByIds(string ids)
        {
            return _dicAccess.DeleteDicRootByIds(ids);
        }
        #endregion

        #region dic

        /// <summary>
        /// 获取dic分页数据
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
       public  GridList<DicModel> GetDicList(int pIndex, int pSize)
        {
            return _dicAccess.GetDicList(pIndex, pSize);
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public  DicModel GetDicModelById(int id)
        {
            return _dicAccess.GetDicModelById(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertDicData(DicModel model)
        {
            return _dicAccess.InsertDicData(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateDicData(DicModel model)
        {
            return _dicAccess.UpdateDicData(model);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteDicByIds(string ids)
        {
            return _dicAccess.DeleteDicByIds(ids);
        }
        #endregion
    }
}
