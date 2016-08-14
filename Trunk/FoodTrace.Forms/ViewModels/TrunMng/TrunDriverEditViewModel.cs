using Caliburn.Micro;
using FoodTrace.Forms.Helpers;
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
    [Export(typeof(TrunDriverEditViewModel))]
    public class TrunDriverEditViewModel : ViewAware
    {
        private ITrunDriverService iTrunDriverService = new TrunDriverService();

        private ICompanyService iCompanyService = new CompanyService();


        private ICodeMaxService iCodeMaxService = new CodeMaxService();
        public void EpcGotFocus()
        {
            CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
            //种植场号
            pro96.CompanyCode = Model.CompanyID.ToString();
            pro96.CompanyType = "1";
            pro96.Driver = Model.DriverName.ToString();
            //生成日期
            pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
            //标签类型
            pro96.EpcType = "6";
            Model.DriverEPC = pro96.PackEpc();
            NotifyOfPropertyChange(() => Model);
        }


   

        public TrunDriverModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<CompanyModel> Companys { get; set; }

        public void LoadUserControl(TrunDriverEditView view)
        {
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);

        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iTrunDriverService.InsertSingleTrunDriver(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iTrunDriverService.UpdateSingleTrunDriver(Model);
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
