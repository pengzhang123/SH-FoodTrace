﻿using Caliburn.Micro;
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
    [Export(typeof(ProcessProductViewModel))]
    public class ProcessProductViewModel : Screen, IMainScreenTabItem
    {
        private IProcessProductService iProcessProductService = new ProcessProductService();

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

        private BindableCollection<ProcessProductModel> _models;

        public BindableCollection<ProcessProductModel> ModelCollection
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

        public ProcessProductViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private void LoadData(string key, int pageIndex = 1, int pageSize = 10)
        {
            pbLoading.Visibility = Visibility.Visible;
            Task.Factory.StartNew(() =>
            {
                var list = iProcessProductService.GetPagerProcessProduct(key, pageIndex, pageSize);
                var total = iProcessProductService.GetProcessProductCount(key);
                var pageCount = total / pageSize == 0 ? 1 : (total / pageSize) + (total % pageSize == 0 ? 0 : 1);
                ModelCollection = new BindableCollection<ProcessProductModel>(list);
                PagerModel = new PagerModel { TotalCount = total, PageCount = pageCount, DetailMsg = string.Format("[共{0}页/共{1}条]", pageCount, total) };
            }).ContinueWith((task) =>
            {
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

        public void LoadUserControl(ProcessProductView view)
        {
            pbLoading = view.LoadingProgressBar;
            LoadData(string.Empty);
        }

        public int TabItemIndex { get; set; }

        public void Add()
        {

            var vm = IoC.Get<ProcessProductEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new ProcessProductModel
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
            var vm = IoC.Get<ProcessProductEditViewModel>();
            vm.Model = (ProcessProductModel)dg.SelectedItem;
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

        public void EditRow(ProcessProductModel model)
        {
            var vm = IoC.Get<ProcessProductEditViewModel>();
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

        public void DeleteRow(ProcessProductModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var message = iProcessProductService.DeleteSingleProcessProduct(model.PProductID);
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
                var model = (ProcessProductModel)dg.SelectedItem;
                var message = iProcessProductService.DeleteSingleProcessProduct(model.PProductID);
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
