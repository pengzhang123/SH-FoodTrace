using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ITrunDriverService
    {
        /// <summary>
        /// 获取TrunDriver总条数
        /// </summary>
        /// <returns></returns>
        int GetTrunDriverCount();

        /// <summary>
        /// 获取TrunDriver总条数
        /// </summary>
        /// <param name="carNo">查询条件：司机名称（模糊查询）</param>
        /// <returns></returns>
        int GetTrunDriverCount(string name);

        /// <summary>
        /// 获取当前用户所在公司的冷链物流司机信息（分页）
        /// </summary>
        /// <param name="carNo">查询条件：司机名称（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<TrunDriverModel> GetPagerTrunDriver(string name, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取TrunDriver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TrunDriverModel GetTrunDriverById(int id);

        /// <summary>
        /// 新增单条TrunDriver
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleTrunDriver(TrunDriverModel model);

        /// <summary>
        /// 编辑单条TrunDriver
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleTrunDriver(TrunDriverModel model);

        /// <summary>
        /// 删除单条TrunDriver
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleTrunDriver(int id);
    }
}
