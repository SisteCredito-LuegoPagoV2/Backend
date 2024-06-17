using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class Purchase
    {
        public int id {get;set;}
        
        [Required(ErrorMessage = "This field is necessary")]
        public int user_id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public DateTime date {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public decimal amount {get;set;}

        
        //Relaciòn: Purchase is listed by MarketplaceUser - 
        [Required(ErrorMessage = " This field is necessary")]

        public MarketplaceUser? MarketplaceUsers {get;set;}

        //Relaciòn: Purchase is listed by PurchaseCoupon -
        [JsonIgnore]
        public ICollection<PurchaseCoupon>? PurchaseCoupons {get;set;}

    }
}