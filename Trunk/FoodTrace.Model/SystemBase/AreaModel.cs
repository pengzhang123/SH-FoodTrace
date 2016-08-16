using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrace.Model
{
    [Table("STM_AREA")]
    public class AreaModel
    {
        [Key]
        public int AreaID { get; set; }
        public string AreaName { get; set; }

        public virtual ICollection<ProvinceModel> Province { get; set; }
    }

    [Table("STM_PROVINCE")]
    public class ProvinceModel
    {
        [Key]
        public int ProvinceID { get; set; }

        public int? AreaID { get; set; }
        [ForeignKey("AreaID")]
        public virtual AreaModel Area { get; set; }

        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
    }

    [Table("STM_CITY")]
    public class CityModel
    {
        [Key]
        public int CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string CityAreaCode { get; set; }

        public int? ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        public virtual ProvinceModel Province { get; set; }
    }

    [Table("STM_COUNTRY")]
    public class CountryModel
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public int? ProvinceId { get; set; }
        public int? CityID { get; set; }
        [ForeignKey("CityID")]
        public virtual CityModel City { get; set; }
    }
}
