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
using WL.NTAG203.Reader;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(ChipViewModel))]
    public class ChipViewModel : Screen, IMainScreenTabItem
    {
        public int TabItemIndex { get; set; }

        public ChipViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private ITidService tidService = new TidService();

        private BindableCollection<TIDModel> _models;

        public BindableCollection<TIDModel> ModelCollection
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


        private void LoadData(string key)
        {
            Task.Factory.StartNew(() =>
            {
                var list = tidService.GetPagerTid( 1, 50);
                ModelCollection = new BindableCollection<TIDModel>(list);
            });
        }

        public void LoadUserControl(ChipView view)
        {
            LoadData(string.Empty);
        }

        public void Add()
        {

            var vm = IoC.Get<ChipEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new TIDModel
            {
                IsUse = false,
                IsLocked = true,
                IsShow = true
            };
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "添加芯片" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
            if (result ?? false)
            {
                LoadData(string.Empty);
            }
        }

        public void GridMouseDoubleClick(DataGrid dg, MouseButtonEventArgs args)
        {
            var vm = IoC.Get<ChipEditViewModel>();
            vm.Model = (TIDModel)dg.SelectedItem;
            vm.Mode = Models.EditMode.UPDATE;
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "编辑芯片" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
            if (result ?? false)
            {
                LoadData(string.Empty);
            }

        }

        public void EditRow(TIDModel model)
        {
            var vm = IoC.Get<ChipEditViewModel>();
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

        public void DeleteRow(TIDModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //var model = (TIDModel)dg.SelectedItem;
                var message = tidService.DeleteSingleTid(model.TID);
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
                var model = (TIDModel)dg.SelectedItem;
                var message = tidService.DeleteSingleTid(model.TID);
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
