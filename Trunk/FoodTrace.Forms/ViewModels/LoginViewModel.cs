using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodTrace.Forms.Views;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Service;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(LoginViewModel))]
    public class LoginViewModel : ViewAware
    {
        ICompanyService iCompanyService = new CompanyService();
        public string LoginName { get; set; }
        public void Login()
        {
            //System.Windows.Application.Current.Shutdown();
            string name = LoginName;
            UserManagement.CurrentCompany = iCompanyService.GetCompanyById(UserManagement.CurrentUser.CompanyId);


            var win = GetView() as System.Windows.Window;
            if (win != null)
            {
                win.DialogResult = true;
                win.Close();
            }
        }

        public void Cancel()
        {
            var win = GetView() as System.Windows.Window;
            if (win != null)
            {
                win.DialogResult = false;
                win.Close();
            }
        }
    }
}
