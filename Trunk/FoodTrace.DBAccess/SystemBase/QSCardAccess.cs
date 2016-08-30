using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.IDBAccess.SystemBase;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class QSCardAccess : BaseAccess,IQSCardAccess
    {

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QSCardModel GetQsCardById(int id)
        {
            return Context.QSCard.Find(id);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<QsCardDto> GetQsCardPagingList(string name, int pIndex, int pSize)
        {
            var query = (from s in Context.QSCard
                         join com in Context.Company on s.CompanyID equals com.CompanyID into coml
                         from comleft in coml.DefaultIfEmpty()
                         select new QsCardDto()
                         {
                             QSID = s.QSID,
                             QSName = s.QSName,
                             QSCard = s.QSCard,
                             IssuingTime = s.IssuingTime,
                             IssuingUnit = s.IssuingUnit,
                             Validity = s.Validity,
                             Remark = s.Remark,
                             CompanyID = s.CompanyID,
                             CompanyName = comleft.CompanyName
                         }).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.QSName.Contains(name));
            }
            var list = query.OrderBy(s => s.QSID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();
            int count = query.Count();

            return new GridList<QsCardDto>() { rows = list, total = count };
        }


        public List<QsCardDto> GetQsCardListByComId(int comid)
        {
            var query = (from s in Context.QSCard
                         join com in Context.Company on s.CompanyID equals com.CompanyID into coml
                         from comleft in coml.DefaultIfEmpty()
                         where s.CompanyID==comid
                         select new QsCardDto()
                         {
                             QSID = s.QSID,
                             QSName = s.QSName,
                             QSCard = s.QSCard,
                             IssuingTime = s.IssuingTime,
                             IssuingUnit = s.IssuingUnit,
                             Validity = s.Validity,
                             Remark = s.Remark,
                             CompanyID = s.CompanyID,
                             CompanyName = comleft.CompanyName
                         }).AsQueryable();

           
            var list = query.ToList();
            //int count = query.Count();

            return list;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        public MessageModel InsertQSCard(QSCardModel model)
        {
           
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.QSCard.Add(model);
                context.SaveChanges();
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateQSCard(QSCardModel model)
        {

            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var basemodel = context.QSCard.Find(model.QSID);

                if (basemodel != null)
                {
                    basemodel.CompanyID = model.CompanyID;
                    basemodel.QSName = model.QSName;
                    basemodel.CheckType = model.CheckType;
                    basemodel.QSCard = model.QSCard;
                    basemodel.IssuingTime = model.IssuingTime;
                    basemodel.IssuingUnit = model.IssuingUnit;
                    basemodel.Validity = model.Validity;
                    basemodel.Remark = model.Remark;
                    basemodel.IsLocked = model.IsLocked;
                    basemodel.IsShow = model.IsShow;
                    basemodel.ModifyID = UserManagement.CurrentUser.UserID;
                    basemodel.ModifyName = UserManagement.CurrentUser.UserName;
                    basemodel.ModifyTime = DateTime.Now;

                    context.UpdateAndSave(basemodel);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
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

                var idsArray = ids.Split(',');
                var baselist = context.QSCard.Where(s => idsArray.Contains(s.QSID.ToString())).ToList();
                if (baselist.Any())
                {
                    context.BatchDelete(baselist);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
    }
}
