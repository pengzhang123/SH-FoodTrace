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
     
     [Export(typeof(CultivationBaseEditViewModel))]
    public class CultivationBaseEditViewModel : ViewAware
    {
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();
        
        public CultivationBaseModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(CultivationBaseEditView view)
        {

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iCultivationBaseService.InsertSingleCultivationBase(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iCultivationBaseService.UpdateSingleCultivationBase(Model);
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
