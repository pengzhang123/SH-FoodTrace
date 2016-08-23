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
     [Export(typeof(BreedHomeEditViewModel))]
    public class BreedHomeEditViewModel : ViewAware
    {
        private IBreedHomeService iBreedHomeService = new BreedHomeService();
        private IBreedAreaService iBreedAreaService = new BreedAreaService();
        private readonly IBreedVarietyService _varietyService = new BreedVarietyService();
        public BreedHomeModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedHomeEditView view)
        {
            var list = iBreedAreaService.GetPagerBreedArea("", 1, 100);
            view.cbBreedArea.ItemsSource = list;
            view.cbBreedArea.DisplayMemberPath = "AreaName";
            view.cbBreedArea.SelectedValuePath = "AreaID";

            var list2 = _varietyService.GetVarietyList();
            view.cbVarietyType.ItemsSource = list2;
            view.cbVarietyType.DisplayMemberPath = "VarietyName";
            view.cbVarietyType.SelectedValuePath = "VarietyName";
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iBreedHomeService.InsertSingleBreedHome(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedHomeService.UpdateSingleBreedHome(Model);
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
