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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(ShadowBaseEditViewModel))]
    public class ShadowBaseEditViewModel : ViewAware
    {
        private IShadowBaseService iShadowBaseService = new ShadowBaseService();
        private ICompanyService iCompanyService = new CompanyService();
        private IProductBaseService iProductBaseService = new ProductBaseService();
        private IProductTypeService iProductTypeService = new ProductTypeService();
        private IProductSpecService iProductSpecService = new ProductSpecService();

        public ShadowBaseModel Model { get; set; }
        public EditMode Mode { get; set; }

        public ShadowBaseEditView ViewSelf;

        public void ProductSelectionChanged(ComboBox cb)
        {
            Model.ProductName = (cb.SelectedItem as ProductBaseModel).ProductName;
            NotifyOfPropertyChange(()=>Model);
        }

        public void EpcGotFocus()
        {
            CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
            //商品类别
            pro96.GoodsType = "3";
            //商品代号
            pro96.GoodsCode = Model.ProductID.ToString();
            //生成日期
            pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
            var maxId = MaxId;
            //销售店号
            pro96.BusinessCode = maxId;
            //商品号型
            pro96.GoodsSize = "255";
            //序号
            pro96.SeqNo = maxId;

            pro96.EpcType = "4";
            Model.ShadowEPC = pro96.PackEpc();
            NotifyOfPropertyChange(() => Model);
        }


        public string MaxId
        {
            get
            {
                int maxId = 10000;
                string path = "maxid";

                if (File.Exists(path))
                {
                    using (TextReader reader = new StreamReader(path))
                    {
                        string txt = reader.ReadToEnd();
                        maxId = SerializeUtilities.Desrialize<int>(txt);
                    }
                }

                int newValue = maxId + 1;

                using (TextWriter writer = new StreamWriter(path, false))
                {
                    string txt = SerializeUtilities.Serialize<int>(newValue);
                    writer.Write(txt);
                }

                return maxId.ToString();
            }
        }

        public string QRCode
        {
            get
            {
                int qrcode = 10000000;
                string path = "qrcode";

                if (File.Exists(path))
                {
                    using (TextReader reader = new StreamReader(path))
                    {
                        string txt = reader.ReadToEnd();
                        qrcode = SerializeUtilities.Desrialize<int>(txt);
                    }
                }

                int newValue = qrcode + 1;

                using (TextWriter writer = new StreamWriter(path, false))
                {
                    string txt = SerializeUtilities.Serialize<int>(newValue);
                    writer.Write(txt);
                }

                return qrcode.ToString();
            }
        }


        public void LoadUserControl(ShadowBaseEditView view)
        {
            ViewSelf = view;
            //Init Control
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            var products = iProductBaseService.GetPagerProductBase("", 1, 100);
            var productTypes = iProductTypeService.GetPagerProductType("", 1, 100);
            var productSpecs = iProductSpecService.GetPagerProductSpec("", 1, 100);

            view.cbCompany.ItemsSource = companys;
            view.cbCompany.SelectedIndex = 0;
            view.cbProduct.ItemsSource = products;
            view.cbProduct.SelectedIndex = 0;
            Model.ProductName = products[0].ProductName;
            
            view.cbProductType.ItemsSource = productTypes;
            view.cbProductType.SelectedIndex = 0;
            //view.cb.ItemsSource = companys;
            //view.cbCompany.SelectedIndex = 0;
            Model.ORCode = QRCode;
            NotifyOfPropertyChange(() => Model);
        }

        public void Save()
        {
            if (Mode == EditMode.CREATE)
            {
                var result = iShadowBaseService.InsertSingleShadowBase(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iShadowBaseService.UpdateSingleShadowBase(Model);
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
