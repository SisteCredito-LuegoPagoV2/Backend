using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class MarketplaceUser
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Username {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Password {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Email {get;set;}


        //Relaciòn : MarketplaceUser is listed by Purchase -

        // [JsonIgnore]
        // public List<Purchase>? Purchases {get;set;}

        // //Relaciòn: MarketplaceUser is listed by CouponUsage - 
        
        // [JsonIgnore]
        // public List<CouponUsage> ? CouponUsages {get;set;}

    }
}