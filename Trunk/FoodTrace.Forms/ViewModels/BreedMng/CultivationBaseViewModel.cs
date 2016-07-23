using Caliburn.Micro;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.UserControls;
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
     [Export(typeof(CultivationBaseViewModel))]
    public class CultivationBaseViewModel : Screen, IMainScreenTabItem
    {
        private ICultivationBaseService iCultivationBaseService = new CultivationBaseService();

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

        private BindableCollection<CultivationBaseModel> _models;

        public BindableCollection<CultivationBaseModel> ModelCollection
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

        public CultivationBaseViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private void LoadData(string key, int pageIndex = 1, int pageSize = 2)
        {
            pbLoading.Visibility = Visibility.Visible;
            Task.Factory.StartNew(() =>
            {
                var list = iCultivationBaseService.GetPagerCultivationBase(key, pageIndex, pageSize);
                var total = iCultivationBaseService.GetCultivationBaseCount(key);
                var pageCount = total / pageSize == 0 ? 1 : (total / pageSize) + (total % pageSize == 0 ? 0 : 1);
                ModelCollection = new BindableCollection<CultivationBaseModel>(list);
                PagerModel = new PagerModel { TotalCount = total, PageCount = pageCount, DetailMsg = string.Format("[共{0}页/共{1}条]", pageCount, total) };
            }).ContinueWith((task) => {
                System.Windows.Application.Current.Dispatcher.Invoke(new System.Action(() =>
                {
                    pbLoading.Visibility = Visibility.Collapsed;
                }));
            });
        }

        //public void PageIndexChanged(PaggingUserControl pager, PageIndexChangedEventArgs args)
        public void PageIndexChanged(PaggingUserControl pager, RoutedPropertyChangedEventArgs<int> args)
        {
            LoadData("", args.NewValue);
        }

        public void PagePrint(PaggingUserControl pager, RoutedPropertyChangedEventArgs<int> args)
        {
            MessageBox.Show("打印");
        }

        public void LoadUserControl(CultivationBaseView view)
        {
            pbLoading = view.LoadingProgressBar;
            LoadData(string.Empty);
        }

        public int TabItemIndex { get; set; }

        public void Add()
        {

            var vm = IoC.Get<CultivationBaseEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new CultivationBaseModel
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
            var vm = IoC.Get<CultivationBaseEditViewModel>();
            vm.Model = (CultivationBaseModel)dg.SelectedItem;
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

        public void EditRow(CultivationBaseModel model)
        {
            var vm = IoC.Get<CultivationBaseEditViewModel>();
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

        public void DeleteRow(CultivationBaseModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var message = iCultivationBaseService.DeleteSingleEntity(model.CultivationID);
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
                var model = (CultivationBaseModel)dg.SelectedItem;
                var message = iCultivationBaseService.DeleteSingleEntity(model.CultivationID);
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
