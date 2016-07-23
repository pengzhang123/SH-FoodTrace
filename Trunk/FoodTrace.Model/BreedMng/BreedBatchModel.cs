using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_BATCH")]
    public class BreedBatchModel : BaseModel
    {
        [Key]
        public int BreedBatchID { get; set; }
        public int? BreedID { get; set; }

        [ForeignKey("BreedID")]
        public virtual BreedBaseModel BreedBase { get; set; }
        public string BatchNO { get; set; }
        public string RecvicePeople { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
