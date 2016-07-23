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
    [Export(typeof(TrunDriverEditViewModel))]
    public class TrunDriverEditViewModel : ViewAware
    {
        private ITrunDriverService iTrunDriverService = new TrunDriverService();

        private ICompanyService iCompanyService = new CompanyService();

        public TrunDriverModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<CompanyModel> Companys { get; set; }

        public void LoadUserControl(TrunDriverEditView view)
        {
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iTrunDriverService.InsertSingleTrunDriver(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iTrunDriverService.UpdateSingleTrunDriver(Model);
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
