using System.ComponentModel.DataAnnotations;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class SeedBaseAccess : BaseAccess, ISeedBaseAccess
    {
        public int GetEntityCount()
        {
            return base.Context.SeedBase.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.SeedBase.Where(m => (string.IsNullOrEmpty(name) || m.SeedName.Contains(name))).Count();
        }

        public List<SeedBaseModel> GetAllEntities()
        {
            return base.Context.SeedBase.ToList();
        }

        public SeedBaseModel GetEntityById(int id)
        {
            return base.Context.SeedBase.FirstOrDefault(m => m.SeedID == id);
        }


        public MessageModel InsertSingleEntity(SeedBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.SeedBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public SeedBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.SeedBase.FirstOrDefault(m => m.SeedID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(SeedBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.SeedBase.FirstOrDefault(m => m.SeedID == model.SeedID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.SeedCode = model.SeedCode;
                data.SeedNO = model.SeedNO;
                data.SeedName = model.SeedName;
                data.BatchNO = model.BatchNO;
                data.Place = model.Place;
                data.Supplier = model.Supplier;
                data.PurchPerson = model.PurchPerson;
                data.BuyTime = model.BuyTime;
                data.BuyCount = model.BuyCount;
                data.Units = model.Units;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                if (context.PlansBatch.Any(m => m.BlockID == id)) return "该种子信息存在关联数据，不能被删除！";

                var data = Context.SeedBase.FirstOrDefault(m => m.SeedID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<SeedBaseModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<SeedBaseModel> GetPagerSeedBaseByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.SeedBase.Where(m => (string.IsNullOrEmpty(name) || m.SeedName.Contains(name))).OrderBy(m => m.SeedID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<SeedDto> GetSeedPagingList(string name, int pIndex, int pSize)
        {
            var query =(from s in Context.SeedBase
                        select new SeedDto()
                        {
                            SeedID = s.SeedID,
                            SeedCode = s.SeedCode,
                            SeedName = s.SeedName,
                            BatchNO = s.BatchNO,
                            Place = s.Place,
                            Supplier = s.Supplier,
                            PurchPerson = s.PurchPerson,
                            BuyTime = s.BuyTime,
                            BuyCount = s.BuyCount,
                            Units = s.Units,
                            Remark = s.Remark
                        }).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.SeedName.Contains(name));
            }

            var list = query.OrderBy(s=>s.SeedID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();
            var count = query.Count();

            return new GridList<SeedDto>(){rows = list,total = count};
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SeedDto GetSeedDtoById(int id)
        {
            var query = (from s in Context.SeedBase
                         where s.SeedID==id
                         select new SeedDto()
                         {
                             SeedID = s.SeedID,
                             SeedCode = s.SeedCode,
                             SeedName = s.SeedName,
                             BatchNO = s.BatchNO,
                             Place = s.Place,
                             Supplier = s.Supplier,
                             PurchPerson = s.PurchPerson,
                             BuyTime = s.BuyTime,
                             BuyCount = s.BuyCount,
                             Units = s.Units,
                             Remark = s.Remark
                         }).FirstOrDefault();

            return query;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var idArray = ids.Split(',');
                var list = context.SeedBase.Where(s => idArray.Contains(s.SeedID.ToString())).ToList();
                if (list.Any())
                {
                    context.BatchDelete(list);
                }
                return string.Empty;
            };

            return base.DbOperation(operation);
        }
    }
}
