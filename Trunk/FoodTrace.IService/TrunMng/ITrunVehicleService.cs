using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ITrunVehicleService
    {
        /// <summary>
        /// 获取TrunVehicle总条数
        /// </summary>
        /// <returns></returns>
        int GetTrunVehicleCount();

        /// <summary>
        /// 获取TrunVehicle总条数
        /// </summary>
        /// <param name="carNo">查询条件：车牌号（模糊查询）</param>
        /// <returns></returns>
        int GetTrunVehicleCount(string carNo);

        /// <summary>
        /// 获取当前用户所在公司的冷链物流车辆信息（分页）
        /// </summary>
        /// <param name="carNo">查询条件：车牌号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<TrunVehicleModel> GetPagerTrunVehicle(string carNo, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取TrunVehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TrunVehicleModel GetTrunVehicleById(int id);

        /// <summary>
        /// 新增单条TrunVehicle
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleTrunVehicle(TrunVehicleModel model);

        /// <summary>
        /// 编辑单条TrunVehicle
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleTrunVehicle(TrunVehicleModel model);

        /// <summary>
        /// 删除单条TrunVehicle
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleTrunVehicle(int id);
    }
}
