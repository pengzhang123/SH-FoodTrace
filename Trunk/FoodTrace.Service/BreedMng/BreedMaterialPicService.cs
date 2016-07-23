using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 用料图片管理
    /// </summary>
    public class BreedMaterialPicService : BaseService, IBreedMaterialPicService
    {
        private IBreedMaterialPicAccess breedMaterialPicAccess;

        public BreedMaterialPicService()
        {
            breedMaterialPicAccess = BaseAccess.CreateAccess<IBreedMaterialPicAccess>(AccessMappingKey.BreedMaterialPicAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedMaterialPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedMaterialPicAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedMaterialPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedMaterialPicModel GetBreedMaterialPicById(int id)
        {
            return breedMaterialPicAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedMaterialPic总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedMaterialPicCount()
        {
            return breedMaterialPicAccess.GetEntityCount();
        }

        public int GetBreedMaterialPicCount(string name)
        {
            throw new NotImplementedException();
        }

        public List<BreedMaterialPicModel> GetPagerBreedMaterialPic(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 插入单条BreedMaterialPic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedMaterialPic(BreedMaterialPicModel model)
        {
            return breedMaterialPicAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedMaterialPic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedMaterialPic(BreedMaterialPicModel model)
        {
            var data = breedMaterialPicAccess.GetOriEntity(model.PicID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedMaterialPicAccess.UpdateSingleEntity(model);
        }
    }
}
