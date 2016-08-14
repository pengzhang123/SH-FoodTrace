using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MahApps.Metro.Controls;
using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace FoodTrace.Forms
{
    [Export(typeof(MetroWindowManager))]
    public class MetroWindowManager : WindowManager
    {
        private ResourceDictionary[] _resourceDictionaries;

        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            MetroWindow window = null;
            Window inferOwnerOf;
            if (view is MetroWindow)
            {
                window = CreateCustomWindow(view, true);
                inferOwnerOf = InferOwnerOf(window);
                if (inferOwnerOf != null && isDialog)
                {
                    window.Owner = inferOwnerOf;
                }
            }

            if (window == null)
            {
                window = CreateCustomWindow(view, false);
            }

            ConfigureWindow(window);
            window.SetValue(View.IsGeneratedProperty, true);
            inferOwnerOf = InferOwnerOf(window);
            if (inferOwnerOf != null)
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                window.Owner = inferOwnerOf;
            }
            else
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            window.BorderThickness = new Thickness(2);
            window.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(154, 34, 46));
            
            return window;
        }

        public virtual void ConfigureWindow(MetroWindow window)
        {

        }
        public virtual MetroWindow CreateCustomWindow(object view, bool windowIsView)
        {
            MetroWindow result;
            if (windowIsView)
            {
                result = view as MetroWindow;
            }
            else
            {
                result = new MetroWindow
                {
                    Content = view
                };
            }
            result.BorderThickness = new Thickness(2);
            result.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(154, 34, 46));
            //AddMetroResources(result);
            return result;
        }

        private void AddMetroResources(MetroWindow window)
        {
            _resourceDictionaries = LoadResources();
            foreach (ResourceDictionary dictionary in _resourceDictionaries)
            {
                window.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        private ResourceDictionary[] LoadResources()
        {
            return new[]
                       {
                           new ResourceDictionary
                               {
                                   Source =
                                       new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source =
                                       new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source =
                                       new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source =
                                       new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source =
                                       new Uri(
                                       "pack://application:,,,/Caliburn.Metro.Core;component/Resources/Icons.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source =
                                       new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml",
                                       UriKind.RelativeOrAbsolute)
                               }

                       };
        }
    }
}
