using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖日志
    /// </summary>
    public class BreedLogService : BaseService, IBreedLogService
    {
        private IBreedLogAccess breedLogAccess;

        public BreedLogService()
        {
            breedLogAccess = BaseAccess.CreateAccess<IBreedLogAccess>(AccessMappingKey.BreedLogAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedLog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedLogAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedLog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedLogModel GetBreedLogById(int id)
        {
            return breedLogAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedLog总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedLogCount()
        {
            return breedLogAccess.GetEntityCount();
        }

        public int GetBreedLogCount(string name)
        {
            throw new NotImplementedException();
        }

        public List<BreedLogModel> GetPagerBreedLog(string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 插入单条BreedLog
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedLog(BreedLogModel model)
        {
            return breedLogAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedLog
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedLog(BreedLogModel model)
        {
            var data = breedLogAccess.GetOriEntity(model.LogID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedLogAccess.UpdateSingleEntity(model);
        }
    }
}
