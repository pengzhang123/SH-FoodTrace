using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Forms.Models;
using FoodTrace.Service;

namespace FoodTrace.Forms
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static UserBaseModel CurrentUser { get; set; }

        public static List<NaviModel> Navis { get; private set; }
      

        static App()
        {

            Navis = new List<NaviModel> {
                
                new NaviModel {
                     Name="种植管理子系统",IsExpanded=false,NaviIndex=1,
                      Menus=new List<string> { "地块管理", "种子管理", "种植计划管理", "施肥管理", "防疫管理" }
                },new NaviModel {
                     Name="屠宰管理子系统",IsExpanded=false,NaviIndex=2,
                      Menus=new List<string> { "屠宰批次管理", "屠宰明细管理", "屠宰管理", "检疫管理" }
                },new NaviModel {
                     Name="养殖管理子系统",IsExpanded=false,NaviIndex=3,
                      Menus=new List<string> { "养殖场管理", "养殖区域管理", "圈舍管理", "养殖生物管理", "养殖用料管理", "养殖健康管理", "养殖防疫管理", "养殖计划管理", "养殖详细计划管理" }
                },new NaviModel {
                     Name="加工管理子系统",IsExpanded=false,NaviIndex=4,
                      Menus=new List<string> { "加工接收订单管理", "加工接收订单明细管理", "产品加工管理", "农产品管理", "农产品加工管理", "农产品工序管理" }
                },new NaviModel {
                     Name="销售管理子系统",IsExpanded=false,NaviIndex=5,
                      Menus=new List<string> { "销售订单管理", "仓库管理", "仓库明细管理","仓库库存管理" }
                },new NaviModel {
                     Name="冷链物流管理子系统",IsExpanded=false,NaviIndex=6,
                      Menus=new List<string> { "物流订单管理", "物流订单明细管理", "车辆管理", "驾驶员管理", "物流订单实时管理" }
                },
                new NaviModel {
                     Name="平台管理系统",IsExpanded=false,NaviIndex=7,
                      Menus=new List<string> { "芯片管理", "农产品查询" }
                }
            };
        }

    }
}
