using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    public class BaseModel
    {
        public int? ModifyID { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }

    public class BasePicModel : BaseModel
    {
        public string Pic { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }

    public class BaseVideoModel : BaseModel
    {
        public string Video { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }

    public enum AccessMappingKey
    {
        #region SystemBase
        CompanyAccess,
        LandBaseAccess,
        DeptAccess,
        TidAccess,
        QSCardAccess,
        UserBaseAccess,
        RoleAccess,
        MenuAccess,
        AreaAccess,
        AreaPlatAccess,
        ProvinceAccess,
        CityAccess,
        CountryAccess,
        UserLoginAccess,
        UserDetailAccess,
        UserRoleAccess,
        DicAccess,
        ProductBaseAccess,
        ProductSpecAccess,
        ProductTypeAccess,
        CodeOrderAccess,
        CodeMaxAccess,
        CodeObjectAccess,
        #endregion

        #region PlansMng
        LandBlockAccess,
        SeedBaseAccess,
        PlansBatchAccess,
        PlansDrugAccess,
        PlansFertAccess,
        #endregion

        #region BreedMng
        CultivationBaseAccess,
        BreedBaseAccess,
        BreedAreaAccess,
        BreedHomeAccess,
        BreedBatchDetailAccess,
        BreedBatchAccess,
        BreedDrugAccess,
        BreedDrugPicAccess,
        BreedDrugVideoAccess,
        BreedHealthAccess,
        BreedHealthPicAccess,
        BreedHealthVideoAccess,
        BreedLogAccess,
        BreedMaterialAccess,
        BreedMaterialPicAccess,
        BreedMaterialVideoAccess,
        VarietyBaseAccess,
        #endregion

        #region KillMng
        KillBatchAccess,
        KillBatchDetailAccess,
        KillCullAccess,
        KillDrugAccess,
        #endregion

        #region TrunMng
        TrunVehicleAccess,
        TrunTemperatrueAccess,
        TrunDriverAccess,
        TrunApplyDetailAccess,
        TrunApplyAccess,
        #endregion

        #region SalesMng
        WareHouseBaseAccess,
        WareHouseDetailAccess,
        WareHouseStockAccess,
        SaleBaseAccess,
        #endregion

        #region ProcessMng
        ProcessBaseAccess,
        ProcessBatchDetailAccess,
        ProcessBatchAccess,
        ProcessProductAccess,
        ShadowBaseAccess,
        ShadowProcessAccess
        #endregion
    }
}
