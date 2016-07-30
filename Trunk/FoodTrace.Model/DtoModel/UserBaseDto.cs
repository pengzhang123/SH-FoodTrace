using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    public class UserBaseDto
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DeptName { get; set; }
        public string CompanyName { get; set; }
        public int? DeptID { get; set; }
        public int? CompanyID { get; set; }
        public string AreaCode { get; set; }
        public int? UserType { get; set; }
        public int? Status { get; set; }
        public bool? IsLocked { get; set; }
        public int? CreateID { get; set; }
        public string CreateName { get; set; }
        public DateTime? ModifyTime{ get; set; }
        public DateTime? CreateTime { get; set; }
        public string UserTypeStr{ get { return UserType == 1 ? "普通" : "管理员"; }}


        public int DetailId { get; set; }
        public string UserPhoto { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? FormalDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string QQ { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Email { get; set; }
        public string IDCard { get; set; }
        public string Mobile { get; set; }
        public int? Marriage { get; set; }
        public int? Gender { get; set; }
        public int? Education { get; set; }
        public string HomeAddress { get; set; }
        public string Remark { get; set; }
        public string AttendanceNo { get; set; }
        public string BankNo { get; set; }
    }
}
