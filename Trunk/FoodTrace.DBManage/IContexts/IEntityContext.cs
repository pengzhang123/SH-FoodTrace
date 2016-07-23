using FoodTrace.Model;
using System;
using System.Data.Entity;

namespace FoodTrace.DBManage.IContexts
{
    public interface IEntityContext : IDbContext, IDisposable
    {
        #region SystemBase
        /// <summary>
        /// 公司信息
        /// </summary>
        IDbSet<CompanyModel> Company { get; set; }

        /// <summary>
        /// 企业（种植）基地信息
        /// </summary>
        IDbSet<LandBaseModel> LandBase { get; set; }
        /// <summary>
        /// 系统部门信息
        /// </summary>
        IDbSet<DeptModel> Dept { get; set; }

        /// <summary>
        /// 企业资质
        /// </summary>
        IDbSet<QSCardModel> QSCard { get; set; }

        /// <summary>
        /// 人员基本信息
        /// </summary>
        IDbSet<UserBaseModel> UserBase { get; set; }

        /// <summary>
        /// 人员详细信息
        /// </summary>
        IDbSet<UserDetailModel> UserDetail { get; set; }

        /// <summary>
        /// 用户登陆记录
        /// </summary>
        IDbSet<LogUserLoginModel> LogUserLogin { get; set; }

        /// <summary>
        /// 系统角色信息
        /// </summary>
        IDbSet<RoleModel> Role { get; set; }

        /// <summary>
        /// 人员角色关系
        /// </summary>
        IDbSet<UserRoleModel> UserRole { get; set; }

        /// <summary>
        /// 系统菜单信息
        /// </summary>
        IDbSet<MenuModel> Menu { get; set; }

        /// <summary>
        /// 角色和功能菜单索引
        /// </summary>
        IDbSet<RoleMenuModel> RoleMenu { get; set; }

        /// <summary>
        /// 区域信息
        /// </summary>
        IDbSet<AreaModel> Area { get; set; }

        /// <summary>
        /// 系统省份信息
        /// </summary>
        IDbSet<ProvinceModel> Province { get; set; }

        /// <summary>
        /// 系统城市信息
        /// </summary>
        IDbSet<CityModel> City { get; set; }

        /// <summary>
        /// 系统全国区县
        /// </summary>
        IDbSet<CountryModel> Country { get; set; }

        /// <summary>
        /// 字典根信息
        /// </summary>
        IDbSet<DicRootModel> DicRoot { get; set; }

        /// <summary>
        /// 字典节点信息
        /// </summary>
        IDbSet<DicModel> Dic { get; set; }

        /// <summary>
        /// 环县RFID溯源服务平台
        /// </summary>
        IDbSet<AreaPlatModel> AreaPlat { get; set; }

        /// <summary>
        /// 商品/产品基本信息
        /// </summary>
        IDbSet<ProductBaseModel> ProductBase { get; set; }


        /// <summary>
        /// 产品规格信息
        /// </summary>
        IDbSet<ProductSpecModel> ProductSpec { get; set; }


        /// <summary>
        /// 产品型号信息
        /// </summary>
        IDbSet<ProductTypeModel> ProductType { get; set; }

        /// <summary>
        /// 对象规则
        /// </summary>
        IDbSet<CodeObjectModel> CodeObject { get; set; }

        /// <summary>
        /// 最大编号
        /// </summary>
        IDbSet<CodeMaxModel> CodeMax { get; set; }
        /// <summary>
        /// 最大编号
        /// </summary>
        IDbSet<TIDModel> TID { get; set; }

        /// <summary>
        /// 单据规则
        /// </summary>
        IDbSet<CodeOrderModel> CodeOrder { get; set; }
        #endregion

        #region PlansMng

        /// <summary>
        /// 种植企业基地地块
        /// </summary>
        IDbSet<LandBlockModel> LandBlock { get; set; }

        /// <summary>
        /// 种植种子基本信息
        /// </summary>
        IDbSet<SeedBaseModel> SeedBase { get; set; }

        /// <summary>
        /// 批次产品种植计划
        /// </summary>
        IDbSet<PlansBatchModel> PlansBatch { get; set; }

        /// <summary>
        /// 种植用药情况
        /// </summary>
        IDbSet<PlansDrugModel> PlansDrug { get; set; }

        /// <summary>
        /// 种植用药情况（防疫）多图片
        /// </summary>
        IDbSet<PlansDrugPicModel> PlansDrugPic { get; set; }

        /// <summary>
        /// 种植用药情况（防疫）多视频
        /// </summary>
        IDbSet<PlansDrugVideoModel> PlansDrugVideo { get; set; }

        /// <summary>
        /// 种植施肥情况
        /// </summary>
        IDbSet<PlansFertModel> PlansFert { get; set; }

        /// <summary>
        /// 种植施肥情况多图片
        /// </summary>
        IDbSet<PlansFertPicModel> PlansFertPic { get; set; }

