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
    [Export(typeof(ProcessBatchDetailEditViewModel))]
    public class ProcessBatchDetailEditViewModel : ViewAware
    {
        private IProcessBatchDetailService iProcessBatchDetailService = new ProcessBatchDetailService();

        public ProcessBatchDetailModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(ProcessBatchDetailEditView view)
        {

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iProcessBatchDetailService.InsertSingleProcessBatchDetail(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iProcessBatchDetailService.UpdateSingleProcessBatchDetail(Model);
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
