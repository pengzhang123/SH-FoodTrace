using FoodTrace.DBManage.Contexts;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FoodTrace.Common.Libraries;
using System.Transactions;
using FoodTrace.Model;

namespace FoodTrace.DBAccess
{
    public class BaseAccess
    {
        protected readonly IEntityContext Context;
        private const string AssemblyName = "FoodTrace.DBAccess";
        public BaseAccess()
        {
            string connStr = CommonConfig.ConnectionString;
            //SqlConnection conn = new SqlConnection(connStr);
            //Context = new EntityContext(conn, false);
            Context = new EntityContext(connStr);
        }

        protected MessageModel DbOperationInTransaction(Func<IEntityContext, string> operation)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IEntityContext db = new EntityContext(CommonConfig.ConnectionString))
                {
                    try
                    {
                        var res = operation(db);
                        var businessId = 0;
                        var test = Int32.TryParse(res, out businessId);
                        if (res != string.Empty && test == false)//不为空,且返回的值不为0的整数：说明业务操作不允许
                        {
                            return new MessageModel
                            {
                                Status = MessageStatus.Error,
                                Message = res
                            };
                        }
                        scope.Complete();
                        return new MessageModel { Status = MessageStatus.Success, NewBusinessId = businessId };
                    }
                    catch (Exception e)
                    {
                        return new MessageModel
                        {
                            Status = MessageStatus.Exception,
                            Message = e.InnerException != null ? e.InnerException.Message : e.Message
                        };
                    }
                }
            }
        }

        protected MessageModel DbOperation(Func<IEntityContext, string> operation)
        {
            using (IEntityContext db = new EntityContext(CommonConfig.ConnectionString))
            {
                try
                {
                    var res = operation(db);
                    var businessId = 0;
                    var test = Int32.TryParse(res, out businessId);
                    if (res != string.Empty && test == false)//不为空,且返回的值不为0的整数：说明业务操作不允许
                    {
                        return new MessageModel
                        {
                            Status = MessageStatus.Error,
                            Message = res
                        };
                    }
                    return new MessageModel { Status = MessageStatus.Success, NewBusinessId = businessId };
                }
                catch (Exception e)
                {
                    return new MessageModel
                    {
                        Status = MessageStatus.Exception,
                        Message = e.InnerException != null ? e.InnerException.Message : e.Message
                    };
                }
            }
        }


        public static T CreateAccess<T>(string name)
        {
            try
            {
                return (T)Assembly.Load(AssemblyName).CreateInstance(CommonConfig.ReadConfigValue(name));
            }
            catch (Exception ex)
            {
                Common.Log.Logger.Error(ex);
                return default(T);
            }
        }
    }
}
