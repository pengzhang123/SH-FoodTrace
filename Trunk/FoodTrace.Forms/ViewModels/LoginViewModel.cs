using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using FoodTrace.Common;
using FoodTrace.Forms.UserControls;
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
        //ICompanyService iCompanyService = new CompanyService();
        IUserLoginService _user=new UserLoginService();
        public string LoginName { get; set; }
        private SJTextBox Upwd { get; set; }
        public string Password { get; set; }

        public void LoadUserControl(LoginView view)
        {
            Upwd = view.Upwd;
        }
        public void Login()
        {
            if (string.IsNullOrEmpty(LoginName))
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            string userPwd = Upwd.PasswordStr;
            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("请输入用户密码");
                return;
            }
            string name = LoginName;
            string pwd = EncodeStrToMd5.String32ToMD5(userPwd);
            var user = _user.GetUserLoginDto(name, pwd);

                UserManagement.CurrentUser = user;
                var win = GetView() as System.Windows.Window;
                if (win != null)
                {
                    if (user != null)
                    {
                        win.DialogResult = true;
                        win.Close();
                       
                    }
                    else
                    {
                        MessageBox.Show("用户名密码错误");
                    }

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
