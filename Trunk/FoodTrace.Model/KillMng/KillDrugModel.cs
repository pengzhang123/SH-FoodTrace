using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    /// <summary>
    /// 屠宰场检验检疫记录
    /// </summary>
    [Table("BMS_KILL_DRUG")]
    public class KillDrugModel : BaseModel
    {
        [Key]
        public int DrugID { get; set; }

        public int? KillCullID { get; set; }
        [ForeignKey("KillCullID")]
        public virtual KillCullModel KillCull { get; set; }

        public string KillEpc { get; set; }
        public string People { get; set; }
        public DateTime? DrugTime { get; set; }
        public bool? IsNormal { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<KillDrugPicModel> KillDrugPic { get; set; }
        public virtual ICollection<KillDrugVideoModel> KillDrugVideo { get; set; }
    }

    /// <summary>
    /// 屠宰场检验检疫图片信息
    /// </summary>
    [Table("BMS_KILL_DRUG_PIC")]
    public class KillDrugPicModel : BasePicModel
    {
        [Key]
        public int PicID { get; set; }

        public int? DrugID { get; set; }
        [ForeignKey("DrugID")]
        public KillDrugModel KillDrug { get; set; }

    }

    /// <summary>
    /// 屠宰场检验检疫视频信息
    /// </summary>
    [Table("BMS_KILL_DRUG_VIEDO")]
    public class KillDrugVideoModel : BaseVideoModel
    {
        [Key]
        public int VideoID { get; set; }

        public int? DrugID { get; set; }
        [ForeignKey("DrugID")]
        public KillDrugModel KillDrug { get; set; }
    }
}
