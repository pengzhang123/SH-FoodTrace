using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IDBAccess.BreedMng;
using FoodTrace.IService.BreedMng;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service.BreedMng
{
    public class BreedVarietyService : BaseService, IBreedVarietyService
    {
        private readonly IBreedVarietyAccess _breedVarietyAccess;

        public BreedVarietyService()
        {
            _breedVarietyAccess = BaseAccess.CreateAccess<IBreedVarietyAccess>(AccessMappingKey.BreedVarietyAccess.ToString());
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<BreedVarietyDto> GetVarietyGridList(string name,int pIndex, int pSize)
        {
            int comId = UserManagement.CurrentUser.CompanyId;

            return _breedVarietyAccess.GetVarietyGridList(name,comId, pIndex, pSize);
        }

        /// <summary>
        /// 获取品种列表
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public List<BreedVarietyModel> GetVarietyList()
        {
            int comId = UserManagement.CurrentUser.CompanyId;
            return _breedVarietyAccess.GetVarietyList(comId);
        }

        /// <summary>
        /// 单表插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertVarietyModel(BreedVarietyModel model)
        {
            return _breedVarietyAccess.InsertVarietyModel(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateVarietyModel(BreedVarietyModel model)
        {
            return _breedVarietyAccess.UpdateVarietyModel(model);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return _breedVarietyAccess.DeleteByIds(ids);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedVarietyDto GetVarietyDtoById(int id)
        {
            return _breedVarietyAccess.GetVarietyDtoById(id);
        }
    }
}
