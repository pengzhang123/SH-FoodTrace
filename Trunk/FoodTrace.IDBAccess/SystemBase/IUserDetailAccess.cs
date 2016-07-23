using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IUserDetailAccess //: IBaseAccess<UserDetailModel>
    {
        UserDetailModel GetEntityById(int id);

        MessageModel InsertSingleEntity(UserDetailModel model);

        MessageModel UpdateSingleEntity(UserDetailModel model);

        MessageModel DeleteSingleEntity(int id);
    }
}
