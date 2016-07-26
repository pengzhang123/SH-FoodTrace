using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("STM_USER_DETAIL")]
    public class UserDetailModel
    {
        [Key]
        public int DetailID { get; set; }


        public int UserID { get; set; }
        //[ForeignKey("UserID")]
        //public virtual UserBaseModel UserBase { get; set; }

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
