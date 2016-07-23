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
    [Export(typeof(BreedHealthEditViewModel))]
    public class BreedHealthEditViewModel : ViewAware
    {
        public BreedHealthEditView ViewSelf { get; set; }
        private IBreedHealthService iBreedHealthService = new BreedHealthService();
        private IBreedMaterialService iBreedMaterialService = new BreedMaterialService();
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();

        public BreedHealthModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedHealthEditView view)
        {
            ViewSelf = view;
            view.cbCultivationBase.ItemsSource = iCultivationBaseService.GetPagerCultivationBase("", 1, 100);//.Select(_=>_.BreedBase);
            view.cbCultivationBase.DisplayMemberPath = "CultivationID";// "BreedBase.BreedName";
            view.cbCultivationBase.SelectedValuePath = "CultivationID";
        }

        public void CultivationBaseSelectionChanged()
        {
            //ViewSelf.YZSWSUYM.Text = iCultivationBaseService.GetCultivationBaseById(Model.CultivationID.Value).BreedBase.BreedCode.Value.ToString();
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iBreedHealthService.InsertSingleBreedHealth(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedHealthService.UpdateSingleBreedHealth(Model);
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
