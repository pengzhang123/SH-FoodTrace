using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IBaseAccess<TEntity> where TEntity : class
    {

        int GetEntityCount();

        List<TEntity> GetAllEntities();

        TEntity GetEntityById(int id);

        MessageModel InsertSingleEntity(TEntity model);

        TEntity GetOriEntity(int id, DateTime? modifyTime);

        MessageModel UpdateSingleEntity(TEntity model);

        MessageModel DeleteSingleEntity(int id);
    }
}
