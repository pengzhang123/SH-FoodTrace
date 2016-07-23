using Caliburn.Micro;
using FoodTrace.Forms.Helpers;
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
    [Export(typeof(ShadowBaseDisplayViewModel))]
    public class ShadowBaseDisplayViewModel : Screen, IMainScreenTabItem
    {
        public int TabItemIndex { get; set; }

        private IShadowBaseService iShadowBaseService = new ShadowBaseService();
        private IShadowProcessService iShadowProcessService = new ShadowProcessService();
        private ICompanyService iCompanyService = new CompanyService();
        private IProductBaseService iProductBaseService = new ProductBaseService();
        private IProductTypeService iProductTypeService = new ProductTypeService();
        private IProductSpecService iProductSpecService = new ProductSpecService();
        public ShadowBaseModel Model { get; set; }

        public ShadowBaseDisplayView ViewSelf { get; set; }

        public ShadowBaseDisplayViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        public void LoadUserControl(ShadowBaseDisplayView view) {
            //Init Control
            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            var products = iProductBaseService.GetPagerProductBase("", 1, 100);
            var productTypes = iProductTypeService.GetPagerProductType("", 1, 100);
            var productSpecs = iProductSpecService.GetPagerProductSpec("", 1, 100);

            view.cbCompany.ItemsSource = companys;
            view.cbCompany.SelectedIndex = -1;
            view.cbProduct.ItemsSource = products;
            view.cbProduct.SelectedIndex = -1;
            view.cbProductType.ItemsSource = productTypes;
            view.cbProductType.SelectedIndex = -1;

            ViewSelf = view;
        }

        ReaderHelper reader = null;

        public void ProductSelectionChanged(ComboBox cb)
        {
            if (cb.SelectedIndex >= 0)
            {
                Model.ProductName = (cb.SelectedItem as ProductBaseModel).ProductName;
                NotifyOfPropertyChange(() => Model);
            }
        }

        public void QueryShadowBase()
        {
            ResetControl();

            if (reader == null)
            {
                reader = new ReaderHelper();
            }

            var chipCode = reader.Read();

            var shadow = iShadowBaseService.GetShawInfoByChipCode(chipCode);

            if (shadow != null)
            {
                Model = shadow;
                NotifyOfPropertyChange(() => Model);

                ModelCollection = new BindableCollection<ShadowProcessModel>(shadow.ShadowProcess.ToList());
            }
            else
            {
                System.Windows.MessageBox.Show("没有找到对应的农产品");

            }
            
        }

        private BindableCollection<ShadowProcessModel> _models;

        public BindableCollection<ShadowProcessModel> ModelCollection
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
                NotifyOfPropertyChange(() => ModelCollection);
            }
        }

        void ResetControl()
        {
            TreeHelper.FindVisualChildren<TextBox>(ViewSelf).ForEach(_=> {
                _.Text = "";
            });
            TreeHelper.FindVisualChildren<ComboBox>(ViewSelf).ForEach(_ => {
                _.SelectedIndex = -1;
            });
            TreeHelper.FindVisualChildren<CheckBox>(ViewSelf).ForEach(_ => {
                _.IsChecked = false;
            });

            ModelCollection = new BindableCollection<ShadowProcessModel>(new List<ShadowProcessModel>());
        }

    }
}
