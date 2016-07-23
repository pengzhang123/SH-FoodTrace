using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_LOG")]
    public class BreedLogModel : BaseModel
    {
        [Key]
        public int LogID { get; set; }
        public int CultivationID { get; set; }
        public int? BreedID { get; set; }
        public int? AreaID { get; set; }
        public int? HomeID { get; set; }
        public string CultivationEpc { get; set; }
        public string BatchCode { get; set; }

        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
