using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖健康图片管理
    /// </summary>
    public class BreedHealthPicServic : BaseService, IBreedHealthPicService
    {
        private IBreedHealthPicAccess breedHealthPicAccess;

        public BreedHealthPicServic()
        {
            breedHealthPicAccess = BaseAccess.CreateAccess<IBreedHealthPicAccess>(AccessMappingKey.BreedHealthPicAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedHealthPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedHealthPicAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedHealthPic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedHealthPicModel GetBreedHealthPicById(int id)
        {
            return breedHealthPicAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedHealthPic总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedHealthPicCount()
        {
            return breedHealthPicAccess.GetEntityCount();
        }

        public int GetBreedHealthPicCount(string name)
        {
            throw new NotImplementedException();
        }

        public List<BreedHealthPicModel> GetPagerBreedHealthPic(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 插入单条BreedHealthPic数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedHealthPic(BreedHealthPicModel model)
        {
            return breedHealthPicAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedHealthPic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedHealthPic(BreedHealthPicModel model)
        {
            var data = breedHealthPicAccess.GetOriEntity(model.PicID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedHealthPicAccess.UpdateSingleEntity(model);
        }
    }
}
