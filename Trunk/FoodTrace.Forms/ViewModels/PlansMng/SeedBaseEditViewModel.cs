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
    [Export(typeof(SeedBaseEditViewModel))]
    public class SeedBaseEditViewModel : ViewAware
    {
        private ISeedBaseService iSeedBaseService = new SeedBaseService();

        public SeedBaseModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(SeedBaseEditView view)
        {

            ILandBaseService iLandBaseService = new LandBaseService();
            var landBases = iLandBaseService.GetPagerLandBase(string.Empty, 1, 10);
            //view.lbLand.ItemsSource = landBases;
            //view.lbLand.SelectedValuePath = "LandID";
            //view.lbLand.DisplayMemberPath = "LandName";
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                iSeedBaseService.InsertSingleSeedBase(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iSeedBaseService.UpdateSingleSeedBase(Model);
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
