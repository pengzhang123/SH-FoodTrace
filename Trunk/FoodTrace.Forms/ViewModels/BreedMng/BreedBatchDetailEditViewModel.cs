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
    [Export(typeof(BreedBatchDetailEditViewModel))]
    public class BreedBatchDetailEditViewModel : ViewAware
    {
        public BreedBatchDetailEditView ViewSelf { get; set; }
        private IBreedBatchDetailService iBreedBatchDetailService = new BreedBatchDetailService();
        private IBreedBatchService iBreedBatchService = new BreedBatchService();
        private IBreedHomeService iBreedHomeService = new BreedHomeService();
        private IBreedAreaService iBreedAreaService = new BreedAreaService();
        private IBreedBaseService iBreedBaseService = new BreedBaseService();
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();

        public BreedBatchDetailModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedBatchDetailEditView view)
        {
            ViewSelf = view;
            view.cbBreedBase.ItemsSource = iBreedBaseService.GetPagerBreedBase("", 1, 100);//.Select(_=>_.BreedBase);
            view.cbBreedBase.DisplayMemberPath = "BreedName";// "BreedBase.BreedName";
            view.cbBreedBase.SelectedValuePath = "BreedID";

            view.cbBreedArea.ItemsSource = iBreedAreaService.GetPagerBreedArea("", 1, 100);//.Select(_=>_.BreedBase);
            view.cbBreedArea.DisplayMemberPath = "AreaName";// "BreedBase.BreedName";
            view.cbBreedArea.SelectedValuePath = "AreaID";

            view.cbBreedBatch.ItemsSource = iBreedBatchService.GetPagerBreedBatch("", 1, 100);//.Select(_=>_.BreedBase);
            view.cbBreedBatch.DisplayMemberPath = "BatchNO";// "BreedBase.BreedName";
            view.cbBreedBatch.SelectedValuePath = "BreedBatchID";

            view.cbBreedHome.ItemsSource = iBreedHomeService.GetPagerBreedHome("", 1, 100);//.Select(_=>_.BreedBase);
            view.cbBreedHome.DisplayMemberPath = "HomeName";// "BreedBase.BreedName";
            view.cbBreedHome.SelectedValuePath = "HomeID";

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
                var result = iBreedBatchDetailService.InsertSingleBreedBatchDetail(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iBreedBatchDetailService.UpdateSingleBreedBatchDetail(Model);
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
