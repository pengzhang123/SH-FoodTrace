using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    [Table("STM_LOG_USERLOGIN")]
    public class LogUserLoginModel
    {
        [Key]
        public int LoginID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserBaseModel UserBase { get; set; }

        public DateTime? LoginTime { get; set; }
        public int? LoginType { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }

    }
}
