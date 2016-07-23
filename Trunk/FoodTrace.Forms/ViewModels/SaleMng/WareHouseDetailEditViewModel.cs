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
    [Export(typeof(WareHouseDetailEditViewModel))]
    public class WareHouseDetailEditViewModel : ViewAware
    {
        private IWareHouseDetailService iWareHouseDetailService = new WareHouseDetailService();

        private IWareHouseBaseService iWareHouseBaseService = new WareHouseBaseService();

        public WareHouseDetailModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<WareHouseBaseModel> Houses { get; set; }
        public BindableCollection<ProductBaseModel> ProductBases { get; set; }

        public void LoadUserControl(WareHouseDetailEditView view)
        {
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
                var result = iWareHouseDetailService.InsertSingleWareHouseDetail(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iWareHouseDetailService.UpdateSingleWareHouseDetail(Model);
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
