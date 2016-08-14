using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodTrace.Common;
using FoodTrace.Model;
using FoodTrace.Model.WinCeModel;
using FoodTrace.Service.WinCe;

namespace FoodTrace.WebAPI.Controllers
{
    public class WinceDicController : ApiController
    {

        [HttpPost]
        public string WinceUserLogin([FromBody]WinceUser model)
        {
            string username = string.Empty;
            try
            {
                 var winceSer = new WinceDicService();
                var pwd = EncodeStrToMd5.String32ToMD5(model.PassWord);

                username = winceSer.WinceUserLogin(model.UserName, pwd);

            }
            catch
            {
            }

            return username;
        }

        #region 养殖防疫
        /// <summary>
        /// 获取养殖防疫数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DicDto> GetBreedDrugDic()
        {
            var winceSer = new WinceDicService();

            var list = winceSer.GetDrugDicList();
            return list;
        }

        /// <summary>
        /// 保存养殖防疫数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string SaveBreedDrugData([FromBody]BredDrug model)
        {
            string issuccess = "false";
            try
            {
                var winceSer = new WinceDicService();
                winceSer.SaveBredDrugData(model);
                issuccess = "true";
            }
            catch (Exception ex)
            {
             
            }

            return issuccess;
        }
        #endregion

        #region 养殖健康
        /// <summary>
        /// 养殖健康
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetBreedHealthDicList()
        {
            var winceSer = new WinceDicService();

            var list = winceSer.GetBreedHealthDicList();
            return list;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string SaveBreedHealthData([FromBody]BreedHealth model)
        {
            string issuccess = "false";
            try
            {
                var winceSer = new WinceDicService();
                winceSer.SaveBreedHealthData(model);
                issuccess = "true";
            }
            catch (Exception ex)
            {

            }

            return issuccess;
        }
        #endregion

        #region 养殖用料
        /// <summary>
        /// 养殖用料
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetBreedMaterialDic()
        {
            var winceSer = new WinceDicService();

            var list = winceSer.GetBreedMaterialDic();
            return list;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string SaveBreedMaterialData([FromBody]BreedMaterial model)
        {
            string issuccess = "false";
            try
            {
                var winceSer = new WinceDicService();
                winceSer.SaveBreedMaterialData(model);
                issuccess = "true";
            }
            catch (Exception ex)
            {

            }

            return issuccess;
        }
        #endregion
    }

}
