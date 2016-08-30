using Caliburn.Micro;
using FoodTrace.Forms.Views.PlansMng;
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

namespace FoodTrace.Forms.ViewModels.PlansMng
{
    [Export(typeof(LandBlockViewModel))]
    public class LandBlockViewModel : Screen, IMainScreenTabItem
    {
        private ILandBlockService landBlockService = new LandBlockService();

        private BindableCollection<LandBlockModel> _models;

        public BindableCollection<LandBlockModel> ModelCollection{

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

        public LandBlockViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private void LoadData(string key)
        {
            Task.Factory.StartNew(() =>
            {
                var list = landBlockService.GetPagerLandBlock(key, 1, 10);
                ModelCollection = new BindableCollection<LandBlockModel>(list);
            });
        }

        public void LoadUserControl(LandBlockView view)
        {
            LoadData(string.Empty);
        }

        public int TabItemIndex { get; set; }

        public void Add()
        {
            
            var vm = IoC.Get<LandBlockEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new LandBlockModel {
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
            var vm = IoC.Get<LandBlockEditViewModel>();
            vm.Model = (LandBlockModel)dg.SelectedItem;
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

        public void EditRow(LandBlockModel model)
        {
            var vm = IoC.Get<LandBlockEditViewModel>();
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

        public void DeleteRow(LandBlockModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //var model = (LandBlockModel)dg.SelectedItem;
                var message = landBlockService.DeleteSingleLandBlock(model.BlockID);
                if (message.Status == MessageStatus.Success)
                {
                    LoadData(string.Empty);
                }
            }
        }

        public void DeleteData(DataGrid dg)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                var model = (LandBlockModel)dg.SelectedItem;
                var message = landBlockService.DeleteSingleLandBlock(model.BlockID);
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
