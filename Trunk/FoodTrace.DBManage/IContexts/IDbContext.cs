using FoodTrace.DBManage.Contexts;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

namespace FoodTrace.DBManage.IContexts
{
    public interface IDbContext
    {
        void Update<T>(T entity) where T : class;
        void UpdateAndSave<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteAndSave<T>(object id) where T : class;
        void DeleteAndSave<T>(T entity) where T : class;
        int DeleteAll<T>(string table, string keyName, int[] keys) where T : class;
        int UpdateAll<T>(string table, string keyName, int[] keys, string column, bool value) where T : class;
        int UpdateAll<T>(string table, string keyName, int[] keys, string column, string value) where T : class;
        int UpdateAll<T>(string table, string keyName, int[] keys, Dictionary<string, string> columnsToUPdate) where T : class;

        int ExecuteSQL(string sqlStatement);

        Database Database { get; }
        int SaveChanges();
        void ExecuteProcedure(string commandText, Dictionary<string, object> parameters);


        void BatchDelete<T>(List<T> list) where T : class;
        void BatctInsert<T>(List<T> list) where T : class;
    }
}
