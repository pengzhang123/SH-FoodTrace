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
    [Export(typeof(TrunTemperatrueEditViewModel))]
    public class TrunTemperatrueEditViewModel : ViewAware
    {
        private ITrunTemperatrueService iTrunTemperatrueService = new TrunTemperatrueService();
        private ITrunApplyService iTrunApplyService = new TrunApplyService();
        private ICompanyService iCompanyService = new CompanyService();

        public TrunTemperatrueModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<CompanyModel> Companys { get; set; }
        public BindableCollection<TrunApplyModel> Applys { get; set; }
        public void LoadUserControl(TrunTemperatrueEditView view)
        {
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);

            var applys = iTrunApplyService.GetPagerTrunApply("", 1, 100);
            Applys = new BindableCollection<TrunApplyModel>(applys);
            NotifyOfPropertyChange(() => Applys);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iTrunTemperatrueService.InsertSingleTrunTemperatrue(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iTrunTemperatrueService.UpdateSingleTrunTemperatrue(Model);
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
