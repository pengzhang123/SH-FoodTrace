using Caliburn.Micro;
using FoodTrace.Forms.Helpers;
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
using System.Windows.Media.Imaging;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(ShadowBaseViewModel))]
    public class ShadowBaseViewModel : Screen, IMainScreenTabItem
    {
        private IShadowBaseService iShadowBaseService = new ShadowBaseService();
        private ITidService iTidService = new TidService();

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

        private BindableCollection<ShadowBaseModel> _models;

        public BindableCollection<ShadowBaseModel> ModelCollection
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

        public ShadowBaseViewModel()
        {
            DisplayName = "PlansBaseViewModel";
            TabItemIndex = 0;
        }

        private void LoadData(string key, int pageIndex = 1, int pageSize = 2)
        {
            pbLoading.Visibility = Visibility.Visible;
            Task.Factory.StartNew(() =>
            {
                var list = iShadowBaseService.GetPagerShadowBase(key, pageIndex, pageSize);
                var total = iShadowBaseService.GetShadowBaseCount(key);
                var pageCount = total / pageSize == 0 ? 1 : (total / pageSize) + (total % pageSize == 0 ? 0 : 1);
                ModelCollection = new BindableCollection<ShadowBaseModel>(list);
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

        public void LoadUserControl(ShadowBaseView view)
        {
            pbLoading = view.LoadingProgressBar;
            LoadData(string.Empty);
        }

        public int TabItemIndex { get; set; }

        public void Add()
        {

            var vm = IoC.Get<ShadowBaseEditViewModel>();
            vm.Mode = Models.EditMode.CREATE;
            vm.Model = new ShadowBaseModel
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
            var vm = IoC.Get<ShadowBaseEditViewModel>();
            vm.Model = (ShadowBaseModel)dg.SelectedItem;
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

        public void EditRow(ShadowBaseModel model)
        {
            var vm = IoC.Get<ShadowBaseEditViewModel>();
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

        public void DeleteRow(ShadowBaseModel model)
        {
            var result = MessageBox.Show("是否删除", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var message = iShadowBaseService.DeleteSingleShadowBase(model.ShadowID);
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
                var model = (ShadowBaseModel)dg.SelectedItem;
                var message = iShadowBaseService.DeleteSingleShadowBase(model.ShadowID);
                if (message.Status == MessageStatus.Success)
                {
                    LoadData(string.Empty);
                }
            }
        }

        public void AddChipCode(DataGrid dg)
        {
            var result = MessageBox.Show("是否添加芯片吗", "提示", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ReaderHelper reader = new ReaderHelper();
                var code = reader.Read();
                var chip = iTidService.GetTidByChipCode(code);

                if (chip.IsUse)
                {
                    MessageBox.Show("该芯片已经使用");
                    return;
                }
                var model = (ShadowBaseModel)dg.SelectedItem;

                model.ChipCode = code;
                var message = iShadowBaseService.UpdateSingleShadowBase(model);

                chip.IsUse = true;
                iTidService.UpdateSingleTid(chip);
                if (message.Status == MessageStatus.Success)
                {
                    LoadData(string.Empty);
                }
            }
        }

        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }

            return bitmapImage;
        }

        public void ShowQR(DataGrid dg)
        {

            var model = (ShadowBaseModel)dg.SelectedItem;
            var vm = IoC.Get<QRViewModel>();
            vm.QRImage = BitmapToBitmapImage(QRHelp.GenerateQR(model.ORCode));
            IoC.Get<IWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                {"Title", "二维码" },{"ResizeMode", System.Windows.ResizeMode.NoResize},
                        {"Width", 450},
                        {"Height", 450} });

        }

        public void FilterData(TextBox tb)
        {
            LoadData(tb.Text);
        }
    }
}
