using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IDBAccess.SystemBase;
using FoodTrace.IService.SystemBase;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service.SystemBase
{
    public class QSCardService:BaseService,IQSCardService
    {
         private IQSCardAccess _qsCardAccess;

         public QSCardService()
        {
            _qsCardAccess = BaseAccess.CreateAccess<IQSCardAccess>(AccessMappingKey.QSCardAccess.ToString());
        }

        public List<QsCardDto> GetQsCardListByComId(int comid)
        {
            return _qsCardAccess.GetQsCardListByComId(comid);
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
         public GridList<QsCardDto> GetQsCardPagingList(string name, int pIndex, int pSize)
        {
            return _qsCardAccess.GetQsCardPagingList(name, pIndex, pSize);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        public MessageModel InsertQSCard(QSCardModel model)
        {
            return _qsCardAccess.InsertQSCard(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageModel UpdateQSCard(QSCardModel model)
        {
            return _qsCardAccess.UpdateQSCard(model);
        }


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return _qsCardAccess.DeleteByIds(ids);
        }


        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  QSCardModel GetQsCardById(int id)
        {
            return _qsCardAccess.GetQsCardById(id);
        }
    }
}
