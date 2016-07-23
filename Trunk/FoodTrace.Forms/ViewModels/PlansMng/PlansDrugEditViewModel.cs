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
        [Export(typeof(PlansDrugEditViewModel))]
    public class PlansDrugEditViewModel : ViewAware
    {
        private IPlansBatchService iPlansBatchService = new PlansBatchService();
        private IPlansDrugService iPlansDrugService = new PlansDrugService();

        public PlansDrugModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(PlansDrugEditView view)
        {

            //ILandBlockService iLandBlockService = new LandBlockService();
            var landBlocks = iPlansBatchService.GetPagerPlansBatch(string.Empty, 1, 10);
            view.lbLand.ItemsSource = landBlocks;
            view.lbLand.SelectedValuePath = "BatchID";
            view.lbLand.DisplayMemberPath = "BatchNO";

            //ISeedBaseService iISeedBaseService = new SeedBaseService();
            //var seeds = iISeedBaseService.GetPagerSeedBase(string.Empty, 1, 10);

            //view.lbSeed.SelectedValuePath = "SeedID";
            //view.lbSeed.DisplayMemberPath = "SeedName";
            //view.lbSeed.ItemsSource = seeds;
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                iPlansDrugService.InsertSinglePlansDrug(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iPlansDrugService.UpdateSinglePlansDrug(Model);
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
