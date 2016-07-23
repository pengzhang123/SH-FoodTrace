using Caliburn.Micro;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.Views;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service;
using FoodTrace.Service.TrunMng;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(TrunApplyEditViewModel))]
    public class TrunApplyEditViewModel : ViewAware
    {
        private ITrunApplyService iTrunApplyEditService = new TrunApplyService();

        private ICompanyService iCompanyService = new CompanyService();
        private ITrunDriverService iTrunDriverService = new TrunDriverService();
        private ITrunVehicleService iTrunVehicleService = new TrunVehicleService();

        public TrunApplyModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<CompanyModel> Companys { get; set; }
        public BindableCollection<TrunDriverModel> Drivers { get; set; }
        public BindableCollection<TrunVehicleModel> Vehicles { get; set; }

        public void LoadUserControl(TrunApplyEditView view)
        {
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);

            var vehicles = iTrunVehicleService.GetPagerTrunVehicle("", 1, 100);
            Vehicles = new BindableCollection<TrunVehicleModel>(vehicles);
            NotifyOfPropertyChange(() => Vehicles);

            var drivers = iTrunDriverService.GetPagerTrunDriver("", 1, 100);
            Drivers = new BindableCollection<TrunDriverModel>(drivers);
            NotifyOfPropertyChange(() => Drivers);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iTrunApplyEditService.InsertSingleTrunApply(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iTrunApplyEditService.UpdateSingleTrunApply(Model);
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
