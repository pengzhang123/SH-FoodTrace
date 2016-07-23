using Caliburn.Micro;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(SaleBaseViewModel))]
    public class SaleBaseViewModel : Screen, IMainScreenTabItem
    {
        private ISaleBaseService SaleBaseService = new SaleBaseService();

        private BindableCollection<SaleBaseModel> _models;

        public BindableCollection<SaleBaseModel> ModelCollection
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

        public SaleBaseViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private void LoadData(string key)
        {
            Task.Factory.StartNew(() =>
            {
                var list = SaleBaseService.GetPagerSaleBase(key, 1, 5);
                ModelCollection = new BindableCollection<SaleBaseModel>(list);
            });
        }

        public void LoadUserControl(SaleBaseView view)
        {
            LoadData(string.Empty);
        }

        public int TabItemIndex { get; set; }

        public void Add()
        {

            var vm = IoC.Get<SaleBaseEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new SaleBaseModel {
                IsLocked = true,
                IsShow = true
            };
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "添加地块" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
            if (result ?? false)
            {
                LoadData(string.Empty);
            }
        }

        public void GridMouseDoubleClick(DataGrid dg, MouseButtonEventArgs args)
        {
            var vm = IoC.Get<SaleBaseEditViewModel>();
            vm.Model = (SaleBaseModel)dg.SelectedItem;
            vm.Mode = Models.EditMode.UPDATE;
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "编辑地块" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
            if (result ?? false)
            {
                LoadData(string.Empty);
            }

        }

        public void EditRow(SaleBaseModel model)
        {
            var vm = IoC.Get<SaleBaseEditViewModel>();
            vm.Model = model;
            vm.Mode = Models.EditMode.UPDATE;
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "编辑" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
            if (result ?? false)
            {
                LoadData(string.Empty);
            }
        }

        public void DeleteRow(SaleBaseModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //var model = (SaleBaseModel)dg.SelectedItem;
                var message = SaleBaseService.DeleteSingleEntity(model.SaleID);
                if (message.Status == MessageStatus.Success)
                {
                    LoadData(string.Empty);
                }
            }
        }

        public void DeleteData(DataGrid dg)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var model = (SaleBaseModel)dg.SelectedItem;
                var message = SaleBaseService.DeleteSingleEntity(model.SaleID);
                if (message.Status == MessageStatus.Success)
                {
                    LoadData(string.Empty);
                }
            }
        }

        public void FilterData(TextBox tb)
        {
            LoadData(tb.Text);
        }
    }
}
