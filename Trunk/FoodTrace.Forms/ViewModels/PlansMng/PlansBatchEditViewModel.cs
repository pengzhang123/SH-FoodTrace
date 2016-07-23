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
        [Export(typeof(PlansBatchEditViewModel))]
    public class PlansBatchEditViewModel : ViewAware
    {
        private IPlansBatchService iPlansBatchService = new PlansBatchService();

        public PlansBatchModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(PlansBatchEditView view)
        {

            ILandBlockService iLandBlockService = new LandBlockService();
            var landBlocks = iLandBlockService.GetPagerLandBlock(string.Empty, 1, 10);
            view.lbLand.SelectedValuePath = "BlockID";
            view.lbLand.DisplayMemberPath = "BlockName";
            view.lbLand.ItemsSource = landBlocks;

            ISeedBaseService iISeedBaseService = new SeedBaseService();
            var seeds = iISeedBaseService.GetPagerSeedBase(string.Empty, 1, 10);
            
            view.lbSeed.SelectedValuePath = "SeedID";
            view.lbSeed.DisplayMemberPath = "SeedName";
            view.lbSeed.ItemsSource = seeds;
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                iPlansBatchService.InsertSinglePlansBatch(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iPlansBatchService.UpdateSinglePlansBatch(Model);
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
