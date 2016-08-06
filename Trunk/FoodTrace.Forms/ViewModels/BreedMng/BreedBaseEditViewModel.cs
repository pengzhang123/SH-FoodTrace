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
     
   [Export(typeof(BreedBaseEditViewModel))]
    public class BreedBaseEditViewModel : ViewAware
    {
        private IBreedBaseService iBreedBaseService = new BreedBaseService();
        private ILandBaseService iLandBaseService = new LandBaseService();

        public BreedBaseModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedBaseEditView view)
        {
            var list = iLandBaseService.GetLandBaseListByType(2);
            view.cbLandBase.ItemsSource = list;
            view.cbLandBase.DisplayMemberPath = "LandName";
            view.cbLandBase.SelectedValuePath = "LandId";
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iBreedBaseService.InsertSingleBreedBase(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedBaseService.UpdateSingleBreedBase(Model);
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
