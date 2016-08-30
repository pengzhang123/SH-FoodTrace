using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI;
using System.Windows;
using Caliburn.Micro;
using FoodTrace.Common.Libraries;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.Views.BreedMng;
using FoodTrace.IService;
using FoodTrace.IService.BreedMng;
using FoodTrace.Model;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;
using FoodTrace.Service;
using FoodTrace.Service.BreedMng;

namespace FoodTrace.Forms.ViewModels.BreedMng
{
    [Export(typeof(BreedVarietyEditViewModel))]
    public class BreedVarietyEditViewModel : ViewAware
    {
        private readonly IBreedVarietyService _breedVarietyService=new BreedVarietyService();
        private readonly ICompanyService _companyService=new CompanyService();
        public BreedVarietyDto Model { get; set; }
        public EditMode Mode { get; set; }

        public void LoadUserControl(BreedVarietyEditView view)
        {
            var companys = _companyService.GetPagerCompany("", 1, 100);

            view.cbCompany.ItemsSource = companys;
            view.cbCompany.DisplayMemberPath = "CompanyName";
            view.cbCompany.SelectedValuePath = "CompanyID";
            view.cbCompany.SelectedValue = Model.CompanyId;
        }

        public void Save()
        {
            var model = DtoToModel(Model);
            var result = new MessageModel();
            if (Mode == EditMode.CREATE)
            {
                 result = _breedVarietyService.InsertVarietyModel(model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                 result = _breedVarietyService.UpdateVarietyModel(model);
            }

            if (result.Status != MessageStatus.Success)
            {
                MessageBox.Show("保存失败");
            }
            
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

        private BreedVarietyModel DtoToModel(BreedVarietyDto dto)
        {
            var model = new BreedVarietyModel();

            model.VarietyId = dto.VarietyId;
            model.VarietyName = dto.VarietyName;
            model.CompanyId = dto.CompanyId;
            model.ModifyID = UserManagement.CurrentUser.UserID;
            model.ModifyName = UserManagement.CurrentUser.UserName;
            model.ModifyTime = DateTime.Now;
            model.IsLocked = dto.IsLocked;
            model.Remark = dto.Remark;
            model.IsShow = dto.IsShow;

            return model;
        }
    }
}
