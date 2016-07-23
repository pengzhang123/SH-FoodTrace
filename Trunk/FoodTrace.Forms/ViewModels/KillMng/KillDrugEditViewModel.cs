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
using System.Windows.Controls;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(KillDrugEditViewModel))]
    public class KillDrugEditViewModel : ViewAware
    {
        private IKillDrugService iKillDrugService = new KillDrugService();
        private IKillCullService iKillCullService = new KillCullService();

        public KillDrugEditView ViewSelf { get; set; }

        public KillDrugModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(KillDrugEditView view)
        {
            ViewSelf = view;

            ViewSelf.cbKillCull.ItemsSource = iKillCullService.GetPagerKillCull(string.Empty, 1, 100);
            ViewSelf.cbKillCull.SelectedValuePath = "KillCullID";
            ViewSelf.cbKillCull.DisplayMemberPath = "KillCullID";

            //ICompanyService iCompanyService = new CompanyService();
            //var landBases = iCompanyService.GetCompanyById();
            //view.lbLand.ItemsSource = landBases;
            //view.lbLand.SelectedValuePath = "LandID";
            //view.lbLand.DisplayMemberPath = "LandName";
            //if(Mode  == EditMode.CREATE)
            //{

            //    NotifyOfPropertyChange(() => Model);
            //}
        }

        public void KillCullSelectionChanged(ComboBox cb)
        {
            var model = (KillCullModel)cb.SelectedItem;
            ViewSelf.TZSUYM.Text = model.KillEpc;
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iKillDrugService.InsertSingleKillDrug(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iKillDrugService.UpdateSingleKillDrug(Model);
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