        /// <summary>
        /// 种植施肥情况多视频
        /// </summary>
        IDbSet<PlansFertVideoModel> PlansFertVideo { get; set; }

        #endregion

        #region BreedMng
        /// <summary>
        /// 养殖场基本信息
        /// </summary>
        IDbSet<BreedBaseModel> BreedBase { get; set; }
        IDbSet<BreedAreaModel> BreedArea { get; set; }
        IDbSet<BreedBatchDetailModel> BreedBatchDetail { get; set; }
        IDbSet<BreedBatchModel> BreedBatch { get; set; }
        IDbSet<BreedHomeModel> BreedHome { get; set; }
        IDbSet<BreedLogModel> BreedLog { get; set; }
        IDbSet<BreedMaterialPicModel> BreedMaterialPic { get; set; }
        IDbSet<BreedMaterialModel> BreedMaterial { get; set; }
        IDbSet<BreedMaterialVideoModel> BreedMaterialVideo { get; set; }
        IDbSet<BreedDrugModel> BreedDrug { get; set; }
        IDbSet<BreedDrugPicModel> BreedDrugPic { get; set; }
        IDbSet<BreedDrugVideoModel> BreedDrugVideo { get; set; }
        IDbSet<BreedHealthModel> BreedHealth { get; set; }
        IDbSet<BreedHealthPicModel> BreedHealthPic { get; set; }
        IDbSet<BreedHealthVideoModel> BreedHealthVideo { get; set; }
        IDbSet<CultivationBaseModel> CultivationBase { get; set; }
        IDbSet<VarietyBaseModel> VarietyBase { get; set; }
        #endregion

        #region KillMng
        /// <summary>
        /// 屠宰场接收批次信息
        /// </summary>
        IDbSet<KillBatchModel> KillBatch { get; set; }

        /// <summary>
        /// 屠宰场接收批次明细信息
        /// </summary>
        IDbSet<KillBatchDetailModel> KillBatchDetail { get; set; }

        /// <summary>
        /// 待屠宰转换信息
        /// </summary>
        IDbSet<KillCullModel> KillCull { get; set; }

        /// <summary>
        /// 屠宰场检验检疫记录
        /// </summary>
        IDbSet<KillDrugModel> KillDrug { get; set; }

        /// <summary>
        /// 屠宰场检验检疫图片信息
        /// </summary>
        IDbSet<KillDrugPicModel> KillDrugPic { get; set; }

        /// <summary>
        /// 屠宰场检验检疫视频信息
        /// </summary>
        IDbSet<KillDrugVideoModel> KillDrugVideo { get; set; }
        #endregion

        #region ProcessMng
        /// <summary>
        /// 生产加工工序基本信息
        /// </summary>
        IDbSet<ProcessBaseModel> ProcessBase { get; set; }

        /// <summary>
        /// 加工厂接收的加工明细信息
        /// </summary>
        IDbSet<ProcessBatchDetailModel> ProcessBatchDetail { get; set; }

        /// <summary>
        /// 加工厂接收待加工订单信息
        /// </summary>
        IDbSet<ProcessBatchModel> ProcessBatch { get; set; }

        /// <summary>
        /// 加工厂加工产品信息
        /// </summary>
        IDbSet<ProcessProductModel> ProcessProduct { get; set; }

        /// <summary>
        /// 成品皮影加工信息基本
        /// </summary>
        IDbSet<ShadowBaseModel> ShadowBase { get; set; }

        /// <summary>
        /// 皮影加工对应的工序信息
        /// </summary>
        IDbSet<ShadowProcessModel> ShadowProcess { get; set; }
        #endregion

        #region TrunMng
        /// <summary>
        /// 冷链物流车辆信息
        /// </summary>
        IDbSet<TrunVehicleModel> TrunVehicle { get; set; }

        /// <summary>
        /// 冷链物流司机信息
        /// </summary>
        IDbSet<TrunDriverModel> TrunDriver { get; set; }

        /// <summary>
        /// 冷链物流运输订单信息
        /// </summary>
        IDbSet<TrunApplyModel> TrunApply { get; set; }

        /// <summary>
        /// 冷链物流运输物品明细信息
        /// </summary>
        IDbSet<TrunApplyDetailModel> TrunApplyDetail { get; set; }

        /// <summary>
        /// 冷链运输GPS温度采集记录信息
        /// </summary>
        IDbSet<TrunTemperatrueModel> TrunTemperatrue { get; set; }
        #endregion

        #region SaleMng
        IDbSet<WareHouseBaseModel> WareHouseBase { get; set; }
        IDbSet<WareHouseDetailModel> WareHouseDetail { get; set; }
        IDbSet<WareHouseStockModel> WareHouseStock { get; set; }
        IDbSet<SaleBaseModel> SaleBase { get; set; }
        #endregion
    }
}
