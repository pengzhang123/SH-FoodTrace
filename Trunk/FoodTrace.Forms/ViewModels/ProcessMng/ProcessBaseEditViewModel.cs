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
    [Export(typeof(ProcessBaseEditViewModel))]
    public class ProcessBaseEditViewModel : ViewAware
    {
        private IProcessBaseService iProcessBaseService = new ProcessBaseService();

        public ProcessBaseModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(ProcessBaseEditView view)
        {

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iProcessBaseService.InsertSingleProcessBase(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iProcessBaseService.UpdateSingleProcessBase(Model);
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
