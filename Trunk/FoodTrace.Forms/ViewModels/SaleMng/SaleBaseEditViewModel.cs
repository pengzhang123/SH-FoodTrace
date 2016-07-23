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
using System.Windows.Controls;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(SaleBaseEditViewModel))]
    public class SaleBaseEditViewModel : ViewAware
    {
        private ISaleBaseService iSaleBaseService = new SaleBaseService();

        private ICompanyService iCompanyService = new CompanyService();
        
        public SaleBaseModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<CompanyModel> Companys { get; set; }

        public void LoadUserControl(SaleBaseEditView view)
        {
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iSaleBaseService.InsertSingleSaleBase(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iSaleBaseService.UpdateSingleSaleBase(Model);
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
