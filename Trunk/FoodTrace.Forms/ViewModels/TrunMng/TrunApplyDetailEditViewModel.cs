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
    [Export(typeof(TrunApplyDetailEditViewModel))]
    public class TrunApplyDetailEditViewModel : ViewAware
    {
        private ITrunApplyDetailService iTrunApplyDetailService = new TrunApplyDetailService();

        private ITrunApplyService iTrunApplyService = new TrunApplyService();

        public TrunApplyDetailModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<TrunApplyModel> Applys { get; set; }

        public void LoadUserControl(TrunApplyDetailEditView view)
        {
            var applys = iTrunApplyService.GetPagerTrunApply("", 1, 100);
            Applys = new BindableCollection<TrunApplyModel>(applys);
            NotifyOfPropertyChange(() => Applys);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iTrunApplyDetailService.InsertSingleTrunApplyDetail(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iTrunApplyDetailService.UpdateSingleTrunApplyDetail(Model);
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
