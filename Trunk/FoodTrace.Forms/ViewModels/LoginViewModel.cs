﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using FoodTrace.Common;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.UserControls;
using FoodTrace.Forms.Views;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
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

        public static List<NaviModel> Navis =new List<NaviModel>();
        public static List<MenuModel> RoleMenuList=new List<MenuModel>(); 
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

                var win = GetView() as System.Windows.Window;
                if (win != null)
                {
                    if (user != null)
                    {
                        UserManagement.CurrentUser = user;
                        var company = new CompanyModel { CompanyID = user.CompanyId, CompanyName = user.CompanyName };
                        UserManagement.CurrentCompany = company;
                        LoadUserMenuNavi();
                        win.DialogResult = true;
                        win.Close();
                       
                    }
                    else
                    {
                        MessageBox.Show("用户名密码错误");
                    }

                }
        
        }

        public void LoadUserMenuNavi()
        {
            int roleId = UserManagement.CurrentUser.RoleId;
            IRoleService _roleService = new RoleService();
            var roleMenu = _roleService.GetRoleMenuByRoleId(roleId, 2);
            RoleMenuList = roleMenu;
            var module = roleMenu.Where(s => s.ParentID == 0).ToList();
            int i =1;
            module.ForEach(s =>
            {
                var naviModel = new NaviModel();
                naviModel.Name = s.Name;
                naviModel.NaviIndex = i++;
                naviModel.IsExpanded = false;
                naviModel.Menus = roleMenu.Where(m => m.ParentID == s.MenuID).Select(m => m.Name).ToList();
                Navis.Add(naviModel);
            });
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
