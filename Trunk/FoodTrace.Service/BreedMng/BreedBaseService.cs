using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service
{
    /// <summary>
    /// 养殖基础信息管理
    /// </summary>
    public class BreedBaseService : BaseService, IBreedBaseService
    {
        private IBreedBaseAccess breedBaseAccess;
        public BreedBaseService()
        {
            breedBaseAccess = BaseAccess.CreateAccess<IBreedBaseAccess>(AccessMappingKey.BreedBaseAccess.ToString());
        }

        /// <summary>
        /// 删除单条BreedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedBaseAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedBaseModel GetBreedBaseById(int id)
        {
            return breedBaseAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedBaseCount()
        {
            return breedBaseAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取BreedBase总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedBaseCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return breedBaseAccess.GetEntityCount(companyID,name);
        }

        public List<BreedBaseModel> GetPagerBreedBase(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = breedBaseAccess.GetPagerBreedBaseByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedBase数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedBase(BreedBaseModel model)
        {
            return breedBaseAccess.InsertSingleEntity(model);
        }

        public MessageModel UpdateSingleBreedBase(BreedBaseModel model)
        {
            var data = breedBaseAccess.GetOriEntity(model.BreedID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedBaseAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<BreedBaseDto> GetBreedBaseListPaging(int pIndex, int pSize)
        {
            int comid = UserManagement.CurrentUser.CompanyId;
            return breedBaseAccess.GetBreedBaseListPaging(comid, pIndex, pSize);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return breedBaseAccess.DeleteByIds(ids);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedBaseDto GetBreedBaseDtoById(int id)
        {
            return breedBaseAccess.GetBreedBaseDtoById(id);
        }
    }
}
