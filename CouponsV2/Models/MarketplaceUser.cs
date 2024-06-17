using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class MarketplaceUser
    {
        public int id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? username {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? password {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? email {get;set;}


        //Relaciòn : MarketplaceUser is listed by Purchase -

        [JsonIgnore]
        public ICollection<Purchase>? Purchases {get;set;}

        //Relaciòn: MarketplaceUser is listed by CouponUsage - 
        
        [JsonIgnore]
        public ICollection<CouponUsage> ? CouponUsages {get;set;}

    }
}