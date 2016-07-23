using Caliburn.Micro;
using FoodTrace.Forms.Views;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service.TrunMng;
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
    [Export(typeof(TrunVehicleViewModel))]
    public class TrunVehicleViewModel : Screen, IMainScreenTabItem
    {
        private ITrunVehicleService TrunVehicleService = new TrunVehicleService();

        private BindableCollection<TrunVehicleModel> _models;

        public BindableCollection<TrunVehicleModel> ModelCollection
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

        public TrunVehicleViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private void LoadData(string key)
        {
            Task.Factory.StartNew(() =>
            {
                var list = TrunVehicleService.GetPagerTrunVehicle(key, 1, 5);
                ModelCollection = new BindableCollection<TrunVehicleModel>(list);
            });
        }

        public void LoadUserControl(TrunVehicleView view)
        {
            LoadData(string.Empty);
        }

        public int TabItemIndex { get; set; }

        public void Add()
        {

            var vm = IoC.Get<TrunVehicleEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new TrunVehicleModel {
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
            var vm = IoC.Get<TrunVehicleEditViewModel>();
            vm.Model = (TrunVehicleModel)dg.SelectedItem;
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

        public void EditRow(TrunVehicleModel model)
        {
            var vm = IoC.Get<TrunVehicleEditViewModel>();
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

        public void DeleteRow(TrunVehicleModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //var model = (TrunVehicleModel)dg.SelectedItem;
                var message = TrunVehicleService.DeleteSingleTrunVehicle(model.VehicleID);
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
                var model = (TrunVehicleModel)dg.SelectedItem;
                var message = TrunVehicleService.DeleteSingleTrunVehicle(model.VehicleID);
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
