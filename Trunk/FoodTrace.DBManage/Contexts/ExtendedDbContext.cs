using System.Data.Entity.Migrations.History;
using FoodTrace.DBManage.IContexts;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;


namespace FoodTrace.DBManage.Contexts
{
    public class ExtendedDbContext: DbContext, IDbContext
    {
        public ExtendedDbContext() : base() { }
        public ExtendedDbContext(string connectionString) : base(connectionString) { }
        public ExtendedDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection) { }

        public void Update<T>(T entity) where T : class
        {
            this.Set<T>().Attach(entity);
            this.Entry<T>(entity).State = EntityState.Modified;
        }

        public void UpdateAndSave<T>(T entity) where T : class
        {
            this.Update<T>(entity);
            this.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            if (this.Entry(entity).State == EntityState.Detached)
            {
                this.Set<T>().Attach(entity);
            }
            this.Set<T>().Remove(entity);
        }

        public void DeleteAndSave<T>(object id) where T : class
        {
            T entity = this.Set<T>().Find(id);
            this.DeleteAndSave<T>(entity);
        }

        public void DeleteAndSave<T>(T entity) where T : class
        {
            this.Delete<T>(entity);
            this.SaveChanges();
        }

        public int DeleteAll<T>(string table, string keyName, int[] keys) where T : class
        {
            return this.Database.ExecuteSqlCommand(DeleteAllQuery(table, keyName, keys));
        }

        private string DeleteAllQuery(string table, string keyName, int[] keys)
        {
            return string.Format("Delete [{0}] WHERE {1} IN ({2})", table, keyName, string.Join(",", keys));
        }

        public int UpdateAll<T>(string table, string keyName, int[] keys, string column, bool value) where T : class
        {
            var coldic = new Dictionary<string, string>();
            coldic.Add(column, value == true ? "1" : "0");
            return this.Database.ExecuteSqlCommand(UpdateAllQuery(table, keyName, keys, coldic));
        }

        public int UpdateAll<T>(string table, string keyName, int[] keys, string column, string value) where T : class
        {
            var coldic = new Dictionary<string, string>();
            coldic.Add(column, value);
            return this.Database.ExecuteSqlCommand(UpdateAllQuery(table, keyName, keys, coldic));
        }

        public int UpdateAll<T>(string table, string keyName, int[] keys, Dictionary<string, string> columnsToUPdate) where T : class
        {
            return this.Database.ExecuteSqlCommand(UpdateAllQuery(table, keyName, keys, columnsToUPdate));
        }

        private string UpdateAllQuery(string table, string keyName, int[] keys, Dictionary<string, string> columnsToUPdate)
        {
            int value;
            var cols = columnsToUPdate.Select(x => string.Format("{0} = {1}", x.Key, int.TryParse(x.Value, out value) ? value.ToString() : "N'" + x.Value + "'"));
            return string.Format("UPDATE {0} SET {1} WHERE  {2} IN ({3})", table, string.Join(",", cols), keyName, string.Join(",", keys));
        }


        public int ExecuteSQL(string sqlStatement)
        {
            return this.ExecuteSQLWithParameters(sqlStatement, null);
        }

        private int ExecuteSQLWithParameters(string sqlStatement, object[] parms)
        {
            return this.Database.ExecuteSqlCommand(sqlStatement, parms);
        }

        public void ExecuteProcedure(string commandText, Dictionary<string, object> parameters)
        {
            var sqlParams = new List<SqlParameter>();
            var cmdText = new System.Text.StringBuilder(commandText);
            foreach (var key in parameters.Keys)
            {
                sqlParams.Add(new SqlParameter() { ParameterName = "@" + key, Value = parameters[key] });
                cmdText.Append(" @" + key + ",");
            }
            this.Database.ExecuteSqlCommand(cmdText.ToString().Substring(0, cmdText.Length - 1), sqlParams.ToArray());
        }


        public void BatchDelete<T>(List<T> list) where T:class 
        {
            if (list.Any())
            {
                foreach (var entity in list)
                    this.Set<T>().Remove(entity);

                this.SaveChanges();
            }
        }

        public void BatctInsert<T>(List<T> list) where T : class
        {
            if (list.Any())
            {
                foreach (var entity in list)
                    this.Set<T>().Add(entity);

                this.SaveChanges();
            }
        }
    }
}
