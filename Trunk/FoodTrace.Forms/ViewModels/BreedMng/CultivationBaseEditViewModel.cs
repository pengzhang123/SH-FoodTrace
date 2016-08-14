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
     
     [Export(typeof(CultivationBaseEditViewModel))]
    public class CultivationBaseEditViewModel : ViewAware
    {
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();



        private ICodeMaxService iCodeMaxService = new CodeMaxService();
        public void EpcGotFocus()
        {
            CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
            //养殖场号
            pro96.BusinessCode = Model.BreedHome == null ? "0":Model.BreedHome.HomeID.ToString();
            //批次号
            pro96.BatchNo = Model.BatchCode;
            //生成日期
            pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
            var maxId = iCodeMaxService.GetMaxCode("CultivationBase");
            //序号
            pro96.SeqNo = maxId;
            //标签类型
            pro96.EpcType = "1";
            Model.CultivationEpc = pro96.PackEpc();
            NotifyOfPropertyChange(() => Model);
        }
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
