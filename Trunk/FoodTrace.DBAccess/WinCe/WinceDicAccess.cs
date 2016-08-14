using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using FoodTrace.Model.WinCeModel;

namespace FoodTrace.DBAccess
{
    public class WinceDicAccess : BaseAccess,IWinceDicAccess
    {
        /// <summary>
        /// wince用户登录返回用户中文吗
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string WinceUserLogin(string username,string pwd)
        {
            var user = Context.UserBase.Where(s => s.UserCode == username && s.Password == pwd).FirstOrDefault();
            if (user != null)
            {
                return user.UserName;
            }
            return string.Empty;
        }
        #region 养殖防疫
        /// <summary>
        /// 养殖防疫窗口下拉
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetDrugDicList()
        {
            var list = new List<DicDto>();

            //用药方法
            var drugMethod = GetDicDtoListByType("DrugMethod");
            if (drugMethod.Any())
            {
                list.AddRange(drugMethod);
            }

            //防治对象
            var drugObject = GetDicDtoListByType("DrugObject");
            if (drugObject.Any())
            {
                list.AddRange(drugObject);
            }

            //病虫害类型
            var drugInsect = GetDicDtoListByType("DrugInsect");
            if (drugInsect.Any())
            {
                list.AddRange(drugInsect);
            }

            //用药名称
            var drug = GetDicDtoListByType("Drug");
            if (drug.Any())
            {
                list.AddRange(drug);
            }
            //天气
            var weather = GetDicDtoListByType("Weather");
            if (weather.Any())
            {
                list.AddRange(weather);
            }

            return list;
        }

        /// <summary>
        /// 保存养殖防疫数据
        /// </summary>
        /// <param name="model"></param>
        public void SaveBredDrugData(BredDrug model)
        {
            var productBase = GetProProductByEpc(model.Epc);
            if (productBase != null)
            {
                var cultivationId = GetCultivationId(productBase.ProcessEPC);

                if (cultivationId != 0)
                {
                    var drugModel = new BreedDrugModel();
                    drugModel.CultivationEpc = model.Epc;
                    drugModel.CultivationID = cultivationId;
                    drugModel.Dilution = model.Dilute;
                    drugModel.People = "于硕";
                    drugModel.Method = model.DrugMethod;
                    drugModel.Problem = model.DrugInsect;
                    drugModel.Object = model.DrugObject;
                    drugModel.DrugCon =int.Parse(model.Dosage);
                    drugModel.DrugTime = DateTime.Now;
                    drugModel.Weather = model.Weather;

                    Context.BreedDrug.Add(drugModel);
                    Context.SaveChanges();
                }

            }

        }
        #endregion

        #region 养殖健康健康
        /// <summary>
        /// 获取养殖健康
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetBreedHealthDicList()
        {
            var list = new List<DicDto>();

            //天气
            var weather = GetDicDtoListByType("Weather");
            if (weather.Any())
            {
                list.AddRange(weather);
            }

            //健康状况
            var health = GetDicDtoListByType("Health");
            if (health.Any())
            {
                list.AddRange(health);
            }

            return list;
        }

        /// <summary>
        /// 保存健康状况
        /// </summary>
        /// <param name="model"></param>
        public void SaveBreedHealthData(BreedHealth model)
        {
            var productBase = GetProProductByEpc(model.Epc);
            if (productBase != null)
            {
                var cultivationId = GetCultivationId(productBase.ProcessEPC);

                if (cultivationId != 0)
                {
                    var healthModel = new BreedHealthModel();

                    healthModel.CultivationEpc = model.Epc;
                    healthModel.CultivationID = cultivationId;
                    healthModel.HealthState = model.Health;
                    healthModel.Weather = model.Weather;
                    healthModel.People = "text";
                    healthModel.CheckTime = DateTime.Now;

                    Context.BreedHealth.Add(healthModel);
                    Context.SaveChanges();
                }

            }
            
        }
        #endregion

        #region 养殖用料
        /// <summary>
        /// 养殖用料
        /// </summary>
        /// <returns></returns>
        public List<DicDto> GetBreedMaterialDic()
        {
            var list = new List<DicDto>();
            
            //用料种类
            var materialType = GetDicDtoListByType("MaterialType");
            if (materialType.Any())
            {
                list.AddRange(materialType);
            }
            
            //用料名称
            var materialName = GetDicDtoListByType("MaterialName");
            if (materialName.Any())
            {
                list.AddRange(materialName);
            }

            //用料方法
            var materalMethod = GetDicDtoListByType("MaterialMethod");
            if (materalMethod.Any())
            {
                list.AddRange(materalMethod);
            }

            //天气
            var weather = GetDicDtoListByType("Weather");
            if (weather.Any())
            {
                list.AddRange(weather);
            }

            return list;
        }

        /// <summary>
        /// 保存用料数据
        /// </summary>
        /// <param name="model"></param>
        public void SaveBreedMaterialData(BreedMaterial model)
        {
            var productBase = GetProProductByEpc(model.Epc);
            if (productBase != null)
            {
                var cultivationId = GetCultivationId(productBase.ProcessEPC);

                if (cultivationId != 0)
                {
                    var material = new BreedMaterialModel();

                    material.CultivationEpc = model.Epc;
                    material.CultivationID = cultivationId;
                    material.MaterialType = model.MaterialType;
                    material.Weather = model.Weather;
                    material.MaterialName = model.MaterialName;
                    material.Method = model.MaterialMethod;
                    material.MaterialCot =int.Parse(model.MaterialCot);
                    material.MaterialTime = DateTime.Now;

                    Context.BreedMaterial.Add(material);
                    Context.SaveChanges();
                }

            }
        }
        #endregion
        /// <summary>
        /// 获取生物编号
        /// </summary>
        /// <param name="epcId"></param>
        /// <returns></returns>
        private int GetCultivationId(string epcId)
        {
            var cultivationId = (from c in Context.CultivationBase
                                 join kill in Context.KillCull on c.CultivationEpc equals kill.CultivationEpc
                                 where kill.KillEpc == epcId
                                 select c.CultivationID
                                ).FirstOrDefault();

            return cultivationId;
        }
        /// <summary>
        /// 根据编码获取字典列表
        /// </summary>
        /// <param name="dicCode"></param>
        /// <returns></returns>
        private List<DicDto> GetDicDtoListByType(string dicCode)
        {
            var list = (from s in Context.Dic
                        where s.Code == dicCode && s.RootID>0
                        select new DicDto()
                        {
                            Id = s.DicID.ToString(),
                            Name = s.Name,
                            Type = dicCode
                        }).ToList();

            return list;
        }
        private ProcessProductModel GetProProductByEpc(string epc)
        {
            var query = Context.ProcessProduct.AsQueryable();
            if (!string.IsNullOrEmpty(epc))
            {
                query = query.Where(s => s.ChipCode == epc);
            }
            return query.FirstOrDefault();
        }
    }
}
