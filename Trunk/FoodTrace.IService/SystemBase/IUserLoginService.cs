using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface IUserLoginService
    {
        MessageModel InsertSingleEntity(LogUserLoginModel model);
    }
}
