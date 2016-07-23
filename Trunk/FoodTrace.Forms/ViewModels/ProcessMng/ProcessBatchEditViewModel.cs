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
    [Export(typeof(ProcessBatchEditViewModel))]
    public class ProcessBatchEditViewModel : ViewAware
    {
        private IProcessBatchService iProcessBatchService = new ProcessBatchService();
        
        public ProcessBatchModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(ProcessBatchEditView view)
        {
            
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iProcessBatchService.InsertSingleProcessBatch(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iProcessBatchService.UpdateSingleProcessBatch(Model);
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
