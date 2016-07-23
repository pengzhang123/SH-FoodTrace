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
    [Export(typeof(BreedDrugEditViewModel))]
    public class BreedDrugEditViewModel : ViewAware
    {
        public BreedDrugEditView ViewSelf { get; set; }
        private IBreedDrugService iBreedDrugService = new BreedDrugService();
        private IBreedMaterialService iBreedMaterialService = new BreedMaterialService();
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();

        public BreedDrugModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedDrugEditView view)
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
                var result = iBreedDrugService.InsertSingleBreedDrug(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedDrugService.UpdateSingleBreedDrug(Model);
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
