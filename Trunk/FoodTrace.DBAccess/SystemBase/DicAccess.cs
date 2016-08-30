using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess.SystemBase;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class DicAccess:BaseAccess,IDicAccess
    {
        #region DicRoot表
        /// <summary>
        /// 获取dicroot分页数据
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<DicRootModel> GetDicrootList(int pIndex, int pSize)
        {
            //var list = new GridList<DicRootModel>();

            var query = (from s in Context.DicRoot
                select s).AsQueryable();

            return new GridList<DicRootModel>() { rows = query.OrderBy(s => s.RootID).Skip((pIndex - 1) * pSize).Take(pSize).ToList(), total = query.Count() };
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DicRootModel GetDicRootModelById(int id)
        {
            return Context.DicRoot.Find(id);
        }

        public MessageModel InsertDicRootData(DicRootModel model)
        {
            Func<IEntityContext, string> opera = delegate(IEntityContext context)
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.DicRoot.Add(model);
                context.SaveChanges();
                return string.Empty;
            };

            return base.DbOperationInTransaction(opera);
        }

        public MessageModel UpdateDicRootData(DicRootModel model)
        {
            Func<IEntityContext, string> opera = delegate(IEntityContext context)
            {
                var dicroot = context.DicRoot.Find(model.RootID);
                if (dicroot!=null)
                {
                    dicroot.Name = model.Name;
                    dicroot.Description = model.Description;
                    dicroot.SortID = model.SortID;
                    dicroot.IsLocked = model.IsLocked;
                    dicroot.Code = model.Code;
                    dicroot.ModifyID = UserManagement.CurrentUser.UserID;
                    dicroot.ModifyTime = DateTime.Now;
                    dicroot.ModifyName = UserManagement.CurrentUser.UserName;
                    context.UpdateAndSave(dicroot);
                }

                return string.Empty;
            };

            return base.DbOperationInTransaction(opera);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteDicRootByIds(string ids)
        {
            Func<IEntityContext, string> opera = delegate(IEntityContext context)
            {
                var idsArray = ids.Split(',');
                var dicroot = context.DicRoot.Where(s => idsArray.Contains(s.RootID.ToString())).ToList();
                if (dicroot.Any())
                {
                    context.BatchDelete(dicroot);
                }

                return string.Empty;
            };

            return base.DbOperationInTransaction(opera);
        }
         #endregion

        #region Dic表
        /// <summary>
        /// 获取dic分页数据
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<DicGridDto> GetDicList(int dicId, string dicName, int pIndex, int pSize)
        {

            var query = (from s in Context.Dic
                         join dic in Context.Dic on s.RootID equals dic.DicID into dicl
                         from dicleft in dicl.DefaultIfEmpty()
                         select new DicGridDto()
                         {
                             DicID = s.DicID,
                             Code = s.Code,
                             Description = s.Description,
                             Name = s.Name,
                             ParentName = dicleft.Name,
                             RootID = s.RootID,
                             SortID = s.SortID
                         }).AsQueryable();
            if (dicId > 0)
            {
                query = query.Where(s => s.DicID == dicId || s.RootID == dicId);
            }
            if (!string.IsNullOrEmpty(dicName))
            {
                query = query.Where(s => s.Name.Contains(dicName));
            }
            return new GridList<DicGridDto>() { rows = query.OrderBy(s => s.DicID).Skip((pIndex - 1) * pSize).Take(pSize).ToList(), total = query.Count() };
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DicModel GetDicModelById(int id)
        {
            return Context.Dic.Find(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel InsertDicData(DicModel model)
        {
            Func<IEntityContext, string> opera = delegate(IEntityContext context)
            {
                context.Dic.Add(model);
                context.SaveChanges();
                return string.Empty;
            };

            return base.DbOperationInTransaction(opera);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateDicData(DicModel model)
        {
            Func<IEntityContext, string> opera = delegate(IEntityContext context)
            {
                var dicroot = context.Dic.Find(model.DicID);
                if (dicroot != null)
                {
                    dicroot.Code = model.Code;
                    dicroot.RootID = model.RootID;
                    dicroot.Name = model.Name;
                    dicroot.Description = model.Description;
                    dicroot.SortID = model.SortID;
                    dicroot.IsLocked = model.IsLocked;
                    dicroot.ModifyID = UserManagement.CurrentUser.UserID;
                    dicroot.ModifyTime = DateTime.Now;
                    dicroot.ModifyName = UserManagement.CurrentUser.UserName;
                    context.UpdateAndSave(dicroot);
                }

                return string.Empty;
            };

            return base.DbOperationInTransaction(opera);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteDicByIds(string ids)
        {
            Func<IEntityContext, string> opera = delegate(IEntityContext context)
            {
                var dicroot = context.Dic.Where(s => ids.Contains(s.DicID.ToString())).ToList();
                if (dicroot.Any())
                {
                    context.BatchDelete(dicroot);
                }

                return string.Empty;
            };

            return base.DbOperationInTransaction(opera);
        }
        #endregion

        /// <summary>
        /// 获取根字典数据项
        /// </summary>
        /// <returns></returns>
        public List<ZtreeModel> GetRootDicTree()
        {
            var list = (from s in Context.Dic
                        where s.RootID==0
                select new ZtreeModel()
                {
                    id = s.DicID.ToString(),
                    name = s.Name,
                    pId = "0",
                    code = s.Code
                }).ToList();
            return list;
        }
    }
}
