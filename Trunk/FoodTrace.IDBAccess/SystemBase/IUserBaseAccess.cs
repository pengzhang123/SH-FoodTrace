using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface IUserBaseAccess : IBaseAccess<UserBaseModel>
    {
        int GetEntityCount(int companyID, string name);
        UserBaseModel GetUserBase(string name, string password);
        MessageModel InsertSingleEntity(UserBaseModel userBaseModel, UserDetailModel userDetailModel, List<int> roleModel);
        List<UserBaseModel> GetPagerUserBaseByConditions(int companyID, string name, int pageIndex, int pageSize);
    }
}
