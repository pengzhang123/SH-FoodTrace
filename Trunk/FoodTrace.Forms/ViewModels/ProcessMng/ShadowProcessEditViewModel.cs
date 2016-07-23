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
     [Export(typeof(ShadowProcessEditViewModel))]
    public class ShadowProcessEditViewModel : ViewAware
    {



        private IShadowProcessService iShadowProcessService = new ShadowProcessService();
        private IProcessBaseService iProcessBaseService = new ProcessBaseService();
        private IShadowBaseService iShadowBaseService = new ShadowBaseService();

        public ShadowProcessModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<ProcessBaseModel> ProcessBases { get; set; }
        public BindableCollection<ShadowBaseModel> ShadowBases { get; set; }

        public void LoadUserControl(ShadowProcessEditView view)
        {
            var processBases = iProcessBaseService.GetPagerProcessBase("", 1, 100);
            ProcessBases = new BindableCollection<ProcessBaseModel>(processBases);
            NotifyOfPropertyChange(() => ProcessBases);

            var shadowBases = iShadowBaseService.GetPagerShadowBase("", 1, 100);
            ShadowBases = new BindableCollection<ShadowBaseModel>(shadowBases);
            NotifyOfPropertyChange(() => ShadowBases);
        }

        public void ProcessBaseSelectionChanged(ComboBox cb)
        {
            var selectedItem = cb.SelectedItem as ProcessBaseModel;
            Model.ProcessCode = selectedItem.ProcessCode;
            Model.ProcessName = selectedItem.ProcessName;
            NotifyOfPropertyChange(() => Model);
        }

        public void ShadowBaseSelectionChanged(ComboBox cb)
        {
            var selectedItem = cb.SelectedItem as ShadowBaseModel;
            Model.CompanyID = selectedItem.CompanyID;
            NotifyOfPropertyChange(() => Model);
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iShadowProcessService.InsertSingleShadowProcess(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iShadowProcessService.UpdateSingleShadowProcess(Model);
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
