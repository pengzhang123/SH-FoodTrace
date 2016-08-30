using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodTrace.DBAccess
{
    public class  AreaPlatAccess : BaseAccess, IAreaPlatAccess
    {
        public int GetEntityCount()
        {
            return base.Context.AreaPlat.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.AreaPlat.Where(m => (string.IsNullOrEmpty(name) || m.AreaName.Contains(name))).Count();
        }

        public List< AreaPlatModel> GetAllEntities()
        {
            return base.Context.AreaPlat.ToList();
        }

        public  AreaPlatModel GetEntityById(int id)
        {
            return base.Context.AreaPlat.FirstOrDefault(m => m.AreaID == id);
        }

        public MessageModel InsertSingleEntity(AreaPlatModel model)
        {
            Func<IEntityContext,string> operation = delegate (IEntityContext context)
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.AreaPlat.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public  AreaPlatModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.AreaPlat.FirstOrDefault(m => m.AreaID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity( AreaPlatModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context. AreaPlat.FirstOrDefault(m => m.AreaID == model.AreaID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.AreaName = model.AreaName;
                data.AreaCode = model.AreaCode;
                data.Remark = model.Remark;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                //if (context.Company.Any(m => m.AreaCode == id)) return "该区域信息存在关联数据，不能被删除！";

                var data = context.AreaPlat.FirstOrDefault(m => m.AreaID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave< AreaPlatModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteAreaPlatByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var idsArray = ids.Split(',');
                var plat =(from s in context.AreaPlat
                           join id in idsArray on s.AreaID.ToString() equals id
                              select s).ToList();
                if (plat.Any())
                {
                    context.BatchDelete(plat);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List< AreaPlatModel> GetPagerAreaPlatByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.AreaPlat.Where(m => (string.IsNullOrEmpty(name) || m. AreaName.Contains(name)))
                    .OrderBy(m => m.AreaID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
