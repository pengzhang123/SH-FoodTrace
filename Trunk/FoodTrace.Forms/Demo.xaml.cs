using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoodTrace.Forms
{
    /// <summary>
    /// Demo.xaml 的交互逻辑
    /// </summary>
    public partial class Demo : Window
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            #region SystemBase
            #region Company MNG
            //AddCompany();
            //UpdateCompany();
            //DeleteCompany();
            //ICompanyService cs = new CompanyService();
            //var result = cs.GetPagerCompany(string.Empty, 1, 10);
            #endregion

            #region LandBase MNG

            //AddLandBase();
            //UpdateLandBase();
            //DeleteLandBase();
            //ILandBaseService cs = new LandBaseService();
            //var result = cs.GetPagerLandBase(string.Empty, 1, 10);

            #endregion

            #region Dept MNG
            //AddDept();
            //UpdateDept();
            //IDeptService cs = new DeptService();
            //var result = cs.GetPagerDept(string.Empty, 1, 10);
            //DeleteDept();
            #endregion

            #region UserBase MNG
            //AddUserBase();
            //UpdateUserBase();
            //IUserBaseService cs = new UserBaseService();
            //var result = cs.GetPagerUserBase(string.Empty, 1, 10);
            //DeleteUserBase();
            #endregion

            #region Role MNG
            //AddRole();
            //UpdateRole();
            //IRoleService cs = new RoleService();
            //var result = cs.GetPagerRole(string.Empty, 1, 10);
            //DeleteRole();
            #endregion

            #region Menu MNG
            //AddMenu();
            //UpdateMenu();
            //IMenuService cs = new MenuService();
            //var result = cs.GetPagerMenu(string.Empty, 1, 10);
            //DeleteMenu();
            #endregion

            #region Area MNG
            //AddArea();
            //UpdateArea();
            //IAreaService cs = new AreaService();
            //var result = cs.GetPagerArea(string.Empty, 1, 10);
            //DeleteArea();
            #endregion

            #region Province MNG
            //AddProvince();
            //UpdateProvince();
            //IProvinceService cs = new ProvinceService();
            //var result = cs.GetPagerProvince(1, string.Empty, 1, 10);
            //DeleteProvince();
            #endregion

            #region City MNG
            //AddCity();
            //UpdateCity();
            //ICityService cs = new CityService();
            //var result = cs.GetPagerCity(1, string.Empty, 1, 10);
            //DeleteCity();
            #endregion

            #region Country MNG
            //AddCountry();
            //UpdateCountry();
            //ICountryService cs1 = new CountryService();
            //var result1 = cs1.GetPagerCountry(1, string.Empty, 1, 10);
            //DeleteCountry();
            #endregion
            #endregion

            #region PlansMng
            #region LandBlock MNG

            //AddLandBlock();
            //UpdateLandBlock();
            //DeleteLandBlock();
            //ILandBlockService cs = new LandBlockService();
            //var result = cs.GetPagerLandBlock(string.Empty, 1, 10);

            #endregion

            #region SeedBase MNG

            //AddSeedBase();
            //UpdateSeedBase();
            //DeleteSeedBase();
            //ISeedBaseService cs = new SeedBaseService();
            //var result = cs.GetPagerSeedBase(string.Empty, 1, 10);

            #endregion

            #region PlansBatch MNG

            //AddPlansBatch();
            //UpdatePlansBatch();
            //DeletePlansBatch();
            //IPlansBatchService cs = new PlansBatchService();
            //var result = cs.GetPagerPlansBatch(string.Empty, 1, 10);

            #endregion

            #region PlansDrug MNG

            //AddPlansDrug();
            //UpdatePlansDrug();
            //DeletePlansDrug();
            //IPlansDrugService cs = new PlansDrugService();
            //var result = cs.GetPagerPlansDrug(string.Empty, 1, 10);

            #endregion

            #region PlansFert MNG

            //AddPlansFert();
            //UpdatePlansFert();
            //DeletePlansFert();
            //IPlansFertService cs = new PlansFertService();
            //var result = cs.GetPagerPlansFert(string.Empty, 1, 10);

            #endregion
            #endregion

            #region KillMng

            #region KillCull
            //AddKillCull();
            //UpdateKillCull();
            //DeleteKillCull();
            //IKillCullService cs = new KillCullService();
            //var result = cs.GetPagerKillCull(1, 10);
            #endregion

            #region KillDrug
            //AddKillDrug();
            //UpdateKillDrug();
            //IKillDrugService cs = new KillDrugService();
            //var result = cs.GetPagerKillDrug(string.Empty, 1, 10);
            //DeleteKillDrug();
            #endregion

            #region KillBatch
            //AddKillBatch();
            //UpdateKillBatch();
            IKillBatchService cs = new KillBatchService();
            //var result = cs.GetPagerKillBatch(string.Empty, 1, 10);
            var result1 = cs.GetKillBatchById(2);
            //DeleteKillBatch();
            #endregion

            #region KillBatchDetail
            //AddKillBatchDetail();
            //UpdateKillBatchDetail();
            //IKillBatchDetailService cs = new KillBatchDetailService();
            //var result = cs.GetPagerKillBatchDetail(string.Empty, 1, 10);
            //DeleteKillBatchDetail();
            #endregion

            #endregion
            Common.Log.Logger.Error("test");
        }
        #region SystemBase
        #region Company MNG

        private void AddCompany()
        {
            CompanyModel data = new CompanyModel();
            data.CompanyName = "test";
            data.AreaCode = "test";
            data.Address = "test";
            data.Leader = "test";
            data.Logo = "test";
            data.OrgID = "test";
            data.QsCode = "test";
            data.Location = "test";
            data.Code = "test";
            data.ZipCode = "test";
            data.TaxCard = "test";
            data.Fax = "test";
            data.Mobile = "test";
            data.Email = "test";
            data.Info = "test";
            data.Demand = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            ICompanyService cs = new CompanyService();
            var result = cs.InsertSingleCompany(data);
        }

        private void UpdateCompany()
        {
            ICompanyService cs = new CompanyService();
            var data = cs.GetCompanyById(3);
            var result = cs.UpdateSingleCompany(data);
        }

        private void DeleteCompany()
        {
            int id = 3;
            ICompanyService cs = new CompanyService();
            var result = cs.DeleteSingleCompany(id);
        }

        #endregion

        #region LandBase MNG

        private void AddLandBase()
        {
            LandBaseModel data = new LandBaseModel();
            data.CompanyID = 1;
            data.LandCode = "test";
            data.LandName = "test";
            data.Location = "test";
            data.LandTime = DateTime.Now;
            data.LandArea = Convert.ToDecimal(10.000);
            data.EmployeesNum = 10;
            data.LandState = 0;
            data.LandType = 0;
            data.Address = "test";
            data.Lon = "test";
            data.Lat = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            ILandBaseService cs = new LandBaseService();
            var result = cs.InsertSingleLandBase(data);
        }

        private void UpdateLandBase()
        {
            int id = 1;
            ILandBaseService cs = new LandBaseService();
            var data = cs.GetLandBaseById(id);
            var result = cs.UpdateSingleLandBase(data);
        }

        private void DeleteLandBase()
        {
            int id = 1;
            ILandBaseService cs = new LandBaseService();
            var result = cs.DeleteSingleLandBase(id);
        }

        #endregion

        #region Dept MNG
        private void AddDept()
        {
            DeptModel data = new DeptModel();
            data.CompanyID = 2;
            data.DeptName = "test";
            data.UpperDeptID = 1;
            data.DeptRemark = "test";
            data.SortID = 0;
            IDeptService cs = new DeptService();
            var result = cs.InsertSingleDept(data);
        }

        private void UpdateDept()
        {
            int id = 1;
            IDeptService cs = new DeptService();
            var data = cs.GetDeptById(id);
            var result = cs.UpdateSingleDept(data);
        }

        private void DeleteDept()
        {
            int id = 1;
            IDeptService cs = new DeptService();
            var result = cs.DeleteSingleDept(id);
        }
        #endregion

        #region UserBase MNG
        private void AddUserBase()
        {
            UserBaseModel data = new UserBaseModel();
            data.UserCode = "test";
            data.Password = "test";
            data.UserName = "test";
            data.DeptID = 2;
            data.CompanyID = 1;
            data.AreaCode = "test";
            data.Status = 1;
            data.UserType = 1;
            data.IsLocked = true;
            data.CreateID = 1;
            data.CreateName = "test";
            data.CreateTime = DateTime.Now;
            IUserBaseService cs = new UserBaseService();
            var result = cs.InsertSingleUserBase(data);
        }

        private void UpdateUserBase()
        {
            int id = 1;
            IUserBaseService cs = new UserBaseService();
            var data = cs.GetUserBaseById(id);
            var result = cs.UpdateSingleUserBase(data);
        }

        private void DeleteUserBase()
        {
            int id = 1;
            IUserBaseService cs = new UserBaseService();
            var result = cs.DeleteSingleUserBase(id);
        }
        #endregion

        #region Role MNG
        private void AddRole()
        {
            RoleModel data = new RoleModel();
            data.RoleName = "test";
            data.Remark = "test";
            data.SortID = 1;
            data.IsLocked = true;
            data.CreateID = 1;
            data.CreateName = "test";
            data.CreateTime = DateTime.Now;
            IRoleService cs = new RoleService();
            var result = cs.InsertSingleRole(data);
        }

        private void UpdateRole()
        {
            int id = 1;
            IRoleService cs = new RoleService();
            var data = cs.GetRoleById(id);
            var result = cs.UpdateSingleRole(data);
        }

        private void DeleteRole()
        {
            int id = 1;
            IRoleService cs = new RoleService();
            var result = cs.DeleteSingleRole(id);
        }
        #endregion

        #region Menu MNG
        private void AddMenu()
        {
            MenuModel data = new MenuModel();
            data.ParentID = 0;
            data.Name = "test";
            data.SortID = 1;
            data.IcoURL = "test";
            data.FunctionURL = "test";
            data.SortID = 1;
            data.IsLocked = true;
            data.CreateID = 1;
            data.CreateName = "test";
            data.CreateTime = DateTime.Now;
            IMenuService cs = new MenuService();
            var result = cs.InsertSingleMenu(data);
        }

        private void UpdateMenu()
        {
            int id = 1;
            IMenuService cs = new MenuService();
            var data = cs.GetMenuById(id);
            var result = cs.UpdateSingleMenu(data);
        }

        private void DeleteMenu()
        {
            int id = 1;
            IMenuService cs = new MenuService();
            var result = cs.DeleteSingleMenu(id);
        }
        #endregion

        #region Area MNG
        private void AddArea()
        {
            AreaModel data = new AreaModel();
            data.AreaName = "test";
            IAreaService cs = new AreaService();
            var result = cs.InsertSingleArea(data);
        }

        private void UpdateArea()
        {
            int id = 1;
            IAreaService cs = new AreaService();
            var data = cs.GetAreaById(id);
            var result = cs.UpdateSingleArea(data);
        }

        private void DeleteArea()
        {
            int id = 1;
            IAreaService cs = new AreaService();
            var result = cs.DeleteSingleArea(id);
        }
        #endregion

        #region Province MNG
        private void AddProvince()
        {
            ProvinceModel data = new ProvinceModel();
            data.AreaID = 1;
            data.ProvinceCode = "test";
            data.ProvinceName = "test";
            IProvinceService cs = new ProvinceService();
            var result = cs.InsertSingleProvince(data);
        }

        private void UpdateProvince()
        {
            int id = 1;
            IProvinceService cs = new ProvinceService();
            var data = cs.GetProvinceById(id);
            var result = cs.UpdateSingleProvince(data);
        }

        private void DeleteProvince()
        {
            int id = 1;
            IProvinceService cs = new ProvinceService();
            var result = cs.DeleteSingleProvince(id);
        }
        #endregion

        #region City MNG
        private void AddCity()
        {
            CityModel data = new CityModel();

            data.CityCode = "test";
            data.CityName = "test";
            data.CityAreaCode = "test";
            data.ProvinceID = 2;
            ICityService cs = new CityService();
            var result = cs.InsertSingleCity(data);
        }

        private void UpdateCity()
        {
            int id = 1;
            ICityService cs = new CityService();
            var data = cs.GetCityById(id);
            var result = cs.UpdateSingleCity(data);
        }

        private void DeleteCity()
        {
            int id = 1;
            ICityService cs = new CityService();
            var result = cs.DeleteSingleCity(id);
        }
        #endregion

        #region Country MNG
        private void AddCountry()
        {
            CountryModel data = new CountryModel();
            data.CountryCode = "test";
            data.CountryName = "test";
            data.CityID = 2;
            ICountryService cs = new CountryService();
            var result = cs.InsertSingleCountry(data);
        }

        private void UpdateCountry()
        {
            int id = 1;
            ICountryService cs = new CountryService();
            var data = cs.GetCountryById(id);
            var result = cs.UpdateSingleCountry(data);
        }

        private void DeleteCountry()
        {
            int id = 1;
            ICountryService cs = new CountryService();
            var result = cs.DeleteSingleCountry(id);
        }
        #endregion
        #endregion

        #region PlansMng
        #region LandBlock MNG

        private void AddLandBlock()
        {
            LandBlockModel data = new LandBlockModel();
            data.LandID = 2;
            data.BlockCode = "test";
            data.BlockName = "test";
            data.BlockArea = Convert.ToDecimal(10.000);
            data.SoilType = "test";
            data.SoilName = "test";
            data.SoilSalinity = "test";
            data.SoilQuality = "test";
            data.Toc = "test";
            data.LakerSalinity = "test";
            data.WaterSalinity = "test";
            data.GroundWater = "test";
            data.WaterQuality = "test";
            data.Lon = "test";
            data.Lat = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;


            ILandBlockService cs = new LandBlockService();
            var result = cs.InsertSingleLandBlock(data);
        }

        private void UpdateLandBlock()
        {
            int id = 1;
            ILandBlockService cs = new LandBlockService();
            var data = cs.GetLandBlockById(id);
            var result = cs.UpdateSingleLandBlock(data);
        }

        private void DeleteLandBlock()
        {
            int id = 1;
            ILandBlockService cs = new LandBlockService();
            var result = cs.DeleteSingleLandBlock(id);
        }

        #endregion

        #region SeedBase MNG

        private void AddSeedBase()
        {
            SeedBaseModel data = new SeedBaseModel();
            data.SeedCode = "test";
            data.SeedNO = "test";
            data.SeedName = "test";
            data.BatchNO = "test";
            data.Place = "test";
            data.Supplier = "test";
            data.PurchPerson = "test";
            data.BuyTime = DateTime.Now;
            data.BuyCount = 10;
            data.Units = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            ISeedBaseService cs = new SeedBaseService();
            var result = cs.InsertSingleSeedBase(data);
        }

        private void UpdateSeedBase()
        {
            int id = 1;
            ISeedBaseService cs = new SeedBaseService();
            var data = cs.GetSeedBaseById(id);
            var result = cs.UpdateSingleSeedBase(data);
        }

        private void DeleteSeedBase()
        {
            int id = 1;
            ISeedBaseService cs = new SeedBaseService();
            var result = cs.DeleteSingleSeedBase(id);
        }

        #endregion

        #region PlansBatch MNG

        private void AddPlansBatch()
        {
            PlansBatchModel data = new PlansBatchModel();
            data.BlockID = 2;
            data.SeedID = 2;
            data.BatchNO = "test";
            data.BatchCode = "test";
            data.PlansTime = DateTime.Now;
            data.PlansYear = "test";
            data.HarvestTime = DateTime.Now;
            data.PlansArea = 10;
            data.ChargePerson = "test";
            data.HarvestCount = 10;
            data.RealCount = 10;
            data.People = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IPlansBatchService cs = new PlansBatchService();
            var result = cs.InsertSinglePlansBatch(data);
        }

        private void UpdatePlansBatch()
        {
            int id = 1;
            IPlansBatchService cs = new PlansBatchService();
            var data = cs.GetPlansBatchById(id);
            var result = cs.UpdateSinglePlansBatch(data);
        }

        private void DeletePlansBatch()
        {
            int id = 1;
            IPlansBatchService cs = new PlansBatchService();
            var result = cs.DeleteSinglePlansBatch(id);
        }

        #endregion

        #region PlansDrug MNG

        private void AddPlansDrug()
        {
            PlansDrugModel data = new PlansDrugModel();
            data.BatchID = 2;
            data.People = "test";
            data.Object = "test";
            data.DrugName = "test";
            data.DrugTime = DateTime.Now;
            data.Problem = "test";
            data.Method = "test";
            data.UANum = "test";
            data.Dilution = "test";
            data.Weather = "test";
            data.Pic = "test";
            data.PlansCode = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IPlansDrugService cs = new PlansDrugService();
            var result = cs.InsertSinglePlansDrug(data);
        }

        private void UpdatePlansDrug()
        {
            int id = 1;
            IPlansDrugService cs = new PlansDrugService();
            var data = cs.GetPlansDrugById(id);
            var result = cs.UpdateSinglePlansDrug(data);
        }

        private void DeletePlansDrug()
        {
            int id = 1;
            IPlansDrugService cs = new PlansDrugService();
            var result = cs.DeleteSinglePlansDrug(id);
        }

        #endregion

        #region PlansFert MNG

        private void AddPlansFert()
        {
            PlansFertModel data = new PlansFertModel();
            data.BatchID = 2;
            data.FertCode = "test";
            data.FertName = "test";
            data.FertPeople = "test";
            data.FertTime = DateTime.Now;
            data.FertType = "test";
            data.FertMethod = "test";
            data.UANum = "test";
            data.Weather = "test";
            data.Pic = "test";
            data.PlansCode = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IPlansFertService cs = new PlansFertService();
            var result = cs.InsertSinglePlansFert(data);
        }

        private void UpdatePlansFert()
        {
            int id = 2;
            IPlansFertService cs = new PlansFertService();
            var data = cs.GetPlansFertById(id);
            var result = cs.UpdateSinglePlansFert(data);
        }

        private void DeletePlansFert()
        {
            int id = 1;
            IPlansFertService cs = new PlansFertService();
            var result = cs.DeleteSinglePlansFert(id);
        }

        #endregion
        #endregion

        #region KillMng

        #region KillCull
        private void AddKillCull()
        {
            KillCullModel data = new KillCullModel();
            data.CompanyID = 2;
            data.KillBatchID = 2;
            data.CultivationID = 2;
            data.CultivationEpc = "test";
            data.KillEpc = "test";
            data.ProductID = 2;
            data.ProductName = "test";
            data.Weight = 10;
            data.Flow = "test";
            data.KillTime = DateTime.Now;
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IKillCullService cs = new KillCullService();
            var result = cs.InsertSingleKillCull(data);
        }

        private void UpdateKillCull()
        {
            int id = 1;
            IKillCullService cs = new KillCullService();
            var data = cs.GetKillCullById(id);
            var result = cs.UpdateSingleKillCull(data);
        }

        private void DeleteKillCull()
        {
            int id = 1;
            IKillCullService cs = new KillCullService();
            var result = cs.DeleteSingleKillCull(id);
        }
        #endregion

        #region KillDrug
        private void AddKillDrug()
        {
            KillDrugModel data = new KillDrugModel();
            data.KillCullID = 2;
            data.KillEpc = "test";
            data.People = "test";
            data.DrugTime = DateTime.Now;
            data.IsNormal = true;
            data.Pic = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IKillDrugService cs = new KillDrugService();
            var result = cs.InsertSingleKillDrug(data);
        }

        private void UpdateKillDrug()
        {
            int id = 1;
            IKillDrugService cs = new KillDrugService();
            var data = cs.GetKillDrugById(id);
            var result = cs.UpdateSingleKillDrug(data);
        }

        private void DeleteKillDrug()
        {
            int id = 1;
            IKillDrugService cs = new KillDrugService();
            var result = cs.DeleteSingleKillDrug(id);
        }
        #endregion

        #region KillBatch
        private void AddKillBatch()
        {
            KillBatchModel data = new KillBatchModel();
            data.CompanyID = 2;
            data.BatchNO = "test";
            data.RecvicePeople = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IKillBatchService cs = new KillBatchService();
            var result = cs.InsertSingleKillBatch(data);
        }

        private void UpdateKillBatch()
        {
            int id = 1;
            IKillBatchService cs = new KillBatchService();
            var data = cs.GetKillBatchById(id);
            var result = cs.UpdateSingleKillBatch(data);
        }

        private void DeleteKillBatch()
        {
            int id = 1;
            IKillBatchService cs = new KillBatchService();
            var result = cs.DeleteSingleKillBatch(id);
        }
        #endregion

        #region KillBatchDetail
        private void AddKillBatchDetail()
        {
            KillBatchDetailModel data = new KillBatchDetailModel();
            data.KillBatchID = 2;
            data.CultivationID = 2;
            data.BreedID = 2;
            data.AreaID = 2;
            data.HomeID = 2;
            data.CultivationEpc = "test";
            data.Remark = "test";
            data.IsLocked = false;
            data.IsShow = true;

            IKillBatchDetailService cs = new KillBatchDetailService();
            var result = cs.InsertSingleKillBatchDetail(data);
        }

        private void UpdateKillBatchDetail()
        {
            int id = 1;
            IKillBatchDetailService cs = new KillBatchDetailService();
            var data = cs.GetKillBatchDetailById(id);
            var result = cs.UpdateSingleKillBatchDetail(data);
        }

        private void DeleteKillBatchDetail()
        {
            int id = 1;
            IKillBatchDetailService cs = new KillBatchDetailService();
            var result = cs.DeleteSingleKillBatchDetail(id);
        }
        #endregion

        #endregion
    }
}
