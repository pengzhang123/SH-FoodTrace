using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    public class TidService : BaseService, ITidService
    {
        private ITidAccess tidAccess;

        public TidService()
        {
            tidAccess = BaseAccess.CreateAccess<ITidAccess>(AccessMappingKey.TidAccess.ToString());
        }

        /// <summary>
        /// 获取Tid总条数
        /// </summary>
        /// <returns></returns>
        public int GetTidCount()
        {
            return tidAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取Tid总条数
        /// </summary>
        /// <param name="name">查询条件：菜单名称（模糊查询）</param>
        /// <returns></returns>
        public int GetTidCount(string name)
        {
            return tidAccess.GetEntityCount(name.Trim());
        }

        /// <summary>
        /// 获取区域信息（分页）
        /// </summary>
        /// <param name="name">查询条件：区域名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<TIDModel> GetPagerTid(int pageIndex, int pageSize)
        {
            return tidAccess.GetPagerTidByConditions(pageIndex, pageSize);
        }

        /// <summary>
        /// 通过ID获取Tid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TIDModel GetTidById(int id)
        {
            return tidAccess.GetEntityById(id);
        }

        /// <summary>
        /// 通过ID获取Tid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TIDModel GetTidByChipCode(string code)
        {
            return tidAccess.GetEntityByChipCode(code);
        }

        public TIDModel GetTidChipCode(string code)
        {
            TidAccess access = new TidAccess();
            return access.GetEntityByChipCode(code);
        }

        /// <summary>
        /// 新增单条Tid
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSingleTid(TIDModel model)
        {
            return tidAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条Tid
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSingleTid(TIDModel model)
        {
            return tidAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条Tid
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSingleTid(int id)
        {
            return tidAccess.DeleteSingleEntity(id);
        }

    }
}
