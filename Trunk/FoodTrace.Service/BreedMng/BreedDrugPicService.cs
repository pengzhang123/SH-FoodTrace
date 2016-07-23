using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖防疫图片管理
    /// </summary>
    public class BreedDrugPicService:BaseService,IBreedDrugPicService
    {
        private IBreedDrugPicAccess breedDrugPicAccess;

        public BreedDrugPicService()
        {
            breedDrugPicAccess = BaseAccess.CreateAccess<IBreedDrugPicAccess>(AccessMappingKey.BreedDrugPicAccess.ToString());
        }

        /// <summary>
        /// 获取BreedDrugPic总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedDrugPicCount()
        {
            return breedDrugPicAccess.GetEntityCount();
        }

        public List<BreedDrugPicModel> GetPagerBreedDrugPic(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过ID获取BreedDrugPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedDrugPicModel GetBreedDrugPicById(int id)
        {
            return breedDrugPicAccess.GetEntityById(id);
        }

        /// <summary>
        /// 插入单条BreedDrugPic数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedDrugPic(BreedDrugPicModel model)
        {
            return breedDrugPicAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedDrugPic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedDrugPic(BreedDrugPicModel model)
        {
            var data = breedDrugPicAccess.GetOriEntity(model.PicID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedDrugPicAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条BreedDrugPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedDrugPicAccess.DeleteSingleEntity(id);
        }

        public int GetBreedDrugPicCount(string name)
        {
            throw new NotImplementedException();
        }
    }
}
