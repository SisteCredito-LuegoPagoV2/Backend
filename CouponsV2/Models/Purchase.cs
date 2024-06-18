using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class Purchase
    {
        public int Id {get;set;}
        
        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey("MarketplaceUsers")]
        public int User_Id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly Date {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public decimal Amount {get;set;}

        
        //Relaciòn: Purchase is listed by MarketplaceUser - 
        // public MarketplaceUser? MarketplaceUsers {get;set;}

        //Relaciòn: Purchase is listed by PurchaseCoupon -
        // [JsonIgnore]
        // public List<PurchaseCoupon>? PurchaseCoupons {get;set;}

    }
}