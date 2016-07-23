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
    public class DeptAccess : BaseAccess, IDeptAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Dept.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.Dept.Where(m => m.CompanyID == companyID
                                            && (string.IsNullOrEmpty(name) || m.DeptName.Contains(name))).Count();
        }

        public List<DeptModel> GetAllEntities()
        {
            return base.Context.Dept.ToList();
        }

        public DeptModel GetEntityById(int id)
        {
            return base.Context.Dept.FirstOrDefault(m => m.DeptID == id);
        }

        public MessageModel InsertSingleEntity(DeptModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Dept.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public DeptModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Dept.FirstOrDefault(m => m.DeptID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(DeptModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Dept.FirstOrDefault(m => m.DeptID == model.DeptID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.CompanyID = model.CompanyID;
                data.DeptName = model.DeptName;
                data.UpperDeptID = model.UpperDeptID;
                data.DeptRemark = model.DeptRemark;
                data.SortID = model.SortID;
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
                //公司名下包含基地信息，则不能被直接删除
                if (context.UserBase.Any(m => m.DeptID == id)) return "该部门信息存在关联数据，不能被删除！";

                var data = Context.Dept.FirstOrDefault(m => m.DeptID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<DeptModel>(id);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<DeptModel> GetPagerDeptByConditions(string name, int pageIndex, int pageSize,int? companyID )
        {
            return base.Context.Dept.Where(m => (companyID==null||m.CompanyID== companyID)
                                            && (string.IsNullOrEmpty(name) || m.DeptName.Contains(name)))
                    .OrderBy(m => m.DeptID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
