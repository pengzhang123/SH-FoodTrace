using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using FoodTrace.Forms.ViewModels;
using FoodTrace.Forms.Views;
using System.Reflection;
using FoodTrace.Forms.Helpers;
using System.Windows.Media.Imaging;

namespace FoodTrace.Forms
{
    public class MefBootstrapper : BootstrapperBase
    {
        /// <summary>
        /// 2.0 必须显式加上构造函数
        /// </summary>
        public MefBootstrapper()
        {
            Initialize();
        }

        private CompositionContainer _container;

        protected override void Configure()
        {
            _container = new CompositionContainer(new AggregateCatalog(
                AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                ));

            //var viewModels =
            //Assembly.GetExecutingAssembly().GetExportedTypes().Where(x => x.GetInterface(typeof(IMainScreenTabItem).Name) != null && !x.IsAbstract && x.IsClass);
            //_container.ComposeParts(typeof(IMainScreenTabItem), viewModels);

            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new MetroWindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);

            _container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Count() > 0)
                return exports.First();

            throw new Exception(string.Format("无法创建契约 {0} 的实例", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            LogManager.GetLog = (type) => new Log4netLogger(type);

            LogManager.GetLog(typeof(MefBootstrapper)).Error(new SystemException { Source = "系统启动" });
            log4net.LogManager.GetLogger(typeof(MefBootstrapper)).Error("系统启动");

            Application.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            var vm = IoC.Get<LoginViewModel>();
            if (vm != null)
            {
                var result = IoC.Get<MetroWindowManager>().ShowDialog(vm, null, new Dictionary<string, object>{
                        {"Width", 1262},
                        {"Height", 697},
                    {"Icon", new BitmapImage(new Uri("pack://application:,,,/FoodTrace.Forms;component/favicon.ico", UriKind.Absolute)) },
                        {"UseNoneWindowStyle", true},

                        //{"Background", new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0,0,0,0))},
                        {"ResizeMode", System.Windows.ResizeMode.NoResize},
                            {"BorderBrush",new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent)}
                    });


                if (result ?? false)
                {
                    Application.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;

                    DisplayRootViewFor<IShell>(new Dictionary<string, object> { 
                       //{"Title", "环县溯源食品管理系统"},
                       {"WindowState", System.Windows.WindowState.Maximized},
                       //{"Icon", new BitmapImage(new Uri("pack://application:,,,/FoodTrace.Forms;component/favicon.ico", UriKind.Absolute)) },
                       {"BorderBrush",new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(1,65,177,225))}
                   });

                    return;
                }

                Application.Shutdown();
            }

        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogManager.GetLog(typeof(MefBootstrapper)).Info("我们很抱歉，当前应用程序遇到一些问题，该操作已经终止，请进行重试，如果问题继续存在，请联系管理员.");
            LogManager.GetLog(typeof(MefBootstrapper)).Error(e.Exception);//这里通常需要给用户一些较为友好的提示，并且后续可能的操作
            log4net.LogManager.GetLogger(typeof(MefBootstrapper)).Error(e.Exception);
            e.Handled = true;//使用这一行代码告诉运行时，该异常被处理了，不再作为UnhandledException抛出了。
        }

        protected override void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //Console.WriteLine(e.Exception.Message);
            //e.Handled = true;
            base.OnUnhandledException(sender, e);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            LogManager.GetLog(typeof(MefBootstrapper)).Info(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            log4net.LogManager.GetLogger(typeof(MefBootstrapper)).Error(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            throw ex;

        }

    }
}
