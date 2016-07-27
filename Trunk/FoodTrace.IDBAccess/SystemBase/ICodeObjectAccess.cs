﻿using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IDBAccess
{
    public interface ICodeObjectAccess : IBaseAccess<CodeObjectModel>
    {
        int GetEntityCount(string name);

        List<CodeObjectModel> GetPagerCodeObjectByConditions(string name, int pageIndex, int pageSize);
    }
}