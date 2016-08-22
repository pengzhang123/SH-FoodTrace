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
    /// 养殖区域管理
    /// </summary>
    public class BreedAreaService :BaseService, IBreedAreaService
    {
        private IBreedAreaAccess breedAreaAccess;

        public BreedAreaService()
        {
            breedAreaAccess = BaseAccess.CreateAccess<IBreedAreaAccess>(AccessMappingKey.BreedAreaAccess.ToString());
        }
        
        /// <summary>
        /// 删除单条BreedArea
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteSingleEntity(int id)
        {
            return breedAreaAccess.DeleteSingleEntity(id);
        }

        /// <summary>
        /// 通过ID获取BreedArea
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedAreaModel GetBreedAreaById(int id)
        {
            return breedAreaAccess.GetEntityById(id);
        }

        /// <summary>
        /// 获取BreedArea总条数
        /// </summary>
        /// <returns></returns>
        public int GetBreedAreaCount()
        {
            return breedAreaAccess.GetEntityCount();
        }

        public int GetBreedAreaCount(string name)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return breedAreaAccess.GetEntityCount(companyID, name);
        }

        public List<BreedAreaModel> GetPagerBreedArea(string name, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = breedAreaAccess.GetPagerBreedAreaByConditions(companyID, name.Trim(), pageIndex, pageSize);
            return result;
        }

        /// <summary>
        /// 插入单条BreedArea数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertSingleBreedArea(BreedAreaModel model)
        {
            return breedAreaAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条BreedArea
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateSingleBreedArea(BreedAreaModel model)
        {
            //var data = breedAreaAccess.GetOriEntity(model.AreaID, model.ModifyTime);
            //if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return breedAreaAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedAreaDto GetAreaDtoById(int id)
        {
            return breedAreaAccess.GetAreaDtoById(id);
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<BreedAreaDto> GetAreaGridList(int pIndex, int pSize)
        {
            int comId = UserManagement.CurrentUser.CompanyId;
            return breedAreaAccess.GetAreaGridList(comId, pIndex, pSize);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return breedAreaAccess.DeleteByIds(ids);
        }
    }
}
