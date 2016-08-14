using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService.WinCe;
using FoodTrace.Model;
using FoodTrace.Model.WinCeModel;

namespace FoodTrace.Service.WinCe
{
    public class WinceDicService : BaseService,IWinceDicService
    {
         private IWinceDicAccess _winceDicAccess;

         public WinceDicService()
        {
            _winceDicAccess = BaseAccess.CreateAccess<IWinceDicAccess>(AccessMappingKey.WinceDicAccess.ToString());
        }

        /// <summary>
        /// wince用户登录返回用户中文吗
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string WinceUserLogin(string username, string pwd)
        {
            return _winceDicAccess.WinceUserLogin(username, pwd);
        }
         #region 养殖防疫
         /// <summary>
        /// 获取用药信息下拉
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetDrugDicList()
        {
            return _winceDicAccess.GetDrugDicList();
        }

        /// <summary>
        /// 保存养殖防疫数据
        /// </summary>
        /// <param name="model"></param>
        public void SaveBredDrugData(BredDrug model)
        {
            _winceDicAccess.SaveBredDrugData(model);
        }
       #endregion

        #region 养殖健康
        /// <summary>
        /// 获取养殖健康
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetBreedHealthDicList()
        {
            return _winceDicAccess.GetBreedHealthDicList();
        }

        /// <summary>
        /// 保存健康状况
        /// </summary>
        /// <param name="model"></param>
        public void SaveBreedHealthData(BreedHealth model)
        {
            _winceDicAccess.SaveBreedHealthData(model);
        }

        #endregion

        #region 养殖用料
        /// <summary>
        /// 养殖用料下拉
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetBreedMaterialDic()
        {
            return _winceDicAccess.GetBreedMaterialDic();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        public void SaveBreedMaterialData(BreedMaterial model)
        {
            _winceDicAccess.SaveBreedMaterialData(model);
        }
        #endregion
    }
}
