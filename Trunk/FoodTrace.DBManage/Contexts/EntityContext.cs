using System.ComponentModel.DataAnnotations.Schema;
using FoodTrace.DBManage.IContexts;
using FoodTrace.Model;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using FoodTrace.Model.BreedMng;

namespace FoodTrace.DBManage.Contexts
{
    public class EntityContext : ExtendedDbContext, IEntityContext
    {
        ObjectContext objectContext = null;
        public EntityContext()
        {
            objectContext = (this as IObjectContextAdapter).ObjectContext;
            //设置Timeout，否则数据量大会抛异常
            objectContext.CommandTimeout = 520;
        }

        public EntityContext(string connectionString) : base(connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer<EntityContext>(null);
            this.Configuration.LazyLoadingEnabled = true;
        }

        public EntityContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            //objectContext = (this as IObjectContextAdapter).ObjectContext;
            //设置Timeout，否则数据量大会抛异常
            //objectContext.CommandTimeout = 520;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBaseModel>()
                .Property(x => x.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }

        #region SystemBase
        /// <summary>
        /// 公司信息
        /// </summary>
        public IDbSet<CompanyModel> Company { get; set; }

        /// <summary>
        /// 企业（种植）基地信息
        /// </summary>
        public IDbSet<LandBaseModel> LandBase { get; set; }
        /// <summary>
        /// 系统部门信息
        /// </summary>
        public IDbSet<DeptModel> Dept { get; set; }

        /// <summary>
        /// 企业资质
        /// </summary>
        public IDbSet<QSCardModel> QSCard { get; set; }

        /// <summary>
        /// 人员基本信息
        /// </summary>
        public IDbSet<UserBaseModel> UserBase { get; set; }

        /// <summary>
        /// 人员详细信息
        /// </summary>
        public IDbSet<UserDetailModel> UserDetail { get; set; }

        /// <summary>
        /// 用户登陆记录
        /// </summary>
        public IDbSet<LogUserLoginModel> LogUserLogin { get; set; }

        /// <summary>
        /// 系统角色信息
        /// </summary>
        public IDbSet<RoleModel> Role { get; set; }

        /// <summary>
        /// 人员角色关系
        /// </summary>
        public IDbSet<UserRoleModel> UserRole { get; set; }

        /// <summary>
        /// 系统菜单信息
        /// </summary>
        public IDbSet<MenuModel> Menu { get; set; }

        /// <summary>
        /// 角色和功能菜单索引
        /// </summary>
        public IDbSet<RoleMenuModel> RoleMenu { get; set; }

        /// <summary>
        /// 区域信息
        /// </summary>
        public IDbSet<AreaModel> Area { get; set; }
        /// <summary>
        /// 区域信息
        /// </summary>
        public IDbSet<TIDModel> TID { get; set; }

        /// <summary>
        /// 系统省份信息
        /// </summary>
        public IDbSet<ProvinceModel> Province { get; set; }

        /// <summary>
        /// 系统城市信息
        /// </summary>
        public IDbSet<CityModel> City { get; set; }

        /// <summary>
        /// 系统全国区县
        /// </summary>
        public IDbSet<CountryModel> Country { get; set; }

        /// <summary>
        /// 字典根信息
        /// </summary>
        public IDbSet<DicRootModel> DicRoot { get; set; }

        /// <summary>
        /// 字典节点信息
        /// </summary>
        public IDbSet<DicModel> Dic { get; set; }

        /// <summary>
        /// 环县RFID溯源服务平台
        /// </summary>
        public IDbSet<AreaPlatModel> AreaPlat { get; set; }


        /// <summary>
        /// 商品/产品基本信息
        /// </summary>
        public IDbSet<ProductBaseModel> ProductBase { get; set; }


        /// <summary>
        /// 产品规格信息
        /// </summary>
        public IDbSet<ProductSpecModel> ProductSpec { get; set; }


        /// <summary>
        /// 产品型号信息
        /// </summary>
        public IDbSet<ProductTypeModel> ProductType { get; set; }

        /// <summary>
        /// 对象规则
        /// </summary>
        public IDbSet<CodeObjectModel> CodeObject { get; set; }

        /// <summary>
        /// 最大编号
        /// </summary>
        public IDbSet<CodeMaxModel> CodeMax { get; set; }

        /// <summary>
        /// 单据规则
        /// </summary>
        public IDbSet<CodeOrderModel> CodeOrder { get; set; }

        #endregion

        #region PlansMng
        /// <summary>
        /// 种植企业基地地块
        /// </summary>
        public IDbSet<LandBlockModel> LandBlock { get; set; }

        /// <summary>
        /// 种植种子基本信息
        /// </summary>
        public IDbSet<SeedBaseModel> SeedBase { get; set; }

        /// <summary>
        /// 批次产品种植计划
        /// </summary>
        public IDbSet<PlansBatchModel> PlansBatch { get; set; }

        /// <summary>
        /// 种植用药情况
        /// </summary>
        public IDbSet<PlansDrugModel> PlansDrug { get; set; }

        /// <summary>
        /// 种植用药情况（防疫）多图片
        /// </summary>
        public IDbSet<PlansDrugPicModel> PlansDrugPic { get; set; }

        /// <summary>
        /// 种植用药情况（防疫）多视频
        /// </summary>
        public IDbSet<PlansDrugVideoModel> PlansDrugVideo { get; set; }

