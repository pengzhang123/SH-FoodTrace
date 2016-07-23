using Caliburn.Micro;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.Views;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(WareHouseStockEditViewModel))]
    public class WareHouseStockEditViewModel : ViewAware
    {
        private IWareHouseStockService iWareHouseStockService = new WareHouseStockService();
        private IWareHouseBaseService iWareHouseBaseService = new WareHouseBaseService();

        private ICompanyService iCompanyService = new CompanyService();

        public WareHouseStockModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<CompanyModel> Companys { get; set; }


        public BindableCollection<WareHouseBaseModel> Houses { get; set; }
        public BindableCollection<ProductBaseModel> ProductBases { get; set; }

        public void LoadUserControl(WareHouseStockEditView view)
        {
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);

            var houses = iWareHouseBaseService.GetPagerWareHouseBase("", 1, 100);
            Houses = new BindableCollection<WareHouseBaseModel>(houses);
            NotifyOfPropertyChange(() => Houses);

            var productBases = new List<ProductBaseModel> { new ProductBaseModel { Price = 11, ProductID = 1, ProductName = "产品1", Weight = 100, ProductCode = "产品1代号" } };
            ProductBases = new BindableCollection<ProductBaseModel>(productBases);
            NotifyOfPropertyChange(() => ProductBases);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iWareHouseStockService.InsertSingleWareHouseStock(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iWareHouseStockService.UpdateSingleWareHouseStock(Model);
            }
            var win = GetView() as System.Windows.Window;
            if (win != null)
            {
                win.DialogResult = true;
                win.Close();
            }
        }

        public void Cancel()
        {
            var win = GetView() as System.Windows.Window;
            if (win != null)
            {
                win.DialogResult = false;
                win.Close();
            }
        }
    }
}
