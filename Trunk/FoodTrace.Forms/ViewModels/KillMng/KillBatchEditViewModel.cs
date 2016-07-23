using Caliburn.Micro;
using FoodTrace.Common.Libraries;
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
     
    [Export(typeof(KillBatchEditViewModel))]
    public class KillBatchEditViewModel : ViewAware
    {
        private IKillBatchService iKillBatchService = new KillBatchService();

        public KillBatchModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(KillBatchEditView view)
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
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                Model.Company = null;//必须设为null，否则会先添加外键值到数据库后添加主键值
                var result = iKillBatchService.InsertSingleKillBatch(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iKillBatchService.UpdateSingleKillBatch(Model);
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
