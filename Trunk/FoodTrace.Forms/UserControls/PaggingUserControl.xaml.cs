using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodTrace.Forms.UserControls
{
    /// <summary>
    /// Interaction logic for PaggingUserControl.xaml
    /// </summary>
    public partial class PaggingUserControl : UserControl
    {
        public PaggingUserControl()
        {
            InitializeComponent();
        }

        #region 路由事件

        //public static readonly RoutedEvent PageIndexChangedEvent = EventManager.RegisterRoutedEvent("PageIndexChanged", RoutingStrategy.Bubble, typeof(EventHandler<PageIndexChangedEventArgs>), typeof(PaggingUserControl));

        //public event RoutedEventHandler PageIndexChanged
        //{
        //    add { AddHandler(PageIndexChangedEvent, value); }
        //    remove { RemoveHandler(PageIndexChangedEvent, value); }
        //}

        public static readonly RoutedEvent PageIndexChangedEvent = EventManager.RegisterRoutedEvent("PageIndexChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(PaggingUserControl));

        public event RoutedPropertyChangedEventHandler<int> PageIndexChanged
        {
            add { AddHandler(PageIndexChangedEvent, value); }
            remove { RemoveHandler(PageIndexChangedEvent, value); }
        }

        public static readonly RoutedEvent PagePrintEvent = EventManager.RegisterRoutedEvent("PagePrint", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(PaggingUserControl));

        public event RoutedPropertyChangedEventHandler<int> PagePrint
        {
            add { AddHandler(PagePrintEvent, value); }
            remove { RemoveHandler(PagePrintEvent, value); }
        }

        #endregion

        #region 依赖属性



        public string DetailMsg
        {
            get { return (string)GetValue(DetailMsgProperty); }
            set { SetValue(DetailMsgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetailMsg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailMsgProperty =
            DependencyProperty.Register("DetailMsg", typeof(string), typeof(PaggingUserControl), new PropertyMetadata("[共0页/共0条]"));




        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(PaggingUserControl), new UIPropertyMetadata(12));

        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(PaggingUserControl), new UIPropertyMetadata(1, new PropertyChangedCallback(OnPageIndexChanged)));

        private static void OnPageIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uc = new PaggingUserControl();
            var index = (int)e.NewValue;

            

            Console.WriteLine("当前页{0}", index);
        }

        public int Total
        {
            get { return (int)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total", typeof(int), typeof(PaggingUserControl), new UIPropertyMetadata(0));



        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(PaggingUserControl), new UIPropertyMetadata(0));

        #endregion

        #region 按钮事件

        private void Print_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(
            PageIndex, ++PageIndex, PagePrintEvent);
            RaiseEvent(args);
        }

        private void NextPage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // PageIndex++;
            // 触发事件，结尾一定要使用RaiseEvent(args)来触发路由事件。
            //PageIndexChangedEventArgs args = new PageIndexChangedEventArgs(PageIndexChangedEvent, this);
            //args.PageIndex = PageIndex++;
            RoutedPropertyChangedEventArgs<int> args =  new RoutedPropertyChangedEventArgs<int>(
            PageIndex, ++PageIndex, PageIndexChangedEvent);
            RaiseEvent(args);
        }

        private void PrevPage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(
            PageIndex, --PageIndex, PageIndexChangedEvent);
            RaiseEvent(args);
        }

        private void FirstPage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(
            PageIndex, 1, PageIndexChangedEvent);
            PageIndex = 1;
            RaiseEvent(args);
        }

        private void LastPage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(
            PageIndex, PageCount, PageIndexChangedEvent);
            PageIndex = PageCount;
            RaiseEvent(args);
        }

        #endregion

    }
}
