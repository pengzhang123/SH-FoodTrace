using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    public interface ITrunTemperatrueService
    {
        /// <summary>
        /// 获取TrunTemperatrue总条数
        /// </summary>
        /// <returns></returns>
         int GetTrunTemperatrueCount();

        /// <summary>
        /// 获取当前用户所在公司的冷链运输GPS温度采集记录信息（分页）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<TrunTemperatrueModel> GetPagerTrunTemperatrue(int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取TrunTemperatrue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         TrunTemperatrueModel GetTrunTemperatrueById(int id);

        /// <summary>
        /// 新增单条TrunTemperatrue
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
         MessageModel InsertSingleTrunTemperatrue(TrunTemperatrueModel model);

        /// <summary>
        /// 编辑单条TrunTemperatrue
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
         MessageModel UpdateSingleTrunTemperatrue(TrunTemperatrueModel model);

        /// <summary>
        /// 删除单条TrunTemperatrue
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
         MessageModel DeleteSingleTrunTemperatrue(int id);
    }
}
