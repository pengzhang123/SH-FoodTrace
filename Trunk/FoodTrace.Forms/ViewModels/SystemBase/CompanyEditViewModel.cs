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
     [Export(typeof(CompanyEditViewModel))]
    public class CompanyEditViewModel : ViewAware
    {
        private ICompanyService iCompanyService = new CompanyService();

        public CompanyModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(CompanyEditView view)
        {

            ILandBaseService iLandBaseService = new LandBaseService();
            var landBases = iLandBaseService.GetPagerLandBase(string.Empty, 1, 10);
            //view.lbLand.ItemsSource = landBases;
            //view.lbLand.SelectedValuePath = "LandID";
            //view.lbLand.DisplayMemberPath = "LandName";
        }

        public void SaveLandBlock()
        {
            if (Mode == EditMode.CREATE)
            {
                iCompanyService.InsertSingleCompany(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iCompanyService.UpdateSingleCompany(Model);
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
