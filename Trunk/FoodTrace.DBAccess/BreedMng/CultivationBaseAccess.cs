using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class CultivationBaseAccess : BaseAccess, ICultivationBaseAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.CultivationBase.FirstOrDefault(m => m.CultivationID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<CultivationBaseModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<CultivationBaseModel> GetAllEntities()
        {
            return base.Context.CultivationBase.ToList();
        }

        public CultivationBaseModel GetEntityById(int id)
        {
            return base.Context.CultivationBase.FirstOrDefault(m => m.CultivationID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.CultivationBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.CultivationBase.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.CultivationEpc == name)).Count();
        }

        public CultivationBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.CultivationBase.FirstOrDefault(m => m.CultivationID == id && m.ModifyTime == modifyTime);
        }

        public List<CultivationBaseModel> GetPagerCultivationBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            var query = (from s in Context.CultivationBase
                join bb in Context.BreedBase on s.BreedID equals bb.BreedID
                join lb in Context.LandBase on bb.LandID equals lb.LandID
                where lb.CompanyID == companyID
                select s).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.CultivationEpc == name);
            }

            return query.OrderBy(m => m.CultivationID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(CultivationBaseModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.CultivationBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(CultivationBaseModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.CultivationBase.FirstOrDefault(m => m.BreedID == model.BreedID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CultivationID = model.CultivationID;
                data.BreedID = model.BreedID;
                data.AreaID = model.AreaID;
                data.HomeID = model.HomeID;
                data.CultivationEpc = model.CultivationEpc;
                data.BatchCode = model.BatchCode;
                data.Source = model.Source;
                data.FatherID = model.FatherID;
                data.MontherID = model.MontherID;
                data.VarietyType = model.VarietyType;
                data.VarietyCode = model.VarietyCode;
                data.VarietyName = model.VarietyName;
                data.InTime = model.InTime;
                data.OutTime = model.OutTime;
                data.OutNotes = model.OutNotes;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public CultivationBaseModel GetCultivationInfoByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.CultivationBase.FirstOrDefault(m => string.IsNullOrEmpty(Epc) || m.CultivationEpc == Epc);
        }
    }
}
