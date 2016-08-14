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
using System.Windows.Controls;

namespace FoodTrace.Forms.ViewModels
{
     [Export(typeof(KillCullEditViewModel))]
    public class KillCullEditViewModel : ViewAware
    {
        private IKillCullService iKillCullService = new KillCullService();
        private IKillBatchService iKillBatchService = new KillBatchService();
        private IKillBatchDetailService iKillBatchDetailService = new KillBatchDetailService();


        private ICodeMaxService iCodeMaxService = new CodeMaxService();
        public void EpcGotFocus()
        {
            CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
            //种植场号
            pro96.BusinessCode = Model.Company.CompanyID.ToString();
            //批次号
            pro96.GoodsCode = Model.KillBatchID.ToString();
            //生成日期
            pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
            var maxId = iCodeMaxService.GetMaxCode("KillCull");
            //序号
            pro96.SeqNo = maxId;
            //标签类型
            pro96.EpcType = "3";
            Model.KillEpc = pro96.PackEpc();
            NotifyOfPropertyChange(() => Model);
        }

        public KillCullEditView ViewSelf { get; set; }

        public KillCullModel Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(KillCullEditView view)
        {
            ViewSelf = view;

            ViewSelf.cbKillBatch.ItemsSource = iKillBatchService.GetPagerKillBatch("", 1, 100);
            ViewSelf.cbKillBatch.SelectedValuePath = "KillBatchID";
            ViewSelf.cbKillBatch.DisplayMemberPath = "BatchNO";
            if (Model.KillBatchID.HasValue)
            {
                var list = iKillBatchService.GetKillBatchById(Model.KillBatchID.Value).KillBatchDetail.Select(_ => _.BreedBase).Distinct();
                ViewSelf.cbKillBatchDetail.ItemsSource = list;// new List <BreedBaseModel> { new BreedBaseModel {  BreedID=1, BreedName="Bull", BreedCode=1 } } ;
                ViewSelf.cbKillBatchDetail.SelectedValuePath = "BreedID";
                ViewSelf.cbKillBatchDetail.DisplayMemberPath = "BreedName";
                ViewSelf.cbKillBatchDetail.SelectedValue = Model.CultivationID;
            }
            

            ViewSelf.cbProducts.ItemsSource = new List<ProductBaseModel> { new ProductBaseModel { ProductID = 1, ProductName = "牛排" } };
            ViewSelf.cbProducts.SelectedValuePath = "ProductID";
            ViewSelf.cbProducts.DisplayMemberPath = "ProductName";

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
        
        public void KillBatchSelectionChanged()
        {
            var list = iKillBatchService.GetKillBatchById(Model.KillBatchID.Value).KillBatchDetail.Select(_ => _.BreedBase).Distinct();
            ViewSelf.cbKillBatchDetail.ItemsSource = list;// new List <BreedBaseModel> { new BreedBaseModel {  BreedID=1, BreedName="Bull", BreedCode=1 } } ;
            ViewSelf.cbKillBatchDetail.SelectedValuePath = "BreedID";
            ViewSelf.cbKillBatchDetail.DisplayMemberPath = "BreedName";
        }

        public void KillBatchDetailSelectionChanged(ComboBox cb)
        {
            var model = (BreedBaseModel)cb.SelectedItem;
            ViewSelf.YZSUYM.Text = model.BreedCode.Value.ToString();
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                Model.Company = null;//必须设为null，否则会先添加外键值到数据库后添加主键值
                var result = iKillCullService.InsertSingleKillCull(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iKillCullService.UpdateSingleKillCull(Model);
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
