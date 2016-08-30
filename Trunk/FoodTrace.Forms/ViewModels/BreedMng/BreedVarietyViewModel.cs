using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.UserControls;
using FoodTrace.Forms.Views.BreedMng;
using FoodTrace.IService;
using FoodTrace.IService.BreedMng;
using FoodTrace.Model;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;
using FoodTrace.Service;
using FoodTrace.Service.BreedMng;

namespace FoodTrace.Forms.ViewModels.BreedMng
{
     [Export(typeof(BreedVarietyViewModel))]
    public class BreedVarietyViewModel : Screen, IMainScreenTabItem
    {
         private IBreedVarietyService breedVarietyService = new BreedVarietyService();
         public int TabItemIndex { get; set; }
        private ProgressBar pbLoading;

        private PagerModel _pagerModel;

        public PagerModel PagerModel
        {
            get
            {
                return _pagerModel;
            }
            set
            {
                _pagerModel = value;
                NotifyOfPropertyChange(() => PagerModel);
            }
        }

        private BindableCollection<BreedVarietyDto> _models;

        public BindableCollection<BreedVarietyDto> ModelCollection
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

        public BreedVarietyViewModel()
        {
            DisplayName = "BreedVarietyViewModel";
            TabItemIndex = 0;
        }

        public void LoadUserControl(BreedVarietyView view)
        {
            pbLoading = view.LoadingProgressBar;
            LoadData(string.Empty);
        }

        private void LoadData(string key, int pageIndex = 1, int pageSize = 10)
        {
            pbLoading.Visibility = Visibility.Visible;
            Task.Factory.StartNew(() =>
            {
                var list = breedVarietyService.GetVarietyGridList(key,pageIndex, pageSize);

                int total = list.total;
                var pageCount = total / pageSize == 0 ? 1 : (total / pageSize) + (total % pageSize == 0 ? 0 : 1);
                ModelCollection = new BindableCollection<BreedVarietyDto>(list.rows);
                PagerModel = new PagerModel { TotalCount = total, PageCount = pageCount, DetailMsg = string.Format("[共{0}页/共{1}条]", pageCount, total) };
            }).ContinueWith((task) =>
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new System.Action(() =>
                {
                    pbLoading.Visibility = Visibility.Collapsed;
                }));
            });
        }
        public void PageIndexChanged(PaggingUserControl pager, RoutedPropertyChangedEventArgs<int> args)
        {
            LoadData("", args.NewValue);
        }

        public void Add()
        {

            var vm = IoC.Get<BreedVarietyEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new BreedVarietyDto()
            {
                IsLocked = true,
                IsShow = true
            };
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "添加" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
            if (result ?? false)
            {
                LoadData(string.Empty);
            }
        }

        public void GridMouseDoubleClick(DataGrid dg, MouseButtonEventArgs args)
        {
            var vm = IoC.Get<BreedVarietyEditViewModel>();
            vm.Model = (BreedVarietyDto)dg.SelectedItem;
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

        public void EditRow(BreedVarietyDto model)
        {
            var vm = IoC.Get<BreedVarietyEditViewModel>();
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

        public void DeleteRow(BreedVarietyDto model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var message = breedVarietyService.DeleteByIds(model.VarietyId.ToString());
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
                var model = (BreedVarietyDto)dg.SelectedItem;
                var message = breedVarietyService.DeleteByIds(model.VarietyId.ToString());
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
