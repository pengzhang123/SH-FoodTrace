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
   [Export(typeof(BreedBatchEditViewModel))]
    public class BreedBatchEditViewModel : ViewAware
    {
        public BreedBatchEditView ViewSelf { get; set; }
        private IBreedBatchService iBreedBatchService = new BreedBatchService();
        private IBreedBaseService iBreedBaseService = new BreedBaseService();
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();

        public BreedBatchModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedBatchEditView view)
        {
            ViewSelf = view;
            view.cbBreedBase.ItemsSource = iBreedBaseService.GetPagerBreedBase("", 1, 100);//.Select(_=>_.BreedBase);
            view.cbBreedBase.DisplayMemberPath = "BreedName";// "BreedBase.BreedName";
            view.cbBreedBase.SelectedValuePath = "BreedID";
        }

        public void CultivationBaseSelectionChanged()
        {
            //ViewSelf.YZSWSUYM.Text = iCultivationBaseService.GetCultivationBaseById(Model.CultivationID.Value).BreedBase.BreedCode.Value.ToString();
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iBreedBatchService.InsertSingleBreedBatch(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedBatchService.UpdateSingleBreedBatch(Model);
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
