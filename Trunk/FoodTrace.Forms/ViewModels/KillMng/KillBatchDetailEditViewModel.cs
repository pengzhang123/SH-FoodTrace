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
     
    [Export(typeof(KillBatchDetailEditViewModel))]
    public class KillBatchDetailEditViewModel : ViewAware
    {
        private IKillBatchDetailService iKillBatchDetailService = new KillBatchDetailService();
        private IKillBatchService _killBatchService = new KillBatchService();
        public KillBatchDetailModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(KillBatchDetailEditView view)
        {

            //ICompanyService iCompanyService = new CompanyService();
            //var landBases = iCompanyService.GetCompanyById();
            //view.lbLand.ItemsSource = landBases;
            //view.lbLand.SelectedValuePath = "LandID";
            //view.lbLand.DisplayMemberPath = "LandName";
            //if(Mode  == EditMode.CREATE)
            //{

            //    NotifyOfPropertyChange(() => Model);
            //}

            var list = _killBatchService.GetKillBatchListPaging(1, 1000);
            view.cbKillBatch.ItemsSource = list.rows;
            view.cbKillBatch.DisplayMemberPath = "BatchNO";
            view.cbKillBatch.SelectedValuePath = "KillBatchID";
            view.cbKillBatch.SelectedValue = Model.KillBatchID;
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iKillBatchDetailService.InsertSingleKillBatchDetail(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iKillBatchDetailService.UpdateSingleKillBatchDetail(Model);
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
