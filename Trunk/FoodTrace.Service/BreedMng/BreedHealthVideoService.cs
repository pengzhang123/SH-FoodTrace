using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖健康视频管理
    /// </summary>
    public class BreedHealthVideoService : BaseService, IBreedHealthVideoService
    {
        private IBreedHealthVideoAccess breedHealthVideoAccess;

        public BreedHealthVideoService()
        {
            breedHealthVideoAccess = BaseAccess.CreateAccess<IBreedHealthVideoAccess>(AccessMappingKey.BreedHealthVideoAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedHealthVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedHealthVideoAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedHealthVideo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedHealthVideoModel GetBreedHealthVideoById(int id)
        {
            return breedHealthVideoAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedHealthVideo总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedHealthVideoCount()
        {
            return breedHealthVideoAccess.GetEntityCount();
        }

        public int GetBreedHealthVideoCount(string name)
        {
            throw new NotImplementedException();
        }

        public List<BreedHealthVideoModel> GetPagerBreedHealthVideo(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 插入单条BreedHealthVideo数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedHealthVideo(BreedHealthVideoModel model)
        {
            return breedHealthVideoAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedHealthVideo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedHealthVideo(BreedHealthVideoModel model)
        {
            var data = breedHealthVideoAccess.GetOriEntity(model.VideoID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedHealthVideoAccess.UpdateSingleEntity(model);
        }
    }
}
