using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess.BreedMng;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class BreedVarietyAccess : BaseAccess, IBreedVarietyAccess
    {

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<BreedVarietyDto> GetVarietyGridList(string name,int comid, int pIndex, int pSize)
        {
            var query = (from s in Context.BreedVariety
                join com in Context.Company on s.CompanyId equals com.CompanyID
                where s.CompanyId==comid
                select new BreedVarietyDto()
                {
                    VarietyId = s.VarietyId,
                    VarietyName = s.VarietyName,
                    CompanyId = s.CompanyId,
                    CompanyName = com.CompanyName,
                    Remark = s.Remark,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow,
                    ModifyName = s.ModifyName,
                    ModifyTime = s.ModifyTime
                }).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.VarietyName.Contains(name));
            }
            var list = query.OrderBy(s => s.VarietyId).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<BreedVarietyDto>(){rows = list,total=query.Count()};
        }

        /// <summary>
        /// 获取品种列表
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public List<BreedVarietyModel> GetVarietyList(int comId)
        {
            return Context.BreedVariety.Where(s => s.CompanyId == comId).ToList();
        }
        /// <summary>
        /// 单表插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertVarietyModel(BreedVarietyModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                model.CompanyId = UserManagement.CurrentUser.CompanyId;
                context.BreedVariety.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateVarietyModel(BreedVarietyModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedVariety.FirstOrDefault(m => m.VarietyId == model.VarietyId);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.VarietyName = model.VarietyName;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.CompanyId = UserManagement.CurrentUser.CompanyId;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var idarray = ids.Split(',');
                var list = context.BreedVariety.Where(s => idarray.Contains(s.VarietyId.ToString())).ToList();
                if (list.Any())
                {
                    context.BatchDelete(list);
                }
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedVarietyDto GetVarietyDtoById(int id)
        {
            var query = (from s in Context.BreedVariety
                         join com in Context.Company on s.CompanyId equals com.CompanyID
                         where s.VarietyId==id
                         select new BreedVarietyDto()
                         {
                             VarietyId = s.VarietyId,
                             VarietyName = s.VarietyName,
                             CompanyId = s.CompanyId,
                             CompanyName = com.CompanyName,
                             Remark = s.Remark,
                             IsLocked = s.IsLocked,
                             IsShow = s.IsShow
                         }).FirstOrDefault();

            return query;
        }
    }
}
