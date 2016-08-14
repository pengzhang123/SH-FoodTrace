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
   [Export(typeof(ProcessProductEditViewModel))]
    public class ProcessProductEditViewModel : ViewAware
    {
        private IProcessProductService iProcessProductService = new ProcessProductService();

        private IShadowProcessService iShadowProcessService = new ShadowProcessService();
        private IProcessBaseService iProcessBaseService = new ProcessBaseService();
        private IProcessBatchDetailService iProcessBatchDetailService = new ProcessBatchDetailService();


        private ICodeMaxService iCodeMaxService = new CodeMaxService();
        public void EpcGotFocus()
        {
            CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
            //商品类别
            pro96.GoodsType = "3";
            //商品代号
            pro96.GoodsCode = Model.ProductID.ToString();
            //生成日期
            pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
            var maxId = iCodeMaxService.GetMaxCode("ProcessProduct");
            //销售店号
            pro96.BusinessCode = "112233";
            //商品号型
            pro96.GoodsSize = "255";
            
            //序号
            pro96.SeqNo = maxId;
            //标签类型
            pro96.EpcType = "4";
            Model.ShadowEPC = pro96.PackEpc();
            NotifyOfPropertyChange(() => Model);
        }

        public ProcessProductModel Model { get; set; }
        public EditMode Mode { get; set; }

        public BindableCollection<ProcessBaseModel> ProcessBases { get; set; }
        public BindableCollection<ProcessBatchDetailModel> ProcessBatchDetails { get; set; }
        public BindableCollection<ProductBaseModel> ProductBases { get; set; }

        public void LoadUserControl(ProcessProductEditView view)
        {
            var processBases = iProcessBaseService.GetPagerProcessBase("", 1, 100);
            ProcessBases = new BindableCollection<ProcessBaseModel>(processBases);
            NotifyOfPropertyChange(() => ProcessBases);

            var processBatchDetails = iProcessBatchDetailService.GetPagerProcessBatchDetail("", 1, 100);
            ProcessBatchDetails = new BindableCollection<ProcessBatchDetailModel>(processBatchDetails);
            NotifyOfPropertyChange(() => ProcessBatchDetails);

            var productBases = new List<ProductBaseModel> { new ProductBaseModel { Price=11, ProductID=1,ProductName="产品1",Weight=100,ProductCode="产品1代号" } };
            ProductBases = new BindableCollection<ProductBaseModel>(productBases);
            NotifyOfPropertyChange(() => ProductBases);
        }

        public void ProductBaseSelectionChanged(ComboBox cb)
        {
            var selectedItem = cb.SelectedItem as ProductBaseModel;
            Model.ProductName = selectedItem.ProductName;
            Model.Price = selectedItem.Price;
            Model.ProductCode = selectedItem.ProductCode;
            Model.ClassID = selectedItem.ClassID.Value.ToString();
            Model.Weight = selectedItem.Weight.Value.ToString();
            NotifyOfPropertyChange(() => Model);
        }

        public void ProcessBatchDetailSelectionChanged(ComboBox cb)
        {
            var selectedItem = cb.SelectedItem as ProcessBatchDetailModel;
            Model.ProcessEPC = selectedItem.ProcessEPC;
            NotifyOfPropertyChange(() => Model);
        }

        
        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iProcessProductService.InsertSingleProcessProduct(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iProcessProductService.UpdateSingleProcessProduct(Model);
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
