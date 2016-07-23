using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using System.Windows;
using System.Windows.Input;
using FoodTrace.Forms.Commands;
using System.Windows.Controls;
using FoodTrace.Forms.Helpers;
using FoodTrace.Forms.Views;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.Views.PlansMng;
using FoodTrace.Forms.ViewModels.PlansMng;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(IShell))]
    public class MainViewModel :  Conductor<IMainScreenTabItem>.Collection.OneActive,IShell
    {
        int count = 0;

        public BindableCollection<HeaderViewModel> TabItems = new BindableCollection<HeaderViewModel>();
        public BindableCollection<NaviModel> Navis { get; set; }

        public ItemsControl NaviIC { get; set; }

        public MainViewModel()
        {
            DisplayName = "";
        }

        /// <summary>
        /// 点击左侧菜单，打开Tab Panel
        /// </summary>
        /// <param name="tb"></param>
        public void OpenTab(TextBlock tb)
        {
            var item = Items.SingleOrDefault(_ => _.DisplayName == tb.Tag.ToString());
            if (item == null)
            {
                int index = count++;
                string displayName = tb.Tag.ToString();
                switch (displayName)
                {
                    case "地块管理":
                        ActivateItem(new LandBlockViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "种子管理":
                        ActivateItem(new SeedBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "种植计划管理":
                        ActivateItem(new PlansBatchViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "施肥管理":
                        ActivateItem(new PlansFertViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "防疫管理":
                        ActivateItem(new PlansDrugViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "公司管理":
                        ActivateItem(new CompanyViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "屠宰批次管理":
                        ActivateItem(new KillBatchViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "屠宰明细管理":
                        ActivateItem(new KillBatchDetailViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "屠宰管理":
                        ActivateItem(new KillCullViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "检疫管理":
                        ActivateItem(new KillDrugViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖场管理":
                        ActivateItem(new BreedBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖区域管理":
                        ActivateItem(new BreedAreaViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "圈舍管理":
                        ActivateItem(new BreedHomeViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖生物管理":
                        ActivateItem(new CultivationBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖用料管理":
                        ActivateItem(new BreedMaterialViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖健康管理":
                        ActivateItem(new BreedHealthViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖防疫管理":
                        ActivateItem(new BreedDrugViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖计划管理":
                        ActivateItem(new BreedBatchViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "养殖详细计划管理":
                        ActivateItem(new BreedBatchDetailViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "加工接收订单管理":
                        ActivateItem(new ProcessBatchViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "加工接收订单明细管理":
                        ActivateItem(new ProcessBatchDetailViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break; 
                    case "农产品工序管理":
                        ActivateItem(new ProcessBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "农产品管理":
                        ActivateItem(new ShadowBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "农产品加工管理":
                        ActivateItem(new ShadowProcessViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "产品加工管理":
                        ActivateItem(new ProcessProductViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "销售订单管理":
                        ActivateItem(new SaleBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "仓库管理":
                        ActivateItem(new WareHouseBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "仓库明细管理":
                        ActivateItem(new WareHouseDetailViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "仓库库存管理":
                        ActivateItem(new WareHouseStockViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "物流订单管理":
                        ActivateItem(new TrunApplyViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "物流订单明细管理":
                        ActivateItem(new TrunApplyDetailViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "车辆管理":
                        ActivateItem(new TrunVehicleViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "驾驶员管理":
                        ActivateItem(new TrunDriverViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "物流订单实时管理":
                        ActivateItem(new TrunTemperatrueViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "芯片管理":
                        ActivateItem(new ChipViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    case "农产品查询":
                        ActivateItem(new ShadowBaseDisplayViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                    default:
                        ActivateItem(new PlansBaseViewModel
                        {
                            TabItemIndex = index,
                            DisplayName = displayName
                        });
                        break;
                } 
                
            }
            else
            {
                ActivateItem(item);
            }
        }

        public void HideLeftPanel(Image img, Grid grid)
        {
            if (img.Tag.ToString() == "0")//Hide grid
            {
                DoubleAnimation widthAnimation =
                    new DoubleAnimation(300, 0, new Duration(TimeSpan.FromSeconds(0.8)), FillBehavior.HoldEnd);
                widthAnimation.Completed += (a,b) => {
                    grid.Visibility = System.Windows.Visibility.Collapsed;
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/FoodTrace.Forms;component/Images/Spilter.png", UriKind.RelativeOrAbsolute));
                };
                grid.BeginAnimation(Grid.WidthProperty, widthAnimation);
                img.Tag = "1";
            }
            else//Show grid
            {
                grid.Visibility = System.Windows.Visibility.Visible;
                DoubleAnimation widthAnimation =
                    new DoubleAnimation(0, 300, new Duration(TimeSpan.FromSeconds(1.5)), FillBehavior.HoldEnd);
                widthAnimation.Completed += (a, b) =>
                {
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/FoodTrace.Forms;component/Images/Spilter2.png", UriKind.RelativeOrAbsolute));
                };
                grid.BeginAnimation(Grid.WidthProperty, widthAnimation);
                img.Tag = "0";
            }
        }

        public MainViewModel(IEnumerable<IMainScreenTabItem> tabs)
        {
            Items.AddRange(tabs);
        }

        public TabControl MainTab { get; set; }

        public MainView ViewSelf { get; set; }

        //public RemoveTabItemCommand RemoveTabItemCommand { get; set; }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            ViewSelf = (view as MainView);
            (view as MainView).DataContext = this;
            NaviIC = (view as MainView).NaviIC;
            TabItems.Add(new HeaderViewModel());
            
            //MainTabSelectionChanged(MainTab, null);
            Navis = new BindableCollection<NaviModel>(App.Navis);
            NotifyOfPropertyChange(() => Navis);

        }

        public void Navi_Expanded(Expander expander)
        {
            var expanders = TreeHelper.FindVisualChildren<Expander>(NaviIC);
            var index = Convert.ToInt32(expander.Tag.ToString());
            for (int i = 0; i < Navis.Count; i++)
            {
                Navis[i].IsExpanded = false;
            }
            Navis[index-1].IsExpanded = true;
            Navis = new BindableCollection<NaviModel>(Navis);
            NotifyOfPropertyChange(() => Navis);
        }

        public void MainTabSelectionChanged(TabControl tc, SelectionChangedEventArgs args)
        {
            //TreeHelper.FindVisualChildren<TabItem>(tc).ForEach(_ =>
            //{
            //    _.Tag = "#0B71AB";
            //});
            //var tabItem = tc.SelectedItem as TabItem;
            //tabItem.Tag = "#FFF";
        }

        public void MainTabItemMouseEnter(TabItem ti, MouseEventArgs args)
        {
            if (ti.IsSelected)
            {
                ti.Tag = "#FFF";
            }
            else
                ti.Tag = "#FFF";
        }

        public void MainTabItemMouseLeave(TabItem ti, MouseEventArgs args)
        {
            if (ti.IsSelected)
            {
                ti.Tag = "#FFF";
            }
            else
                ti.Tag = "#0B71AB";
        }

        void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("CloseTabItem");
        }

        void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void LoginOut()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void CloseTabItem(TextBlock tb)
        {
            Items.Remove(Items.SingleOrDefault(_=>_.DisplayName == tb.Tag.ToString()));
        }
    }
}