        /// <summary>
        /// 种植施肥情况
        /// </summary>
        public IDbSet<PlansFertModel> PlansFert { get; set; }

        /// <summary>
        /// 种植施肥情况多图片
        /// </summary>
        public IDbSet<PlansFertPicModel> PlansFertPic { get; set; }

        /// <summary>
        /// 种植施肥情况多视频
        /// </summary>
        public IDbSet<PlansFertVideoModel> PlansFertVideo { get; set; }
        #endregion

        #region BreedMng
        /// <summary>
        /// 养殖场基本信息
        /// </summary>
        public IDbSet<BreedBaseModel> BreedBase { get; set; }
        public IDbSet<BreedAreaModel> BreedArea { get; set; }
        public IDbSet<BreedVarietyModel> BreedVariety { get; set; }
        public IDbSet<BreedBatchDetailModel> BreedBatchDetail { get; set; }
        public IDbSet<BreedBatchModel> BreedBatch { get; set; }
        public IDbSet<BreedHomeModel> BreedHome { get; set; }
        public IDbSet<BreedLogModel> BreedLog { get; set; }
        public IDbSet<BreedMaterialPicModel> BreedMaterialPic { get; set; }
        public IDbSet<BreedMaterialModel> BreedMaterial { get; set; }
        public IDbSet<BreedMaterialVideoModel> BreedMaterialVideo { get; set; }
        public IDbSet<BreedDrugModel> BreedDrug { get; set; }
        public IDbSet<BreedDrugPicModel> BreedDrugPic { get; set; }
        public IDbSet<BreedDrugVideoModel> BreedDrugVideo { get; set; }
        public IDbSet<BreedHealthModel> BreedHealth { get; set; }
        public IDbSet<BreedHealthPicModel> BreedHealthPic { get; set; }
        public IDbSet<BreedHealthVideoModel> BreedHealthVideo { get; set; }
        public IDbSet<CultivationBaseModel> CultivationBase { get; set; }
        public IDbSet<VarietyBaseModel> VarietyBase { get; set; }

        #endregion

        #region KillMng
        /// <summary>
        /// 屠宰场接收批次信息
        /// </summary>
        public IDbSet<KillBatchModel> KillBatch { get; set; }

        /// <summary>
        /// 屠宰场接收批次明细信息
        /// </summary>
        public IDbSet<KillBatchDetailModel> KillBatchDetail { get; set; }

        /// <summary>
        /// 待屠宰转换信息
        /// </summary>
        public IDbSet<KillCullModel> KillCull { get; set; }

        /// <summary>
        /// 屠宰场检验检疫记录
        /// </summary>
        public IDbSet<KillDrugModel> KillDrug { get; set; }

        /// <summary>
        /// 屠宰场检验检疫图片信息
        /// </summary>
        public IDbSet<KillDrugPicModel> KillDrugPic { get; set; }

        /// <summary>
        /// 屠宰场检验检疫视频信息
        /// </summary>
        public IDbSet<KillDrugVideoModel> KillDrugVideo { get; set; }
        #endregion

        #region ProcessMng
        /// <summary>
        /// 生产加工工序基本信息
        /// </summary>
        public IDbSet<ProcessBaseModel> ProcessBase { get; set; }

        /// <summary>
        /// 加工厂接收的加工明细信息
        /// </summary>
        public IDbSet<ProcessBatchDetailModel> ProcessBatchDetail { get; set; }

        /// <summary>
        /// 加工厂接收待加工订单信息
        /// </summary>
        public IDbSet<ProcessBatchModel> ProcessBatch { get; set; }

        /// <summary>
        /// 加工厂加工产品信息
        /// </summary>
        public IDbSet<ProcessProductModel> ProcessProduct { get; set; }

        /// <summary>
        /// 成品皮影加工信息基本
        /// </summary>
        public IDbSet<ShadowBaseModel> ShadowBase { get; set; }

        /// <summary>
        /// 皮影加工对应的工序信息
        /// </summary>
        public IDbSet<ShadowProcessModel> ShadowProcess { get; set; }
        #endregion

        #region TrunMng
        /// <summary>
        /// 冷链物流车辆信息
        /// </summary>
        public IDbSet<TrunVehicleModel> TrunVehicle { get; set; }

        /// <summary>
        /// 冷链物流司机信息
        /// </summary>
        public IDbSet<TrunDriverModel> TrunDriver { get; set; }

        /// <summary>
        /// 冷链物流运输订单信息
        /// </summary>
        public IDbSet<TrunApplyModel> TrunApply { get; set; }

        /// <summary>
        /// 冷链物流运输物品明细信息
        /// </summary>
        public IDbSet<TrunApplyDetailModel> TrunApplyDetail { get; set; }

        /// <summary>
        /// 冷链运输GPS温度采集记录信息
        /// </summary>
        public IDbSet<TrunTemperatrueModel> TrunTemperatrue { get; set; }
        #endregion

        #region SaleMng
        public IDbSet<WareHouseBaseModel> WareHouseBase { get; set; }
        public IDbSet<WareHouseDetailModel> WareHouseDetail { get; set; }
        public IDbSet<WareHouseStockModel> WareHouseStock { get; set; }
        public IDbSet<SaleBaseModel> SaleBase { get; set; }
        #endregion
    }
}
