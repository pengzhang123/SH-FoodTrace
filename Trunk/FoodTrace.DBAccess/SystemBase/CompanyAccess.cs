using System.Security.Cryptography;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FoodTrace.DBManage.Contexts;
using FoodTrace.DBManage.IContexts;
using FoodTrace.Common.Libraries;

namespace FoodTrace.DBAccess
{
    public class CompanyAccess : BaseAccess, ICompanyAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Company.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.Company.Where(m => (string.IsNullOrEmpty(name) || m.CompanyName.Contains(name))).Count();
        }

        public List<CompanyModel> GetAllEntities()
        {
            return base.Context.Company.ToList();
        }

        public CompanyModel GetEntityById(int id)
        {
            return base.Context.Company.FirstOrDefault(m => m.CompanyID == id);
        }


        public MessageModel InsertSingleEntity(CompanyModel model)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                context.Company.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CompanyModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Company.FirstOrDefault(m => m.CompanyID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(CompanyModel model)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var data =
                    context.Company.FirstOrDefault(
                        m => m.CompanyID == model.CompanyID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CompanyName = model.CompanyName;
                data.AreaCode = model.AreaCode;
                data.Address = model.Address;
                data.Leader = model.Leader;
                data.Logo = model.Logo;
                data.OrgID = model.OrgID;
                data.QsCode = model.QsCode;
                data.Location = model.Location;
                data.Code = model.Code;
                data.ZipCode = model.ZipCode;
                data.TaxCard = model.TaxCard;
                data.Fax = model.Fax;
                data.Mobile = model.Mobile;
                data.Email = model.Email;
                data.Info = model.Info;
                data.Demand = model.Demand;
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
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                //公司名下包含基地信息，则不能被直接删除
                if (context.LandBase.Any(m => m.CompanyID == id) || context.KillCull.Any(m => m.CompanyID == id))
                    return "该公司信息存在关联数据，不能被删除！";

                var data = Context.Company.FirstOrDefault(m => m.CompanyID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<CompanyModel>(id);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<CompanyModel> GetPagerCompanyByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.Company.Where(m => (string.IsNullOrEmpty(name) || m.CompanyName.Contains(name)))
                .OrderBy(m => m.CompanyID).Skip((pageIndex - 1)*pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取企业机构树
        /// </summary>
        /// <returns></returns>
        public List<ZtreeModel> GetCompantTree(int comId)
        {
            var list = new List<ZtreeModel>();
            var company = (from com in Context.Company
                where com.CompanyID == comId
                select new ZtreeModel()
                {
                    id = com.CompanyID.ToString(),
                    name = com.CompanyName,
                    pId = "0",
                    type = 0
                }).FirstOrDefault();

            if (company != null)
            {
                list.Add(company);

                var deptbase = (from s in Context.Dept
                                where s.CompanyID==comId
                    select s).ToList();
                if (deptbase.Any())
                {
                    var deptment = (from dept in deptbase
                        where dept.UpperDeptID == 0
                        select new ZtreeModel()
                        {
                            id = dept.DeptID.ToString(),
                            name = dept.DeptName,
                            pId = dept.CompanyID.ToString(),
                            type = 1,
                        }).ToList();

                    if (deptment.Any())
                    {
                        list.AddRange(deptment);
                    }

                    var deptsonment = (from dept in deptbase
                        where dept.UpperDeptID > 0
                        select new ZtreeModel()
                        {
                            id = dept.DeptID.ToString(),
                            name = dept.DeptName,
                            pId = dept.UpperDeptID.ToString(),
                            type = 1
                        }).ToList();
                    if (deptsonment.Any())
                    {
                        list.AddRange(deptsonment);
                    }
                }
            }


            return list;
        }
    }
}