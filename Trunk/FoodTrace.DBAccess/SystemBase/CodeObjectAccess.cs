using System.Xml.Serialization.Configuration;
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
    public class CodeObjectAccess : BaseAccess, ICodeObjectAccess
    {
        public int GetEntityCount()
        {
            return base.Context.CodeObject.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.CodeObject.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name))).Count();
        }

        public List<CodeObjectModel> GetAllEntities()
        {
            return base.Context.CodeObject.ToList();
        }

        public CodeObjectModel GetEntityById(int id)
        {
            return base.Context.CodeObject.FirstOrDefault(m => m.ObjectID == id);
        }

        public MessageModel InsertSingleEntity(CodeObjectModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.CodeObject.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CodeObjectModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.CodeObject.FirstOrDefault(m => m.ObjectID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(CodeObjectModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.CodeObject.FirstOrDefault(m => m.ObjectID == model.ObjectID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ObjectCode = model.ObjectCode;
                data.ObjectName = model.ObjectName;
                data.Prefix = model.Prefix;
                data.MaxLength = model.MaxLength;
                data.SeqLength = model.SeqLength;
                data.IsFixedLength = model.IsFixedLength;
                data.IsAuto = model.IsAuto;
                data.SortID = model.SortID;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = model.ModifyID;
                data.ModifyName = model.ModifyName;
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
                var data = context.CodeObject.FirstOrDefault(m => m.ObjectID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<CodeObjectModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteCodeObjectByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var idsArray = ids.Split(',');
                var data =context.CodeObject.Where(m =>idsArray.Contains(m.ObjectID.ToString())).ToList();
                if (data.Any())
                {
                    context.BatchDelete(data);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
        public List<CodeObjectModel> GetPagerCodeObjectByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.CodeObject.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name)))
                    .OrderBy(m => m.ObjectID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }


        /// <summary>
        /// 生成5位流水号长度的批次号
        /// </summary>
        /// <param name="objCode"></param>
        /// <returns></returns>
        public string GetCodeObjNum(string objCode)
        {
            string num = string.Empty;
            try
            {
                string  dt1 = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                string dt2 = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                DateTime stime = DateTime.Parse(dt1);
                DateTime etime = DateTime.Parse(dt2);
                var codemax = (from s in Context.CodeMax
                    where s.ObjectCode == objCode && s.ModifyTime > stime && s.ModifyTime < etime
                    select s
                    ).FirstOrDefault();
                
                if (codemax == null)
                {
                    var data = Context.CodeObject.Where(s => s.ObjectCode == objCode).FirstOrDefault();
                    if (data != null)
                    {
                        if (!string.IsNullOrEmpty(data.Prefix))
                        {
                            num += data.Prefix;
                        }
                        string dt = DateTime.Now.ToString("yyyyMMdd");
                        num += dt;
                        string newseqNum = "00001";
                        num += newseqNum;
                        
                        //插入
                        InsertCodeMax(data.ObjectCode, data.ObjectName, num);
                    }

                }
                else
                {
                    var val = codemax.ObjectValue;
                    if (!string.IsNullOrEmpty(val))
                    {
                        var tempHeadSeq = val.Substring(0, val.Length - 5);
                        var tempVal = val.Substring(val.Length-5, 5);

                        int tempSeq = int.Parse(tempVal);
                        string tempseq2=(tempSeq + 1).ToString().PadLeft(5, '0');
                        num = tempHeadSeq + tempseq2;

                        codemax.ObjectValue = num;
                        UpdateCodeMax(codemax);
                    }
                   
                }

            }
            catch (Exception)
            {
             
            }

            return num;
        }


        private void InsertCodeMax(string code,string name,string codeVal)
        {
            var model = new CodeMaxModel();
            model.ObjectCode = code;
            model.ObjectName = name;
            model.ObjectValue = codeVal;
            model.SortID = 0;
            model.IsLocked = false;
            model.IsShow = true;
            model.ModifyID = UserManagement.CurrentUser.UserID;
            model.ModifyName = UserManagement.CurrentUser.UserName;
            model.ModifyTime = DateTime.Now;
            Context.CodeMax.Add(model);
            Context.SaveChanges();
        }

        private MessageModel UpdateCodeMax(CodeMaxModel model)
        {

             Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var basemodel = context.CodeMax.Where(s => s.CodeMaxID == model.CodeMaxID).FirstOrDefault();
            if (basemodel != null)
            {
                basemodel.ObjectValue = model.ObjectValue;
               context.UpdateAndSave(basemodel);
            }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
           
        }
    }
}
