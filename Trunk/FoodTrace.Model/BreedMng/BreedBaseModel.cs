using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("BMS_BREED_BASE")]
    public class BreedBaseModel:BaseModel
    {
        [Key]
        public int BreedID { get; set; }
        public int? LandID { get; set; }

        [ForeignKey("LandID")]
        public virtual LandBaseModel LandBase { get; set; }

        public string BreedName { get; set; }
        public int? BreedCode { get; set; }
        public string BreedArea { get; set; }
        public string BreedType { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Remark { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsShow { get; set; }
    }
}
