using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.IService.SystemBase
{
    public interface IQSCardService
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        GridList<QsCardDto> GetQsCardPagingList(string name, int pIndex, int pSize);


        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        MessageModel InsertQSCard(QSCardModel model);


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageModel UpdateQSCard(QSCardModel model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        MessageModel DeleteByIds(string ids);


        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        QSCardModel GetQsCardById(int id);
    }
}
