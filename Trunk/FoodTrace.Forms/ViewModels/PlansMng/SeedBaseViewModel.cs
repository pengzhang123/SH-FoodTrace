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

    [Export(typeof(SeedBaseViewModel))]
    public class SeedBaseViewModel : Screen, IMainScreenTabItem
    {
        private ISeedBaseService iSeedBaseService = new SeedBaseService();

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

        private BindableCollection<SeedBaseModel> _models;

        public BindableCollection<SeedBaseModel> ModelCollection
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

        public SeedBaseViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        public int TabItemIndex { get; set; }

        private void LoadData(string key, int pageIndex = 1, int pageSize =10)
        {
            pbLoading.Visibility = Visibility.Visible;
            Task.Factory.StartNew(() =>
            {
                var list = iSeedBaseService.GetPagerSeedBase(key, pageIndex, pageSize);
                var total = iSeedBaseService.GetSeedBaseCount(key);
                var pageCount = total / pageSize == 0 ? 1 : (total / pageSize) + (total % pageSize == 0 ? 0 : 1);
                ModelCollection = new BindableCollection<SeedBaseModel>(list);
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

        public void LoadUserControl(SeedBaseView view)
        {
            pbLoading = view.LoadingProgressBar;
            LoadData(string.Empty);
        }

        public void Add()
        {

            var vm = IoC.Get<SeedBaseEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new SeedBaseModel {
                IsLocked = true,
                IsShow = true
            };
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "添加种子" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
        
                LoadData(string.Empty);
            
        }

        public void DeleteRow(SeedBaseModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var message = iSeedBaseService.DeleteSingleSeedBase(model.SeedID);
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
                var model = (SeedBaseModel)dg.SelectedItem;
                var message = iSeedBaseService.DeleteSingleSeedBase(model.SeedID);
                if (message.Status == MessageStatus.Success)
                {
                    LoadData(string.Empty);
                }
            }
        }

        public void GridMouseDoubleClick(DataGrid dg, MouseButtonEventArgs args)
        {
            var vm = IoC.Get<SeedBaseEditViewModel>();
            vm.Model = (SeedBaseModel)dg.SelectedItem;
            vm.Mode = Models.EditMode.UPDATE;
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "编辑种子" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });
         
                LoadData(string.Empty);
            


        }


        public void EditRow(SeedBaseModel model)
        {
            var vm = IoC.Get<SeedBaseEditViewModel>();
            vm.Model = model;
            vm.Mode = Models.EditMode.UPDATE;
            var result = IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "编辑" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 600} });

                LoadData(string.Empty);
            
        }


        public void FilterData(TextBox tb)
        {
            LoadData(tb.Text);
        }
    }
}
