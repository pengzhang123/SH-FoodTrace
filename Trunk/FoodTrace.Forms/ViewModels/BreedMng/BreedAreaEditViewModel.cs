using Caliburn.Micro;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.Views;
using FoodTrace.IService;
using FoodTrace.IService.BreedMng;
using FoodTrace.Model;
using FoodTrace.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Service.BreedMng;

namespace FoodTrace.Forms.ViewModels
{
   [Export(typeof(BreedAreaEditViewModel))]
    public class BreedAreaEditViewModel : ViewAware
    {
        private IBreedBaseService iBreedBaseService = new BreedBaseService();
        private IBreedAreaService iBreedAreaService = new BreedAreaService();
        private ILandBaseService iLandBaseService = new LandBaseService();
        private IVarietyBaseService iVarietyBaseService = new VarietyBaseService();
       private readonly IBreedVarietyService _varietyService=new BreedVarietyService();

        public BreedAreaModel Model { get; set; }
        public EditMode Mode { get; set; }
        
        public void LoadUserControl(BreedAreaEditView view)
        {
            var list = iBreedBaseService.GetPagerBreedBase("", 1, 100);
            view.cbBreedBase.ItemsSource = list;
            view.cbBreedBase.DisplayMemberPath = "BreedName";
            view.cbBreedBase.SelectedValuePath = "BreedID";

            //var list2 = iVarietyBaseService.GetPagerVarietyBase("", 1, 100);
            var list2 = _varietyService.GetVarietyList();
            view.cbVarietyType.ItemsSource = list2;
            view.cbVarietyType.DisplayMemberPath = "VarietyName";
            view.cbVarietyType.SelectedValuePath = "VarietyName";
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iBreedAreaService.InsertSingleBreedArea(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedAreaService.UpdateSingleBreedArea(Model);
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
